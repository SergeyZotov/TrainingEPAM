using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersAndAwards.DAL;

namespace UsersAndAwards.PL.WinForms
{
    public partial class DeleteAwardForm : Form
    {
        public string Title { get; set; }
        IStorage memory = new InMemoryStorage();

        public DeleteAwardForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (MessageBox.Show("Are you sure you want to remove this user?", "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }

            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void txtTitle_Validated(object sender, EventArgs e)
        {
            Title = txtTitle.Text;
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            string title = txtTitle.Text;

            bool valid = !string.IsNullOrWhiteSpace(title);

            if (valid)
            {
                ctlErrorProvider.SetError(txtTitle, string.Empty);
                e.Cancel = false;
            }
            else
            {
                ctlErrorProvider.SetError(txtTitle, "Пустое поле");
                e.Cancel = true;
            }
        }
    }
}
