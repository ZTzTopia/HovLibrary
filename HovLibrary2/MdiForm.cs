using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary2
{
    public partial class MdiForm : Form
    {
        public event EventHandler Logout;

        public MdiForm()
        {
            InitializeComponent();

            Load += (sender, eventArgs) =>
            {
                memberToolStripMenuItem.Click += (o, args) =>
                {
                    ShowChildForm(typeof(MasterMemberForm));
                };
                bookToolStripMenuItem.Click += (o, args) =>
                {
                    ShowChildForm(typeof(MasterBookForm));
                };
                newBorrowingToolStripMenuItem.Click += (o, args) =>
                {
                    ShowChildForm(typeof(AddNewBorrowingForm));
                };
                allBorrowingToolStripMenuItem.Click += (o, args) =>
                {
                    ShowChildForm(typeof(AllBorrowingForm));
                };
                logoutToolStripMenuItem.Click += (o, args) =>
                {
                    Logout?.Invoke(this, EventArgs.Empty);
                };
            };
        }

        private void ShowChildForm(Type attachFormToChild)
        {
            foreach (var childForm in MdiChildren)
            {
                if (childForm.GetType() != attachFormToChild)
                {
                    continue;
                }

                childForm.BringToFront();
                return;
            }

            var form = (Form)Activator.CreateInstance(attachFormToChild);
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MdiParent = this;
            form.Show();
        }
    }
}
