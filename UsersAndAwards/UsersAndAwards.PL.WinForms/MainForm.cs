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

            ctlUserStripMenu.Items.AddRange(new[] { ctlAddUser, ctlEditUser, ctlRemoveUser });

            ctlUsersGrid.ContextMenuStrip = ctlUserStripMenu;
            ctlAwardsGrid.ContextMenuStrip = ctlAwardStripMenu;

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
        //var connection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private void ctlUsersAndAwardsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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

        private void ctlAddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }

        private void addAwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAward();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAward();
        }

        private void editAwardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditAward();
        }

        private void removeAwardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemoveAward();
        }

        private void ctlEditUser_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void editAwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAward();
        }

        private void removeAwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAward();
        }

        private void ctlRemoveUser_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }

        private void AddAward()
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

        private void EditAward()
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

        private void RemoveAward()
        {
            var form = new DeleteAwardForm();
            bool deleted = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var award in memory.GetAllAwards())
                {
                    if (form.Title == award.Title)
                    {
                        if (memory.RemoveAward(award))
                        {
                            deleted = true;
                            break;
                        }

                    }
                }
            }
            if (!deleted)
            {
                MessageBox.Show("Award not found!", "Attention", MessageBoxButtons.OK);
            }
            ctlUsersGrid.DataSource = null;
            ctlAwardsGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlAwardsGrid.DataSource = memory.GetAllAwards();
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void AddUser()
        {
            var form = new AddEditUserForm(memory);

            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.AddUser(form.NewUser);
            }
            ctlUsersGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
        }

        private void EditUser()
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

        private void RemoveUser()
        {
            var form = new DeleteUserForm();
            bool deleted = false;

            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var user in memory.GetAllUsers())
                {
                    if (form.User.FirstName == user.FirstName && form.User.LastName == user.LastName &&
                        form.User.Birthdate == user.Birthdate)
                    {
                        if (memory.RemoveUser(user))
                        {
                            deleted = true;
                            break;
                        }

                    }
                }
            }
            if (!deleted)
            {
                MessageBox.Show("User not found!", "Attention", MessageBoxButtons.OK);
            }
            ctlUsersGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
        }
    }
}
