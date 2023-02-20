using HovLibrary2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary2
{
    public partial class AllBorrowingForm : Form
    {
        private readonly HovLibraryModel _model;
        private IQueryable<Borrowing> _borrowingFilter;

        public AllBorrowingForm()
        {
            InitializeComponent();

            _model = new HovLibraryModel();

            Load += (sender, eventArgs) =>
            {
                bookStatusComboBox.Items.AddRange(new object[] { "", "Ongoing", "Late", "Returned" });
                bookStatusComboBox.TextChanged += (o, args) =>
                {
                    minBorrowDateTimePicker.Enabled = true;
                    maxBorrowDateTimePicker.Enabled = true;
                    applyButton.Enabled = true;
                };
                applyButton.Click += Apply_ButtonClick;

                LoadData();
                dataGridView.CellContentClick += DataGridView_CellContentClick;
            };
        }

        private void LoadData(IQueryable<Borrowing> borrowingQueryable = null)
        {
            if (borrowingQueryable == null)
            {
                borrowingQueryable = _model.Borrowings;
            }

            _borrowingFilter = borrowingQueryable;
            var borrowings = borrowingQueryable
                .Where(b => b.deleted_at == null).AsEnumerable()
                .Select(b => new
                {
                    Id = b.id,
                    MemberName = b.Member.name,
                    BookTitle = b.BookDetail.Book.title,
                    BookCode = b.BookDetail.code,
                    BorrowDate = b.borrow_date.ToString("dd MMMM yyyy"),
                    ReturnDate = b.return_date == null ? "" : b.return_date?.ToString("dd MMMM yyyy"),
                    Fine = b.fine
                }).ToList();
            dataGridView.DataSource = borrowings;
        }

        private void Apply_ButtonClick(object sender, EventArgs e)
        {
            var borrowings = _model.Borrowings.AsQueryable();
            switch (bookStatusComboBox.Text)
            {
                case "Ongoing":
                    borrowings = borrowings.Where(b => b.return_date == null);
                    break;
                case "Late":
                    borrowings = borrowings
                        .Where(b => b.return_date == null).AsEnumerable()
                        .Where(b => DateTime.Now >= b.borrow_date.AddDays(7)).AsQueryable();
                    break;
                case "Returned":
                    borrowings = borrowings.Where(b => b.return_date != null);
                    break;
                default:
                    LoadData();
                    return;
            }

            if (minBorrowDateTimePicker.Value.Date != maxBorrowDateTimePicker.Value.Date)
            {
                if (minBorrowDateTimePicker.Value.Date > maxBorrowDateTimePicker.Value.Date)
                {
                    MessageBox.Show(@"Minimal borrow date is greater than maximal borrow date.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                borrowings = borrowings.AsEnumerable()
                    .Where(b => b.borrow_date >= minBorrowDateTimePicker.Value.Date && b.borrow_date <= maxBorrowDateTimePicker.Value.Date.AddHours(23).AddMinutes(59)).AsQueryable();
            }
            
            LoadData(borrowings);
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var editColumn = dataGridView.Columns["ReturnColumn"];
            if (editColumn == null)
            {
                return;
            }

            if (e.ColumnIndex != editColumn.Index)
            {
                return;
            }

            if (!int.TryParse(dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString(), out var borrowingId))
            {
                return;
            }

            var borrowing = _model.Borrowings
                .FirstOrDefault(b => b.id == borrowingId);
            if (borrowing == null) 
            {
                MessageBox.Show(@"Failed to get borrowing data by id.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            borrowing.return_date = DateTime.Now;
            if (borrowing.return_date?.AddDays(7) >= borrowing.borrow_date)
            {
                var timeSpan = borrowing.return_date?.Date.Subtract(borrowing.borrow_date);
                borrowing.fine = timeSpan?.Days * 1000;
            }

            _model.SaveChanges();
            MessageBox.Show(@"Data successfully changed.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData(_borrowingFilter);
        }
    }
}
