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
        IStorage dataBase;
        IStorage storage;


        enum SortOrder
        {
            Asc,
            Desc
        };

        // [0,] - fname, [1,] - lname, [2,] - bdate, [3,] - awards
        // [,0] - Asc, [,1] - Des
        private bool[,] HowIsUsersSorted = new bool[6, 2];
        private bool[,] HowIsAwardsSorted = new bool[3, 2]; 

        SortOrder Sort = SortOrder.Asc;

        public MainForm()
        {
            /*if (DBStorage.connection.Contains("System.Data.SqlClient"))
            {*/
                memory = new DBStorage(DBStorage.connection);
            /*}
            else
            {
                memory = new InMemoryStorage();
            }*/

            //dataBase = new DBStorage(DBStorage.connection);

            // values for default table that you see the first time
            HowIsUsersSorted[5, 0] = true;
            HowIsAwardsSorted[2, 0] = true;

            InitializeComponent();

            ctlTabs.TabPages[0].Text = "Users";
            ctlTabs.TabPages[1].Text = "Awards";

            addUserToolStripMenuItem.Enabled = editUserToolStripMenuItem.Enabled =
                removeUserToolStripMenuItem.Enabled = true;
            addAwardToolStripMenuItem.Enabled = editAwardToolStripMenuItem.Enabled =
                removeAwardToolStripMenuItem.Enabled = false;

            ctlUserStripMenu.Items.AddRange(new[] { ctlAddUser, ctlEditUser, ctlRemoveUser });
            ctlAwardStripMenu.Items.AddRange(new[] { ctlAddAward, ctlEditAward, ctlRemoveAward });

            ctlUsersGrid.ContextMenuStrip = ctlUserStripMenu;
            ctlAwardsGrid.ContextMenuStrip = ctlAwardStripMenu;



            memory.AddUser(new User("Petr", "Petrov", new DateTime(1998, 1, 14)));
            memory.AddUser(new User("Sidor", "Sidorov", new DateTime(2000, 6, 28)));
            memory.AddUser(new User("Ivan", "Ivanov", new DateTime(1960, 7, 7)));
            memory.AddUser(new User("Sergey", "Zotov", new DateTime(2016, 12, 12)));
            memory.AddAward(new Award("Nobel prize", "Epic award"));
            memory.AddAward(new Award("Small prize", "Award"));
            logic = new Logic();

            //ctlUsersGrid.AutoGenerateColumns = false;

            ctlUsersGrid.DataSource = /*dataBase.GetAllUsers(); logic.GetUsersForUI(dataBase.GetAllUsers(), dataBase); //*/logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlAwardsGrid.DataSource = /*dataBase.GetAllAwards(); //*/memory.GetAllAwards();

            ctlAwardsGrid.Columns[0].Visible = false;
            ctlUsersGrid.Columns[0].Visible = false;

        }

        private void ctlUsersGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var list = (List<UserViewModel>)ctlUsersGrid.DataSource;
            ctlUsersGrid.DataSource = null;

            int index = e.ColumnIndex;

            if (index == 1)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.FirstName).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.FirstName).ToList();
                    Sort = SortOrder.Asc;

                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.LastName).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.LastName).ToList();
                    Sort = SortOrder.Asc;

                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.Birthdate).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.Birthdate).ToList();
                    Sort = SortOrder.Asc;

                }
            }
            else if (e.ColumnIndex == 4)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.Age).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.Age).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderBy(u => u.Awards).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitArray(index, Sort);
                    ctlUsersGrid.DataSource = list.OrderByDescending(u => u.Awards).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else
            {
                ctlUsersGrid.DataSource = list;
            }
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void InitArray(int index, SortOrder sortOrder)
        {
            HowIsUsersSorted = new bool[6, 2];
            HowIsAwardsSorted = new bool[2, 2];

            if (index == 1 && sortOrder == SortOrder.Asc)
            {
                HowIsUsersSorted[0, 0] = true;
                HowIsAwardsSorted[0, 0] = true;
            }
            else if (index == 1 && sortOrder == SortOrder.Desc)
            {
                HowIsUsersSorted[0, 1] = true;
                HowIsAwardsSorted[0, 1] = true;
            }
            else if (index == 2 && sortOrder == SortOrder.Asc)
            {
                HowIsUsersSorted[1, 0] = true;
                HowIsAwardsSorted[1, 0] = true;
            }
            else if (index == 2 && sortOrder == SortOrder.Desc)
            {
                HowIsUsersSorted[1, 1] = true;
                HowIsAwardsSorted[1, 1] = true;
            }
            if (index == 3 && sortOrder == SortOrder.Asc)
            {
                HowIsUsersSorted[2, 0] = true;
            }
            else if (index == 3 && sortOrder == SortOrder.Desc)
            {
                HowIsUsersSorted[2, 1] = true;
            }
            else if (index == 4 && sortOrder == SortOrder.Asc)
            {
                HowIsUsersSorted[3, 0] = true;
            }
            else if (index == 4 && sortOrder == SortOrder.Desc)
            {
                HowIsUsersSorted[3, 1] = true;
            }
            else if (index == 5 && sortOrder == SortOrder.Asc)
            {
                HowIsUsersSorted[4, 0] = true;
            }
            else if (index == 5 && sortOrder == SortOrder.Desc)
            {
                HowIsUsersSorted[4, 1] = true;
            }

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

            var list = (List<Award>)ctlAwardsGrid.DataSource;


            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.AddAward(new Award(form.Title, form.Description));
            }
            ctlAwardsGrid.DataSource = null;
            list = memory.GetAllAwards();
            ctlAwardsGrid.DataSource = GetListWithLastSort(list);
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void EditAward()
        {
            DataGridViewRow selected = new DataGridViewRow();

            foreach (DataGridViewRow row in ctlAwardsGrid.Rows)
            {
                if (row.Selected)
                {
                    selected = row;
                    break;
                }
            }
            var listOfAwards = memory.GetAllAwards();
            int awardId = (int)selected.Cells[0].Value;
            var selectedAward = listOfAwards.FirstOrDefault(a => a.Id == awardId);
            if (selectedAward != null)
            {
                var form = new AddEditAwardForm(selectedAward);
                var list = (List<UserViewModel>)ctlUsersGrid.DataSource;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var us = memory.GetAllAwards().IndexOf(selectedAward);
                    memory.EditAward(form.Award, us);
                }
                ctlUsersGrid.DataSource = null;
                list = logic.GetUsersForUI(memory.GetAllUsers(), memory);
                ctlUsersGrid.DataSource = GetListWithLastSort(list);
                ctlUsersGrid.Columns[0].Visible = false;
            }
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
            userList = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            awardList = memory.GetAllAwards();
            ctlUsersGrid.DataSource = GetListWithLastSort(userList);
            ctlAwardsGrid.DataSource = GetListWithLastSort(awardList);
            ctlAwardsGrid.Columns[0].Visible = false;
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void AddUser()
        {
            var form = new AddEditUserForm(memory);

            var list = (List<UserViewModel>)ctlUsersGrid.DataSource;

            if (form.ShowDialog() == DialogResult.OK)
            {
                memory.AddUser(form.NewUser);
            }
            ctlUsersGrid.DataSource = null;
            list = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlUsersGrid.DataSource = GetListWithLastSort(list);
            //ctlUsersGrid.Columns[0].Visible = false;
        }

        private void EditUser()
        {
            DataGridViewRow selected = new DataGridViewRow();

            foreach(DataGridViewRow row in ctlUsersGrid.Rows)
            {
                if (row.Selected)
                {
                    selected = row;
                    break;
                }
            }
            var users = memory.GetAllUsers();
            int userId = (int)selected.Cells[0].Value;
            var selectedUser = users.FirstOrDefault(u => u.Id == userId);
            if (selectedUser != null)
            {
                var form = new AddEditUserForm(selectedUser, memory);
                var list = (List<UserViewModel>)ctlUsersGrid.DataSource;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var us = memory.GetAllUsers().IndexOf(selectedUser);
                    memory.EditUser(form.NewUser, us);
                }
                ctlUsersGrid.DataSource = null;
                list = logic.GetUsersForUI(memory.GetAllUsers(), memory);
                ctlUsersGrid.DataSource = GetListWithLastSort(list);
                //ctlUsersGrid.Columns[0].Visible = false;
            }
        }

        private void RemoveUser()
        {
            bool deleted = false;
            var list = (List<UserViewModel>)ctlUsersGrid.DataSource;
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
            list = logic.GetUsersForUI(memory.GetAllUsers(), memory);
            ctlUsersGrid.DataSource = GetListWithLastSort(list);
            //ctlUsersGrid.Columns[0].Visible = false;
        }

        private void ctlAwardsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var list = (List<Award>)ctlAwardsGrid.DataSource;

            ctlAwardsGrid.DataSource = null;

            int index = e.ColumnIndex;

            if (index == 1)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlAwardsGrid.DataSource = list.OrderBy(u => u.Title).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    InitArray(index, Sort);
                    ctlAwardsGrid.DataSource = list.OrderByDescending(u => u.Title).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else if (index == 2)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitArray(index, Sort);
                    ctlAwardsGrid.DataSource = list.OrderBy(u => u.Description).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    InitArray(index, Sort);
                    ctlAwardsGrid.DataSource = list.OrderByDescending(u => u.Description).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else
            {
                ctlAwardsGrid.DataSource = list;
            }
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private List<UserViewModel> GetListWithLastSort(List<UserViewModel> list)
        {
            if (HowIsUsersSorted[0, 0])
            {
                return list.OrderBy(u => u.FirstName).ToList();
            }
            else if (HowIsUsersSorted[0, 1])
            {
                return list.OrderByDescending(u => u.FirstName).ToList();
            }
            else if (HowIsUsersSorted[1, 0])
            {
                return list.OrderBy(u => u.LastName).ToList();
            }
            else if (HowIsUsersSorted[1, 1])
            {
                return list.OrderByDescending(u => u.LastName).ToList();
            }
            else if (HowIsUsersSorted[2, 0])
            {
                return list.OrderBy(u => u.Birthdate).ToList();
            }
            else if (HowIsUsersSorted[2, 1])
            {
                return list.OrderByDescending(u => u.Birthdate).ToList();
            }
            else if (HowIsUsersSorted[3, 0])
            {
                return list.OrderBy(u => u.Awards).ToList();
            }
            else if (HowIsUsersSorted[3, 1])
            {
                return list.OrderByDescending(u => u.Awards).ToList();
            }
            else if (HowIsUsersSorted[4, 0])
            {
                return list;
            }

            return null;
        }

        private List<Award> GetListWithLastSort(List<Award> list)
        {
            if (HowIsAwardsSorted[0, 0])
            {
                return list.OrderBy(u => u.Title).ToList();
            }
            else if (HowIsAwardsSorted[0, 1])
            {
                return list.OrderByDescending(u => u.Title).ToList();
            }
            else if (HowIsAwardsSorted[1, 0])
            {
                return list.OrderBy(u => u.Description).ToList();
            }
            else if (HowIsAwardsSorted[1, 1])
            {
                return list.OrderByDescending(u => u.Description).ToList();
            }
            
            return null;
        }
    }
}
