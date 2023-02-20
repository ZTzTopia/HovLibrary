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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HovLibrary2
{
    public partial class MasterBookForm : Form
    {
        private readonly HovLibraryModel _model;
        private IQueryable<Book> _bookQueryable;
        private int _selectedId;

        public MasterBookForm()
        {
            InitializeComponent();

            _model = new HovLibraryModel();
            _selectedId = -1;

            Load += (sender, eventArgs) =>
            {
                searchByComboBox.Items.AddRange(new object[] { "", "Title", "Author", "Publisher" });
                searchByComboBox.TextChanged += (o, args) =>
                {
                    textBox1.Enabled = true; 
                    searchByButton.Enabled = true;
                };
                searchByButton.Click += SearchByButton_Click;

                filterLanguageComboBox.Items.AddRange(new object[] { "" });
                filterLanguageComboBox.Items.AddRange(_model.Languages.Where(l => l.deleted_at == null).Select(l => l.long_text).ToArray<object>());
                filterLanguageComboBox.TextChanged += (o, args) => applyButton.Enabled = true;
                minPublishDateTimePicker.TextChanged += (o, args) => applyButton.Enabled = true;
                maxPublishDateTimePicker.TextChanged += (o, args) => applyButton.Enabled = true;
                minPageCountNumericUpDown.TextChanged += (o, args) => applyButton.Enabled = true;
                maxPageCountNumericUpDown.TextChanged += (o, args) => applyButton.Enabled = true;
                minRatingsNumericUpDown.TextChanged += (o, args) => applyButton.Enabled = true;
                maxRatingsNumericUpDown.TextChanged += (o, args) => applyButton.Enabled = true;
                applyButton.Click += ApplyButton_Click;

                LoadData();
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.CellContentClick += DataGridView_CellContentClick;
                
                languageComboBox.Items.AddRange(_model.Languages.Where(l => l.deleted_at == null).Select(l => l.long_text).ToArray<object>());
                publisherComboBox.Items.AddRange(_model.Publishers.Where(p => p.deleted_at == null).Select(p => p.name).ToArray<object>());
                saveChangesButton.Click += SaveChangesButton_Click;
            };
        }

        private void LoadData(IQueryable<Book> bookQueryable = null)
        {
            if (bookQueryable == null)
            {
                bookQueryable = _model.Books;
            }

            _bookQueryable = bookQueryable;
            var books = bookQueryable
                .Where(b => b.deleted_at == null).AsEnumerable()
                .Select(b =>
                new
                {
                    Id = b.id,
                    Language = b.Language.long_text,
                    Title = b.title,
                    Isbn = b.isbn,
                    Isbn13 = b.isbn13,
                    Authors = b.authors,
                    Publisher = b.Publisher.name,
                    PublishDate = b.publication_date.ToString("dd MMMM yyyy"),
                    PageCount = b.number_of_pages,
                    Ratings = $"{b.average_rating} ({b.ratings_count})"
                }).ToList();
            dataGridView.DataSource = books;
        }

        private void SearchByButton_Click(object sender, EventArgs e)
        {
            var books = _model.Books.AsQueryable();
            switch (searchByComboBox.Text)
            {
                case "Title":
                    books = books
                        .Where(b => b.title.ToLower().Contains(textBox1.Text.ToLower()));
                    break;
                case "Author":
                    books = books
                        .Where(b => b.authors.ToLower().Contains(textBox1.Text.ToLower()));
                    break;
                case "Publisher":
                    books = books
                        .Where(b => b.Publisher.name.ToLower().Contains(textBox1.Text.ToLower()));
                    break;
            }

            LoadData(books);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var books = _model.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterLanguageComboBox.Text))
            {
                books = books
                    .Where(b => b.Language.long_text == filterLanguageComboBox.Text);
            }

            if (minPublishDateTimePicker.Value.Date != maxPublishDateTimePicker.Value.Date)
            {
                if (minPublishDateTimePicker.Value.Date > maxPublishDateTimePicker.Value.Date)
                {
                    MessageBox.Show(@"Minimal publish date is greater than maximal publish date.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                books = books.AsEnumerable()
                    .Where(b => b.publication_date >= minPublishDateTimePicker.Value.Date && b.publication_date <= maxPublishDateTimePicker.Value.Date.AddHours(23).AddMinutes(59)).AsQueryable();
            }

            if (minPageCountNumericUpDown.Value != 0 || maxPageCountNumericUpDown.Value != 0)
            {
                if (minPageCountNumericUpDown.Value > maxPageCountNumericUpDown.Value)
                {
                    MessageBox.Show(@"Minimal page count is greater than maximal page count.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                books = books
                    .Where(b => b.number_of_pages >= minPageCountNumericUpDown.Value && b.number_of_pages <= maxPageCountNumericUpDown.Value);
            }

            if (minRatingsNumericUpDown.Value != 0 || maxRatingsNumericUpDown.Value != 0)
            {
                if (minRatingsNumericUpDown.Value > maxRatingsNumericUpDown.Value)
                {
                    MessageBox.Show(@"Minimal ratings is greater than maximal ratings.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double.TryParse(minRatingsNumericUpDown.Value.ToString(), out var minRatings);
                double.TryParse(maxRatingsNumericUpDown.Value.ToString(), out var maxRatings);

                books = books
                    .Where(b => b.average_rating >= minRatings && b.average_rating <= maxRatings);
            }

            LoadData(books);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedRow = dataGridView.SelectedRows[0];
            if (selectedRow == null)
            {
                return;
            }

            var cells = selectedRow.Cells;
            languageComboBox.Text = cells["LanguageColumn"].Value.ToString();
            titleTextBox.Text = cells["TitleColumn"].Value.ToString();
            isbnTextBox.Text = cells["IsbnColumn"].Value.ToString();
            isbn13TextBox.Text = cells["Isbn13Column"].Value.ToString();
            authorsTextBox.Text = cells["AuthorsColumn"].Value.ToString();
            publisherComboBox.Text = cells["PublisherColumn"].Value.ToString();
            publishDateTimePicker.Text = cells["PublishDateColumn"].Value.ToString();
            pageCountTextBox.Text = cells["PageCountColumn"].Value.ToString();
            ratingsTextBox.Text = cells["RatingsColumn"].Value.ToString();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var bookListColumn = dataGridView.Columns["BookListColumn"];
            if (bookListColumn != null && e.ColumnIndex == bookListColumn.Index)
            {
                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString(), out var bookId))
                {
                    var book = _model.Books
                        .FirstOrDefault(m => m.id == bookId);
                    if (book == null)
                    {
                        MessageBox.Show(@"Failed to get book data by id.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var form = new BookListForm { Book = book };
                    form.ShowDialog();
                    return;
                }
            }

            var deleteColumn = dataGridView.Columns["deleteColumn"];
            if (deleteColumn != null && e.ColumnIndex == deleteColumn.Index)
            {
                if (MessageBox.Show(@"Are you sure want delete this book data?", @"Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString(), out var bookId))
                {
                    var book = _model.Books
                        .FirstOrDefault(m => m.id == bookId);
                    if (book == null)
                    {
                        MessageBox.Show(@"Failed to get book data by id.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (var bookDetail in book.BookDetails.ToList())
                    {
                        _model.BookDetails.Remove(bookDetail);
                    }

                    _model.Books.Remove(book);

                    _model.SaveChanges();
                    MessageBox.Show(@"Data successfully deleted.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData(_bookQueryable);
                    return;
                }
            }

            var editColumn = dataGridView.Columns["EditColumn"];
            if (editColumn == null)
            {
                return;
            }

            if (e.ColumnIndex != editColumn.Index)
            {
                return;
            }

            if (!int.TryParse(dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString(), out _selectedId))
            {
                _selectedId = -1;
                return;
            }

            saveChangesButton.Enabled = true;
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            saveChangesButton.Enabled = false;

            var book = _model.Books
                .FirstOrDefault(m => m.id == _selectedId);
            if (book == null)
            {
                MessageBox.Show(@"Failed to get book data by id.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var language = _model.Languages
                .FirstOrDefault(l => l.long_text == languageComboBox.Text);
            if (language == null)
            {
                MessageBox.Show(@"Failed to get language data by long text.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var publisher = _model.Publishers
                .FirstOrDefault(p => p.name == publisherComboBox.Text);
            if (publisher == null)
            {
                MessageBox.Show(@"Failed to get publisher data by name.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            book.language_id = language.id;
            book.title = titleTextBox.Text;
            book.isbn = isbnTextBox.Text;
            book.isbn13 = isbn13TextBox.Text;
            book.authors = authorsTextBox.Text;
            book.publisher_id = publisher.id;

            if (DateTime.TryParse(publishDateTimePicker.Text, out var publishDate))
            {
                book.publication_date = publishDate;
            }

            if (int.TryParse(pageCountTextBox.Text, out var pageCount))
            {
                book.number_of_pages = pageCount;
            }

            if (double.TryParse(ratingsTextBox.Text.Split('(')[0], out var averageRating))
            {
                book.average_rating = averageRating;
            }

            var ratingCountText = pageCountTextBox.Text;
            var index = ratingCountText.IndexOf("(", StringComparison.Ordinal) + 1;
            var length = ratingCountText.Length - 1;
            if (int.TryParse(ratingCountText.Substring(index, length), out var ratingCount))
            {
                book.ratings_count = ratingCount;
            }

            _model.SaveChanges();
            MessageBox.Show(@"Data successfully changed.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData(_bookQueryable);
        }
    }
}
