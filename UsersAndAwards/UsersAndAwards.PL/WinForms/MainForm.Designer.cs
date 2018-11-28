namespace UsersAndAwards.PL.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctlTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctlUsersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Awards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctlAwardsGrid = new System.Windows.Forms.DataGridView();
            this.ctlMainMenu = new System.Windows.Forms.MenuStrip();
            this.ctlMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlUserStripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctlAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlRemoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlAwardStripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctlAddAward = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlEditAward = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlRemoveAward = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlUsersGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlAwardsGrid)).BeginInit();
            this.ctlMainMenu.SuspendLayout();
            this.ctlUserStripMenu.SuspendLayout();
            this.ctlAwardStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlTabs
            // 
            this.ctlTabs.Controls.Add(this.tabPage1);
            this.ctlTabs.Controls.Add(this.tabPage2);
            this.ctlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlTabs.Location = new System.Drawing.Point(0, 24);
            this.ctlTabs.Name = "ctlTabs";
            this.ctlTabs.SelectedIndex = 0;
            this.ctlTabs.Size = new System.Drawing.Size(564, 426);
            this.ctlTabs.TabIndex = 4;
            this.ctlTabs.SelectedIndexChanged += new System.EventHandler(this.ctlTabs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctlUsersGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctlUsersGrid
            // 
            this.ctlUsersGrid.AllowUserToResizeColumns = false;
            this.ctlUsersGrid.AllowUserToResizeRows = false;
            this.ctlUsersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctlUsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlUsersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FirstName,
            this.LastName,
            this.Birthdate,
            this.Age,
            this.Awards});
            this.ctlUsersGrid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ctlUsersGrid.Location = new System.Drawing.Point(6, 6);
            this.ctlUsersGrid.Name = "ctlUsersGrid";
            this.ctlUsersGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ctlUsersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlUsersGrid.Size = new System.Drawing.Size(544, 388);
            this.ctlUsersGrid.TabIndex = 4;
            this.ctlUsersGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ctlUsersGrid_ColumnHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Birthdate
            // 
            this.Birthdate.DataPropertyName = "Birthdate";
            this.Birthdate.HeaderText = "Birthdate";
            this.Birthdate.Name = "Birthdate";
            this.Birthdate.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Awards
            // 
            this.Awards.DataPropertyName = "Awards";
            this.Awards.HeaderText = "Awards";
            this.Awards.Name = "Awards";
            this.Awards.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctlAwardsGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctlAwardsGrid
            // 
            this.ctlAwardsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctlAwardsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlAwardsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ctlAwardsGrid.Location = new System.Drawing.Point(6, 6);
            this.ctlAwardsGrid.Name = "ctlAwardsGrid";
            this.ctlAwardsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlAwardsGrid.Size = new System.Drawing.Size(544, 388);
            this.ctlAwardsGrid.TabIndex = 5;
            this.ctlAwardsGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ctlAwardsGrid_ColumnHeaderMouseClick);
            // 
            // ctlMainMenu
            // 
            this.ctlMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlMenuFile,
            this.ctlMenuEdit});
            this.ctlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ctlMainMenu.Name = "ctlMainMenu";
            this.ctlMainMenu.Size = new System.Drawing.Size(564, 24);
            this.ctlMainMenu.TabIndex = 5;
            this.ctlMainMenu.Text = "menuStrip1";
            // 
            // ctlMenuFile
            // 
            this.ctlMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit});
            this.ctlMenuFile.Name = "ctlMenuFile";
            this.ctlMenuFile.Size = new System.Drawing.Size(37, 20);
            this.ctlMenuFile.Text = "File";
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ctlMenuEdit
            // 
            this.ctlMenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.editUserToolStripMenuItem,
            this.removeUserToolStripMenuItem,
            this.addAwardToolStripMenuItem,
            this.editAwardToolStripMenuItem,
            this.removeAwardToolStripMenuItem});
            this.ctlMenuEdit.Name = "ctlMenuEdit";
            this.ctlMenuEdit.Size = new System.Drawing.Size(39, 20);
            this.ctlMenuEdit.Text = "Edit";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editUserToolStripMenuItem.Text = "Edit User";
            this.editUserToolStripMenuItem.Click += new System.EventHandler(this.editUserToolStripMenuItem_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeUserToolStripMenuItem.Text = "Remove User";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
            // 
            // addAwardToolStripMenuItem
            // 
            this.addAwardToolStripMenuItem.Name = "addAwardToolStripMenuItem";
            this.addAwardToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addAwardToolStripMenuItem.Text = "Add Award";
            this.addAwardToolStripMenuItem.Click += new System.EventHandler(this.addAwardToolStripMenuItem_Click);
            // 
            // editAwardToolStripMenuItem
            // 
            this.editAwardToolStripMenuItem.Name = "editAwardToolStripMenuItem";
            this.editAwardToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editAwardToolStripMenuItem.Text = "Edit Award";
            this.editAwardToolStripMenuItem.Click += new System.EventHandler(this.editAwardToolStripMenuItem_Click);
            // 
            // removeAwardToolStripMenuItem
            // 
            this.removeAwardToolStripMenuItem.Name = "removeAwardToolStripMenuItem";
            this.removeAwardToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeAwardToolStripMenuItem.Text = "Remove Award";
            this.removeAwardToolStripMenuItem.Click += new System.EventHandler(this.removeAwardToolStripMenuItem_Click);
            // 
            // ctlUserStripMenu
            // 
            this.ctlUserStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlAddUser,
            this.ctlEditUser,
            this.ctlRemoveUser});
            this.ctlUserStripMenu.Name = "ctlUserStripMenu";
            this.ctlUserStripMenu.Size = new System.Drawing.Size(144, 70);
            // 
            // ctlAddUser
            // 
            this.ctlAddUser.Name = "ctlAddUser";
            this.ctlAddUser.Size = new System.Drawing.Size(143, 22);
            this.ctlAddUser.Text = "Add User";
            this.ctlAddUser.Click += new System.EventHandler(this.ctlAddUser_Click);
            // 
            // ctlEditUser
            // 
            this.ctlEditUser.Name = "ctlEditUser";
            this.ctlEditUser.Size = new System.Drawing.Size(143, 22);
            this.ctlEditUser.Text = "Edit User";
            this.ctlEditUser.Click += new System.EventHandler(this.ctlEditUser_Click);
            // 
            // ctlRemoveUser
            // 
            this.ctlRemoveUser.Name = "ctlRemoveUser";
            this.ctlRemoveUser.Size = new System.Drawing.Size(143, 22);
            this.ctlRemoveUser.Text = "Remove User";
            this.ctlRemoveUser.Click += new System.EventHandler(this.ctlRemoveUser_Click);
            // 
            // ctlAwardStripMenu
            // 
            this.ctlAwardStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlAddAward,
            this.ctlEditAward,
            this.ctlRemoveAward});
            this.ctlAwardStripMenu.Name = "ctlAwardStripMenu";
            this.ctlAwardStripMenu.Size = new System.Drawing.Size(155, 70);
            // 
            // ctlAddAward
            // 
            this.ctlAddAward.Name = "ctlAddAward";
            this.ctlAddAward.Size = new System.Drawing.Size(154, 22);
            this.ctlAddAward.Text = "Add Award";
            this.ctlAddAward.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // ctlEditAward
            // 
            this.ctlEditAward.Name = "ctlEditAward";
            this.ctlEditAward.Size = new System.Drawing.Size(154, 22);
            this.ctlEditAward.Text = "Edit Award";
            this.ctlEditAward.Click += new System.EventHandler(this.editAwardToolStripMenuItem1_Click);
            // 
            // ctlRemoveAward
            // 
            this.ctlRemoveAward.Name = "ctlRemoveAward";
            this.ctlRemoveAward.Size = new System.Drawing.Size(154, 22);
            this.ctlRemoveAward.Text = "Remove Award";
            this.ctlRemoveAward.Click += new System.EventHandler(this.removeAwardToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.ctlTabs);
            this.Controls.Add(this.ctlMainMenu);
            this.MainMenuStrip = this.ctlMainMenu;
            this.MaximumSize = new System.Drawing.Size(580, 489);
            this.MinimumSize = new System.Drawing.Size(580, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and awards";
            this.ctlTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlUsersGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlAwardsGrid)).EndInit();
            this.ctlMainMenu.ResumeLayout(false);
            this.ctlMainMenu.PerformLayout();
            this.ctlUserStripMenu.ResumeLayout(false);
            this.ctlAwardStripMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl ctlTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ctlUsersGrid;
        private System.Windows.Forms.DataGridView ctlAwardsGrid;
        private System.Windows.Forms.MenuStrip ctlMainMenu;
        private System.Windows.Forms.ToolStripMenuItem ctlMenuFile;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem ctlMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAwardToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctlUserStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ctlAddUser;
        private System.Windows.Forms.ToolStripMenuItem ctlEditUser;
        private System.Windows.Forms.ToolStripMenuItem ctlRemoveUser;
        private System.Windows.Forms.ContextMenuStrip ctlAwardStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ctlAddAward;
        private System.Windows.Forms.ToolStripMenuItem ctlEditAward;
        private System.Windows.Forms.ToolStripMenuItem ctlRemoveAward;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Awards;
    }
}

