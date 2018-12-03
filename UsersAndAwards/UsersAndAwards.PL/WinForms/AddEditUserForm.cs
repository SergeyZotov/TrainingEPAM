using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using UsersAndAwards.BLL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class AddEditUserForm : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public User NewUser { get; set; }
        public List<string> checkedBoxes = new List<string>();

        Logic logic;

        public AddEditUserForm(Logic mem)
        {
            InitializeComponent();
            logic = mem;
            var awards = logic.GetAllAwards();
            foreach (var award in awards)
            {
                ctlCheckBoxAwards.Items.Add(award.Title, false);

            }
        }

        public AddEditUserForm(User user, Logic mem)
        {
            InitializeComponent();
            logic = mem;
            txtBirthdate.Text = user.Birthdate.ToShortDateString();
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            var awards = logic.GetAllAwards();
            int _index = 0;

            if (user.Awards.Any())
            {
                foreach (var award in awards)
                {
                    if (_index < user.Awards.Count && user.Awards[_index].AwardId == award.AwardId)
                    {
                        ctlCheckBoxAwards.Items.Add(award.Title, true);
                        _index++;
                    }
                    else
                    {
                        ctlCheckBoxAwards.Items.Add(award.Title, false);
                    }
                }
            }
            else
            {
                foreach (var award in awards)
                {
                    ctlCheckBoxAwards.Items.Add(award.Title, false);
                }
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

                var awards = logic.GetAllAwards();

                for (int i = 0; i < ctlCheckBoxAwards.Items.Count; ++i)
                {
                    for (int j = 0; j < awards.Count; j++)
                    {
                        if (NewUser.Awards.Count != 0)
                        {
                            for (int k = 0; k < NewUser.Awards.Count; ++k)
                            {
                                if (ctlCheckBoxAwards.GetItemChecked(i) && NewUser.Awards[k].AwardId != awards[j].AwardId && awards[j].Title == ctlCheckBoxAwards.Items[i].ToString())
                                {
                                    NewUser.AddAward(awards[j]);
                                }
                                else if (!ctlCheckBoxAwards.GetItemChecked(i) && NewUser.Awards[k].AwardId == awards[j].AwardId && awards[j].Title == ctlCheckBoxAwards.Items[i].ToString())
                                {
                                    NewUser.RemoveAward(NewUser.Awards[k]);
                                }
                            }
                        }
                        else
                        {
                            if (ctlCheckBoxAwards.GetItemChecked(i) && awards[j].Title == ctlCheckBoxAwards.Items[i].ToString())
                            {
                                NewUser.AddAward(awards[j]);
                            }
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
