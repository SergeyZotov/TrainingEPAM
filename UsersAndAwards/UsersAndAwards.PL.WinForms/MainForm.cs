using Entities;
using System;
using System.Windows.Forms;
using UsersAndAwards.BLL;
using UsersAndAwards.DAL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class MainForm : Form
    {
        IStorage memory;
        Logic logic;

        enum SortOrder
        {
            Asc,
            Desc
        };

        SortOrder lastNameSort = SortOrder.Asc;

        public MainForm()
        {
            memory = new InMemoryStorage();
            InitializeComponent();

            ctlTabs.TabPages[0].Text = "Users";
            ctlTabs.TabPages[1].Text = "Awards";

            addUserToolStripMenuItem.Enabled = editUserToolStripMenuItem.Enabled =
                removeUserToolStripMenuItem.Enabled = true;
            addAwardToolStripMenuItem.Enabled = editAwardToolStripMenuItem.Enabled =
                removeAwardToolStripMenuItem.Enabled = false;

            memory.AddUser(new User("Petr", "Petrov", new DateTime(1998, 1, 14)));
            memory.AddUser(new User("Sidor", "Sidorov", new DateTime(2000, 6, 28)));
            memory.AddUser(new User("Ivan", "Ivanov", new DateTime(1960, 7, 7)));
            memory.AddUser(new User("Sergey", "Zotov", new DateTime(2016, 12, 12)));
            memory.AddAward(new Award("Nobel prize", "Epic award"));
            memory.AddAward(new Award("Small prize", "Award"));
            logic = new Logic();
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlAwardsGrid.DataSource = memory.GetAllAwards();
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //var connection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            


        }

        private void ctlUsersAndAwardsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {

            var singleUser = ctlUsersGrid.CurrentRow.Index;

            var users = memory.GetAllUsers();

            var form = new AddEditUserForm(users[singleUser], memory);

            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.EditUser(form.NewUser, singleUser);
            }
            ctlUsersGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
        }

        private void btnAddAward_Click(object sender, EventArgs e)
        {
            var form = new AddEditAwardForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.AddAward(new Award(form.Title, form.Description));
            }
            ctlAwardsGrid.DataSource = null;
            ctlAwardsGrid.DataSource = memory.GetAllAwards();
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            var form = new DeleteUserForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var user in memory.GetAllUsers())
                {
                    if (form.user.FirstName == user.FirstName && form.user.LastName == user.LastName &&
                        form.user.Birthdate == user.Birthdate)
                    {
                        memory.RemoveUser(user);
                        break;
                    }

                }
            }
            ctlUsersGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
        }

        private void btnDeleteAward_Click(object sender, EventArgs e)
        {
            var form = new DeleteAwardForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var award in memory.GetAllAwards())
                {
                    if (form.Title == award.Title)
                    {
                        memory.RemoveAward(award);
                        break;
                    }
                }
            }
            ctlUsersGrid.DataSource = null;
            ctlAwardsGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlAwardsGrid.DataSource = memory.GetAllAwards();
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void btnEditAward_Click(object sender, EventArgs e)
        {
            var singleAward = ctlAwardsGrid.CurrentRow.Index;
            var awards = memory.GetAllAwards();
            var form = new AddEditAwardForm(awards[singleAward]);

            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.EditAward(form.Award, singleAward);
            }
            ctlUsersGrid.DataSource = null;
            ctlAwardsGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlAwardsGrid.DataSource = memory.GetAllAwards();
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void ctlTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctlTabs.SelectedIndex == 1)
            {
                addUserToolStripMenuItem.Enabled = editUserToolStripMenuItem.Enabled =
                    removeUserToolStripMenuItem.Enabled = false;
                addAwardToolStripMenuItem.Enabled = editAwardToolStripMenuItem.Enabled = 
                    removeAwardToolStripMenuItem.Enabled = true;

            }
            else
            {
                addUserToolStripMenuItem.Enabled = editUserToolStripMenuItem.Enabled =
                    removeUserToolStripMenuItem.Enabled = true;
                addAwardToolStripMenuItem.Enabled = editAwardToolStripMenuItem.Enabled =
                    removeAwardToolStripMenuItem.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Close();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddEditUserForm(memory);

            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.AddUser(form.NewUser);
            }

            ctlUsersGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
        }
    }
}
