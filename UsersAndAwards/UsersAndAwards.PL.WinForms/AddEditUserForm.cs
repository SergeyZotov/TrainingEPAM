using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UsersAndAwards.DAL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class AddEditUserForm : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public User NewUser { get; set; }
        public List<string> checkedBoxes = new List<string>();

        IStorage memory;

        public AddEditUserForm(IStorage mem)
        {
            InitializeComponent();
            memory = mem;
            foreach (var award in memory.GetAllAwards())
            {
                ctlCheckBoxAwards.Items.Add(award.Title, false);       
            }
        }

        public AddEditUserForm(User user, IStorage mem)
        {
            InitializeComponent();
            memory = mem;
            txtBirthdate.Text = user.Birthdate.ToShortDateString();
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            foreach (var award in memory.GetAllAwards())
            {
                if (user.GetAwards().Contains(award))
                    ctlCheckBoxAwards.Items.Add(award.Title, true);
                else
                    ctlCheckBoxAwards.Items.Add(award.Title, false);
            }

            NewUser = user;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (NewUser != null)
                {
                    NewUser.FirstName = FirstName;
                    NewUser.LastName = LastName;
                    NewUser.Birthdate = Birthdate;
                }
                else
                {
                    NewUser = new User(FirstName, LastName, Birthdate);
                }

                for (int i = 0; i < ctlCheckBoxAwards.Items.Count; ++i)
                {
                    foreach(var award in memory.GetAllAwards())
                    {
                        if (ctlCheckBoxAwards.GetItemChecked(i) && !NewUser.GetAwards().Contains(award) && award.Title == ctlCheckBoxAwards.Items[i].ToString())
                        {
                            NewUser.AddAward(award);
                        }
                        else if (!ctlCheckBoxAwards.GetItemChecked(i) && NewUser.GetAwards().Contains(award) && award.Title == ctlCheckBoxAwards.Items[i].ToString())
                        {
                            NewUser.RemoveAward(award);
                        }
                    }
                } 

                DialogResult = DialogResult.OK;
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
            bool valid =  !string.IsNullOrWhiteSpace(txtBirthdate.Text) && DateTime.TryParse(txtBirthdate.Text, out DateTime bdate);

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
