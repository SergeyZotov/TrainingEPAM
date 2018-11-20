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

        private void btnOk_Validated(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            Birthdate = DateTime.Parse(txtBirthdate.Text);
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
