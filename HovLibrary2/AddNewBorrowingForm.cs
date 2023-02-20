using HovLibrary2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
    public partial class AddNewBorrowingForm : Form
    {
        private readonly HovLibraryModel _model;

        public AddNewBorrowingForm()
        {
            InitializeComponent();

            _model = new HovLibraryModel();

            Load += (sender, eventArgs) =>
            {
                titleTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                titleTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                titleTextBox.AutoCompleteCustomSource.AddRange(_model.Books
                    .Where(b => b.deleted_at == null)
                    .Select(b => b.title).ToArray());
                titleTextBox.TextChanged += (o, args) => LoadData();

                memberNameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                memberNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                memberNameTextBox.AutoCompleteCustomSource.AddRange(_model.Members
                    .Where(m => m.deleted_at == null)
                    .Select(m => m.name).ToArray());

                submitButton.Click += SubmitButton_Click;
            };
        }

        private void LoadData()
        {
            var book = _model.Books
                .FirstOrDefault(b => b.deleted_at == null && b.title == titleTextBox.Text);
            if (book == null)
            {
                return;
            }

            var bookDetails = _model.BookDetails
                .Where(bd => bd.Book.id == book.id && bd.deleted_at == null)
                .Where(bd => !bd.Borrowings.Any(b => b.deleted_at == null)).AsEnumerable()
                .Select((bd) => new
                {
                    Id = bd.id,
                    Code = bd.code,
                    Location = bd.Location.name,
                    Status = "Available",
                }).ToList();
            dataGridView.DataSource = bookDetails;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(@"There no row in data grid view.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (var i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells["SelectedColumn"].Value == null)
                {
                    continue;
                }

                if (dataGridView.Rows[i].Cells["SelectedColumn"].Value.ToString() == "False")
                {
                    continue;
                }

                if (!int.TryParse(dataGridView.Rows[i].Cells["IdColumn"].Value.ToString(), out var bookDetailId))
                {
                    continue;
                }

                var member = _model.Members
                    .FirstOrDefault(b => b.deleted_at == null && b.name == memberNameTextBox.Text);
                if (member == null)
                {
                    MessageBox.Show(@"Failed to get data by name.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                var borrowing = new Borrowing
                {
                    member_id = member.id,
                    bookdetails_id = bookDetailId,
                    borrow_date = DateTime.Now,
                    created_at = DateTime.Now,
                };
                _model.Borrowings.Add(borrowing);
            }

            if (_model.ChangeTracker.Entries<Borrowing>().Any(entry => entry.State == EntityState.Added))
            {
                _model.SaveChanges();
                MessageBox.Show(@"Data successfully added.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                return;
            }

            MessageBox.Show(@"You not selected any checkbox in data grid view.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
