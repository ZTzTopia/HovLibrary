using HovLibrary2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary2
{
    public partial class LoginForm : Form
    {
        private readonly HovLibraryModel _model;
        private readonly ErrorProvider _errorProvider;

        public LoginForm()
        {
            InitializeComponent();

            _model = new HovLibraryModel();
            _errorProvider = new ErrorProvider();
            _errorProvider.BlinkRate = 0;

            Load += (sender, eventArgs) =>
            {
                loginButton.Click += Login_Click;
            };
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Join("", hashBytes.Select(b => b.ToString("x2")).ToArray()).ToLower();
            }
        }

        private bool ValidateTextBox()
        {
            var validateSuccess = true;

            _errorProvider.SetError(emailTextBox, string.Empty);
            _errorProvider.SetError(passwordTextBox, string.Empty);

            if (!Regex.IsMatch(emailTextBox.Text, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]{2,}$"))
            {
                _errorProvider.SetError(emailTextBox, @"Please enter a valid email address.");
                validateSuccess = false;
            }

            if (!string.IsNullOrWhiteSpace(passwordTextBox.Text) && passwordTextBox.Text.Length <= 64)
            {
                return validateSuccess;
            }

            _errorProvider.SetError(passwordTextBox, @"Please enter a value in the text box or the length of text is more than 64.");
            return false;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox())
            {
                return;
            }

            var hashedPassword = HashPassword(passwordTextBox.Text);
            var employee = _model.Employees
                .FirstOrDefault(em => em.email == emailTextBox.Text && em.password == hashedPassword);
            if (employee == null)
            {
                _errorProvider.SetError(emailTextBox, @"Your email is does not match to database.");
                _errorProvider.SetError(passwordTextBox, @"Your password is does not match to database.");
                return;
            }

            Hide();

            var form = new MdiForm();
            form.Closed += (obj, args) => Application.Exit();
            form.Logout += (o, eventArgs) =>
            {
                form.Hide();
                Show();
            };
            form.Show();
        }
    }
}
