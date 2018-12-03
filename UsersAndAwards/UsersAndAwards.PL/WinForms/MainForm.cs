using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UsersAndAwards.BLL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class MainForm : Form
    {
        Logic logic;

        enum SortOrder
        {
            Asc,
            Desc
        };

        // [0,] - fname, [1,] - lname, [2,] - bdate, [3,] - age, [4,] - awards, [5,] - default
        // [,0] - Asc, [,1] - Des
        private bool[,] HowIsUsersSorted = new bool[6, 2];

        // [0,] - title, [1,] - description, [2,] - default
        private bool[,] HowIsAwardsSorted = new bool[3, 2]; 

        SortOrder Sort = SortOrder.Asc;

        public MainForm()
        {


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

            // Есть ли смысл тут сделать статичный метод на получение UserViewModel?
            logic = new Logic();

            ctlUsersGrid.AutoGenerateColumns = false;
            ctlAwardsGrid.AutoGenerateColumns = false;

            //var usersFromStorage = memory.GetAllUsers();//.Select(u => new UserViewModel(u)).ToList();
            var usersViewModel =  logic.GetUsersForUI(); 
            var awardsFromStorage = logic.GetAllAwards();

            ctlUsersGrid.DataSource = usersViewModel;
            ctlAwardsGrid.DataSource = awardsFromStorage;

            ctlAwardsGrid.Columns[0].Visible = false;
            ctlUsersGrid.Columns[0].Visible = false;

        }

        private void ctlUsersGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var listOfUsers = (List<UserViewModel>)ctlUsersGrid.DataSource;
            ctlUsersGrid.DataSource = null;

            int columnIndex = e.ColumnIndex;

            if (columnIndex == 1)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderBy(u => u.FirstName).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderByDescending(u => u.FirstName).ToList();
                    Sort = SortOrder.Asc;

                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderBy(u => u.LastName).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderByDescending(u => u.LastName).ToList();
                    Sort = SortOrder.Asc;

                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderBy(u => u.Birthdate).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderByDescending(u => u.Birthdate).ToList();
                    Sort = SortOrder.Asc;

                }
            }
            else if (e.ColumnIndex == 4)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderBy(u => u.Age).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderByDescending(u => u.Age).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderBy(u => u.Awards).ToList();
                    Sort = SortOrder.Desc;

                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlUsersGrid.DataSource = listOfUsers.OrderByDescending(u => u.Awards).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else
            {
                ctlUsersGrid.DataSource = listOfUsers;
            }

            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void InitializationOfSortingArray(int index, SortOrder sortOrder)
        {
            HowIsUsersSorted = new bool[6, 2];
            HowIsAwardsSorted = new bool[3, 2];

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
            else
            {
                HowIsUsersSorted[5, 0] = true;
                HowIsAwardsSorted[2, 0] = true;
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
            var addEditAwardForm = new AddEditAwardForm();
            var listOfAwards = (List<Award>)ctlAwardsGrid.DataSource;

            if (addEditAwardForm.ShowDialog() == DialogResult.OK)
            {
                logic.AddAward(new Award(addEditAwardForm.Title, addEditAwardForm.Description));
            }

            ctlAwardsGrid.DataSource = null;
            listOfAwards = logic.GetAllAwards();
            ctlAwardsGrid.DataSource = GetListWithLastSort(listOfAwards);
            ctlAwardsGrid.Columns[0].Visible = false;
        }

        private void EditAward()
        {
            DataGridViewRow selectedRow = new DataGridViewRow();

            foreach (DataGridViewRow row in ctlAwardsGrid.Rows)
            {
                if (row.Selected)
                {
                    selectedRow = row;
                    break;
                }
            }

            var listOfAwards = logic.GetAllAwards();
            int awardId = (int)selectedRow.Cells[0].Value;
            var selectedAward = listOfAwards.FirstOrDefault(a => a.AwardId == awardId);
            if (selectedAward != null)
            {
                var addEditAwardForm = new AddEditAwardForm(selectedAward);
                var listOfUsersViewModel = (List<UserViewModel>)ctlUsersGrid.DataSource;

                if (addEditAwardForm.ShowDialog() == DialogResult.OK)
                {
                    var indexOfSelectedAward = listOfAwards.IndexOf(selectedAward);
                    logic.EditAward(addEditAwardForm.Award, indexOfSelectedAward);
                }
                ctlUsersGrid.DataSource = null;
                ctlAwardsGrid.DataSource = null;
                listOfUsersViewModel = logic.GetUsersForUI();
                listOfAwards = logic.GetAllAwards();
                ctlAwardsGrid.DataSource = GetListWithLastSort(listOfAwards);
                ctlUsersGrid.DataSource = GetListWithLastSort(listOfUsersViewModel);
                ctlUsersGrid.Columns[0].Visible = false;
                ctlAwardsGrid.Columns[0].Visible = false;
            }
        }

        private void RemoveAward()
        {
            var listOfUsersViewModel = (List<UserViewModel>)ctlUsersGrid.DataSource;
            var listOfAwards = (List<Award>)ctlAwardsGrid.DataSource;
            var awardsFromStorage = logic.GetAllAwards();
            bool isDeleted = false;
            foreach (var award in awardsFromStorage)
            {
                foreach (DataGridViewRow index in ctlAwardsGrid.Rows)
                {
                    if (index.Selected && award.AwardId == (int)index.Cells[0].Value)
                    {
                        if (MessageBox.Show("Are you sure?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK && logic.RemoveAward(award))
                        {
                            isDeleted = true;
                            break;
                        }
                    }
                }

                if (isDeleted)
                {
                    break;
                }
            }

            ctlUsersGrid.DataSource = null;
            ctlAwardsGrid.DataSource = null;
            listOfUsersViewModel = logic.GetUsersForUI();
            listOfAwards = logic.GetAllAwards();
            ctlUsersGrid.DataSource = GetListWithLastSort(listOfUsersViewModel);
            ctlAwardsGrid.DataSource = GetListWithLastSort(listOfAwards);
            ctlAwardsGrid.Columns[0].Visible = false;
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void AddUser()
        {
            var addEditUserForm = new AddEditUserForm(logic);

            var listOfUsersViewModel = (List<UserViewModel>)ctlUsersGrid.DataSource;

            if (addEditUserForm.ShowDialog() == DialogResult.OK)
            {
                logic.AddUser(addEditUserForm.NewUser);
            }
            ctlUsersGrid.DataSource = null;
            listOfUsersViewModel = logic.GetUsersForUI();
            ctlUsersGrid.DataSource = GetListWithLastSort(listOfUsersViewModel);
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void EditUser()
        {
            DataGridViewRow selectedRow = new DataGridViewRow();

            foreach(DataGridViewRow row in ctlUsersGrid.Rows)
            {
                if (row.Selected)
                {
                    selectedRow = row;
                    break;
                }
            }
            var users = logic.GetAllUsers();
            int userId = (int)selectedRow.Cells[0].Value;
            var selectedUser = users.FirstOrDefault(u => u.Id == userId);
            if (selectedUser != null)
            {
                var addEditUserForm = new AddEditUserForm(selectedUser, logic);
                var listOfUsersViewModel = (List<UserViewModel>)ctlUsersGrid.DataSource;

                if (addEditUserForm.ShowDialog() == DialogResult.OK)
                {
                    var indexOfSelectedUser = users.IndexOf(selectedUser);
                    logic.EditUser(addEditUserForm.NewUser, indexOfSelectedUser);
                }

                ctlUsersGrid.DataSource = null;
                listOfUsersViewModel = logic.GetUsersForUI();
                ctlUsersGrid.DataSource = GetListWithLastSort(listOfUsersViewModel);
                ctlUsersGrid.Columns[0].Visible = false;
            }
        }

        private void RemoveUser()
        {
            bool isDeleted = false;
            var listOfUsersViewModel = (List<UserViewModel>)ctlUsersGrid.DataSource;
            var usersFromStorage = logic.GetAllUsers();
            foreach (var user in usersFromStorage)
            {
                foreach (DataGridViewRow index in ctlUsersGrid.Rows)
                {
                    if (index.Selected && user.Id == (int)index.Cells[0].Value)
                    {
                        if (logic.RemoveUser(user) && MessageBox.Show("Are you sure?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            isDeleted = true;
                            break;
                        }
                    }
                }

                if (isDeleted)
                {
                    break;
                }
            }
            ctlUsersGrid.DataSource = null;
            listOfUsersViewModel = logic.GetUsersForUI();
            ctlUsersGrid.DataSource = GetListWithLastSort(listOfUsersViewModel);
            ctlUsersGrid.Columns[0].Visible = false;
        }

        private void ctlAwardsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var listOfAwards = (List<Award>)ctlAwardsGrid.DataSource;
            ctlAwardsGrid.DataSource = null;
            int columnIndex = e.ColumnIndex;

            if (columnIndex == 1)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlAwardsGrid.DataSource = listOfAwards.OrderBy(u => u.Title).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlAwardsGrid.DataSource = listOfAwards.OrderByDescending(u => u.Title).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else if (columnIndex == 2)
            {
                if (Sort == SortOrder.Asc)
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlAwardsGrid.DataSource = listOfAwards.OrderBy(u => u.Description).ToList();
                    Sort = SortOrder.Desc;
                }
                else
                {
                    InitializationOfSortingArray(columnIndex, Sort);
                    ctlAwardsGrid.DataSource = listOfAwards.OrderByDescending(u => u.Description).ToList();
                    Sort = SortOrder.Asc;
                }
            }
            else
            {
                ctlAwardsGrid.DataSource = listOfAwards;
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
                return list.OrderBy(u => u.Age).ToList();
            }
            else if (HowIsUsersSorted[3, 1])
            {
                return list.OrderByDescending(u => u.Age).ToList();
            }
            else if (HowIsUsersSorted[4, 0])
            {
                return list.OrderBy(u => u.Awards).ToList();
            }
            else if (HowIsUsersSorted[4, 1])
            {
                return list.OrderByDescending(u => u.Awards).ToList();
            }

            return list;
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

            return list;
        }
    }
}
