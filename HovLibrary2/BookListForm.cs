using HovLibrary2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary2
{
    public partial class BookListForm : Form
    {
        public Book Book { get; set; }
        private readonly HovLibraryModel _model;

        public BookListForm()
        {
            InitializeComponent();

            _model = new HovLibraryModel();

            Load += (sender, eventArgs) =>
            {
                titleTextBox.Text = Book.title;

                LoadData();
                dataGridView.CellContentClick += DataGridView_CellContentClick;

                LanguageComboBox.Items.AddRange(new object[] { "" });
                LanguageComboBox.Items.AddRange(_model.Locations
                    .Where(l => l.deleted_at == null)
                    .Select(l => l.name)
                    .ToArray<object>());
                LanguageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;

                submitButton.Click += SubmitButton_Click;
            };
        }

        private void LoadData()
        {
            var bookDetails = _model.BookDetails
                .Where(bd => bd.Book.id == Book.id && bd.deleted_at == null).AsEnumerable()
                .Select(bd => new
                {
                    Id = bd.id,
                    Code = bd.code,
                    Location = bd.Location.name,
                    Status = bd.Borrowings.Any(b => b.deleted_at == null) ? "Unavailable" : "Available",
                }).ToList();
            dataGridView.DataSource = bookDetails;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var deleteColumn = dataGridView.Columns["DeleteColumn"];
            if (deleteColumn == null)
            {
                return;
            }

            if (e.ColumnIndex != deleteColumn.Index)
            {
                return;
            }

            if (MessageBox.Show(@"Are you sure want delete this book list data?", @"Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            if (!int.TryParse(dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString(), out var bookDetailId))
            {
                return;
            }

            var bookDetail = _model.BookDetails
                .Where(bd => !bd.Borrowings.Any(b => b.deleted_at == null))
                .FirstOrDefault(bd => bd.id == bookDetailId);
            if (bookDetail == null)
            {
                MessageBox.Show(@"Failed to get book detail data by id or maybe the book is currently borrowed.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _model.BookDetails.Remove(bookDetail);
            _model.SaveChanges();
            MessageBox.Show(@"Data successfully deleted.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LanguageComboBox.Text))
            {
                codeTextBox.Text = string.Empty;
                submitButton.Enabled = false;
                return;
            }

            var location = _model.Locations
                .FirstOrDefault(l => l.name == LanguageComboBox.Text);
            if (location == null)
            {
                MessageBox.Show(@"Failed to get location data by name.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lastId = _model.BookDetails
                .OrderByDescending(bd => bd.id)
                .Select(bd => bd.id)
                .FirstOrDefault();
            codeTextBox.Text = $@"{lastId + 1:0000}.{Book.id:0000}.{location.id:00}.{Book.publication_date:yyyy}";
            submitButton.Enabled = true;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            submitButton.Enabled = false;

            var location = _model.Locations
                .FirstOrDefault(l => l.name == LanguageComboBox.Text);
            if (location == null)
            {
                MessageBox.Show(@"Failed to get location data by name.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var bookDetail = new BookDetail
            {
                book_id = Book.id,
                location_id = location.id,
                code = codeTextBox.Text,
                created_at = DateTime.Now,
            };

            _model.BookDetails.Add(bookDetail);
            _model.SaveChanges();
            MessageBox.Show(@"Data successfully added.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }
    }
}
