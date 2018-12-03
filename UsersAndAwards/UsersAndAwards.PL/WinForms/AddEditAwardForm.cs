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


namespace UsersAndAwards.PL.WinForms
{
    public partial class AddEditAwardForm : Form
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Award Award { get; set; }

        public AddEditAwardForm()
        {
            InitializeComponent();
        }

        public AddEditAwardForm(Award award)
        {
            InitializeComponent();
            txtTitle.Text = award.Title;
            txtDescription.Text = award.Description;
            Award = award;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void txtTitle_Validated(object sender, EventArgs e)
        {
            Title = txtTitle.Text;
            if (Award != null)
                Award.Title = Title;
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Description = txtDescription.Text;
            if (Award != null)
                Award.Description = Description;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            string description = txtDescription.Text;

            bool valid = !string.IsNullOrWhiteSpace(description);

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
