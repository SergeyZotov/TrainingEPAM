using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        SortOrder Sort = SortOrder.Asc;

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
            ctlUsersGrid.Columns[0].Visible = false;
        }
        //var connection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private void ctlUsersGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var list = (List<UserViewModel>)ctlUsersGrid.DataSource;
            ctlUsersGrid.DataSource = null;

            if (e.ColumnIndex == 0)
            {
                if (Sort == SortOrder.Asc)
                {
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.FirstName).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.FirstName).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else if (e.ColumnIndex == 1)
            {
                if (Sort == SortOrder.Asc)
                {
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.LastName).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.LastName).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (Sort == SortOrder.Asc)
                {
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.Birthdate).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.Birthdate).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else
            {
                ctlUsersGrid.DataSource = list;
            }
            ctlUsersGrid.Columns[0].Visible = false;
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
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void RemoveAward()
        {
            var userList = (List<UserViewModel>)ctlUsersGrid.DataSource;
            var awardList = (List<Award>)ctlAwardsGrid.DataSource;
            bool deleted = false;
            foreach (var award in memory.GetAllAwards())
            {
                foreach (DataGridViewRow index in ctlAwardsGrid.Rows)
                {
                    if (index.Selected && award.Id == (int)index.Cells[0].Value)
                    {
                        if (memory.RemoveAward(award) && MessageBox.Show("Are you sure?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            deleted = true;
                            break;
                        }
                    }

                }
                if (deleted)
                {
                    break;
                }
            }
            ctlUsersGrid.DataSource = null;
            ctlAwardsGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlAwardsGrid.DataSource = memory.GetAllAwards();
            ctlAwardsGrid.Columns[0].Visible = false;
            ctlUsersGrid.Columns[0].Visible = false;
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
            ctlUsersGrid.Columns[0].Visible = false;
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
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void RemoveUser()
        {
            bool deleted = false;
            foreach (var user in memory.GetAllUsers())
            {
                foreach (DataGridViewRow index in ctlUsersGrid.Rows)
                {
                    if (index.Selected && user.Id == (int)index.Cells[0].Value)
                    {
                        if (memory.RemoveUser(user) && MessageBox.Show("Are you sure?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            deleted = true;
                            break;
                        }
                    }

                }
                if (deleted)
                {
                    break;
                }
            }
            ctlUsersGrid.DataSource = null;
            ctlUsersGrid.DataSource = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void ctlAwardsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var list = (List<Award>)ctlAwardsGrid.DataSource;

            ctlAwardsGrid.DataSource = null;

            if (e.ColumnIndex == 2)
            {
                if (Sort == SortOrder.Asc)
                {
                    ctlAwardsGrid.DataSource = list.OrderBy(u => u.Title).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    ctlAwardsGrid.DataSource = list.OrderByDescending(u => u.Title).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else
            {
                ctlAwardsGrid.DataSource = list;
            }
            ctlAwardsGrid.Columns[0].Visible = false;
        }
    }
}
