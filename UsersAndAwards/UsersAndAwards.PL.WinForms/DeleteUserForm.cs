using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UsersAndAwards.DAL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class DeleteUserForm : Form
    {
        public User user { get; set; }

        public DeleteUserForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (MessageBox.Show("Are you sure you want to remove this user?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }

            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void btnOk_Validated(object sender, EventArgs e)
        {
            user = new User(txtFirstName.Text, txtLastName.Text, DateTime.Parse(txtBirthdate.Text));
        }

        private void btnOk_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            DateTime.TryParse(txtBirthdate.Text, out DateTime bdate);

            bool valid = !string.IsNullOrWhiteSpace(lname) && !string.IsNullOrWhiteSpace(fname) &&
                !string.IsNullOrWhiteSpace(txtBirthdate.Text);

            if (valid)
            {
                ctlErrorProvider.SetError(txtFirstName, string.Empty);
                ctlErrorProvider.SetError(txtLastName, string.Empty);
                ctlErrorProvider.SetError(txtBirthdate, string.Empty);
                e.Cancel = false;
            }
            else
            {
                ctlErrorProvider.SetError(txtFirstName, "Пустое поле");
                ctlErrorProvider.SetError(txtLastName, "Пустое поле");
                ctlErrorProvider.SetError(txtBirthdate, "Пустое поле");
                e.Cancel = true;
            }
        }
    }
}
