using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UsersAndAwards.DAL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class DeleteUserForm : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public User User { get; set; }

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
                    User = new User(txtFirstName.Text, txtLastName.Text, DateTime.Parse(txtBirthdate.Text));
                    DialogResult = DialogResult.OK;
                }

            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fname = txtFirstName.Text;
            bool valid = !string.IsNullOrWhiteSpace(fname);

            if (valid)
            {
                ctlErrorProvider.SetError(txtFirstName, string.Empty);
                e.Cancel = false;
            }
            else
            {
                ctlErrorProvider.SetError(txtFirstName, "First Name cannot be empty");
                e.Cancel = true;
            }
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            LastName = txtLastName.Text;
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string lname = txtLastName.Text;
            bool valid = !string.IsNullOrWhiteSpace(lname);

            if (valid)
            {
                ctlErrorProvider.SetError(txtLastName, string.Empty);
                e.Cancel = false;
            }
            else
            {
                ctlErrorProvider.SetError(txtLastName, "Last Name cannot be empty");
                e.Cancel = true;
            }
        }

        private void txtBirthdate_Validated(object sender, EventArgs e)
        {
            Birthdate = DateTime.Parse(txtBirthdate.Text);
        }

        private void txtBirthdate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool valid = !string.IsNullOrWhiteSpace(txtBirthdate.Text) && DateTime.TryParse(txtBirthdate.Text, out DateTime bdate);

            if (valid)
            {
                ctlErrorProvider.SetError(txtBirthdate, string.Empty);
                e.Cancel = false;
            }
            else
            {
                ctlErrorProvider.SetError(txtBirthdate, "Birthdate cannot be empty and must be correct");
                e.Cancel = true;
            }
        }
    }
}
