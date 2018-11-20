using System;
using UsersAndAwards.DAL;
using System.Windows.Forms;

namespace UsersAndAwards.PL.WinForms
{
    public partial class MainForm : Form
    {
        InMemoryStorage storage;
        public MainForm()
        {
            storage = new InMemoryStorage();
            InitializeComponent();
            TableOfUsersAndAwards.DataSource = storage.GetAllUsers();
        }

    }
}
