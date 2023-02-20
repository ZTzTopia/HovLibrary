using HovLibrary2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary2
{
    public partial class MasterMemberForm : Form
    {
        private readonly HovLibraryModel _model;
        private int _selectedId;

        public MasterMemberForm()
        {
            InitializeComponent();

            _model = new HovLibraryModel();
            _selectedId = -1;

            Load += (o, eventArgs) =>
            {
                LoadData();
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.CellContentClick += DataGridView_CellContentClick;

                saveChangesButton.Click += SaveChangesButton_Click;
            };
        }

        private void LoadData()
        {
            var members = _model.Members
                .Where(m => m.deleted_at == null).AsEnumerable()
                .Select(m => new
                {
                    Id = m.id,
                    Name = m.name,
                    Phone = m.phone_number,
                    Email = m.email,
                    CityOfBirth = m.city_of_birth,
                    DateOfBirth = m.date_of_birth.ToString("dd MMMM yyyy"),
                    Address = m.address,
                    Gender = m.gender
                }).ToList();
            dataGridView.DataSource = members;
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
            nameTextBox.Text = cells["NameColumn"].Value.ToString();
            phoneTextBox.Text = cells["PhoneColumn"].Value.ToString();
            emailTextBox.Text = cells["EmailColumn"].Value.ToString();
            addressTextBox.Text = cells["AddressColumn"].Value.ToString();
            cityOfBirthTextBox.Text = cells["CityOfBirthColumn"].Value.ToString();
            dateOfBirthTimePicker.Text = cells["DateOfBirthColumn"].Value.ToString();

            if (cells["GenderColumn"].Value.ToString().Equals("Male"))
            {
                maleRadioButton.Checked = true;
            }
            else
            {
                femaleRadioButton.Checked = true;
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

            var member = _model.Members
                .FirstOrDefault(m => m.id == _selectedId);
            if (member == null)
            {
                MessageBox.Show(@"Failed to get member data by id.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            member.name = nameTextBox.Text;
            member.phone_number = phoneTextBox.Text;
            member.email = emailTextBox.Text;
            member.address = addressTextBox.Text;
            member.city_of_birth = cityOfBirthTextBox.Text;
            member.gender = maleRadioButton.Checked ? "Male" : "Female";

            if (DateTime.TryParse(dateOfBirthTimePicker.Text, out var dateOfBirth))
            {
                member.date_of_birth = dateOfBirth;
            }

            _model.SaveChanges();
            MessageBox.Show(@"Data successfully changed.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }
    }
}
