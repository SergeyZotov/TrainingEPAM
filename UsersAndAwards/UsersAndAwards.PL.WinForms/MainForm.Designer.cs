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
            this.ctlTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctlUsersGrid = new System.Windows.Forms.DataGridView();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEditAward = new System.Windows.Forms.Button();
            this.btnDeleteAward = new System.Windows.Forms.Button();
            this.btnAddAward = new System.Windows.Forms.Button();
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
            this.ctlTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlUsersGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlAwardsGrid)).BeginInit();
            this.ctlMainMenu.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.btnRemoveUser);
            this.tabPage1.Controls.Add(this.btnEditUser);
            this.tabPage1.Controls.Add(this.btnAddUser);
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
            this.ctlUsersGrid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ctlUsersGrid.Location = new System.Drawing.Point(6, 6);
            this.ctlUsersGrid.Name = "ctlUsersGrid";
            this.ctlUsersGrid.Size = new System.Drawing.Size(544, 339);
            this.ctlUsersGrid.TabIndex = 4;
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(314, 380);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(94, 40);
            this.btnRemoveUser.TabIndex = 6;
            this.btnRemoveUser.Text = "Remove user";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(214, 380);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(94, 40);
            this.btnEditUser.TabIndex = 7;
            this.btnEditUser.Text = "Edit user";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(414, 380);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(94, 40);
            this.btnAddUser.TabIndex = 5;
            this.btnAddUser.Text = "Add user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEditAward);
            this.tabPage2.Controls.Add(this.btnDeleteAward);
            this.tabPage2.Controls.Add(this.btnAddAward);
            this.tabPage2.Controls.Add(this.ctlAwardsGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(556, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEditAward
            // 
            this.btnEditAward.Location = new System.Drawing.Point(223, 376);
            this.btnEditAward.Name = "btnEditAward";
            this.btnEditAward.Size = new System.Drawing.Size(94, 40);
            this.btnEditAward.TabIndex = 8;
            this.btnEditAward.Text = "Edit award";
            this.btnEditAward.UseVisualStyleBackColor = true;
            this.btnEditAward.Click += new System.EventHandler(this.btnEditAward_Click);
            // 
            // btnDeleteAward
            // 
            this.btnDeleteAward.Location = new System.Drawing.Point(323, 376);
            this.btnDeleteAward.Name = "btnDeleteAward";
            this.btnDeleteAward.Size = new System.Drawing.Size(94, 40);
            this.btnDeleteAward.TabIndex = 7;
            this.btnDeleteAward.Text = "Remove award";
            this.btnDeleteAward.UseVisualStyleBackColor = true;
            this.btnDeleteAward.Click += new System.EventHandler(this.btnDeleteAward_Click);
            // 
            // btnAddAward
            // 
            this.btnAddAward.Location = new System.Drawing.Point(423, 376);
            this.btnAddAward.Name = "btnAddAward";
            this.btnAddAward.Size = new System.Drawing.Size(94, 40);
            this.btnAddAward.TabIndex = 6;
            this.btnAddAward.Text = "Add award";
            this.btnAddAward.UseVisualStyleBackColor = true;
            this.btnAddAward.Click += new System.EventHandler(this.btnAddAward_Click);
            // 
            // ctlAwardsGrid
            // 
            this.ctlAwardsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctlAwardsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlAwardsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ctlAwardsGrid.Location = new System.Drawing.Point(6, 6);
            this.ctlAwardsGrid.Name = "ctlAwardsGrid";
            this.ctlAwardsGrid.Size = new System.Drawing.Size(544, 339);
            this.ctlAwardsGrid.TabIndex = 5;
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
            this.btnExit.Size = new System.Drawing.Size(180, 22);
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
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editUserToolStripMenuItem.Text = "Edit User";
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeUserToolStripMenuItem.Text = "Remove User";
            // 
            // addAwardToolStripMenuItem
            // 
            this.addAwardToolStripMenuItem.Name = "addAwardToolStripMenuItem";
            this.addAwardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAwardToolStripMenuItem.Text = "Add Award";
            // 
            // editAwardToolStripMenuItem
            // 
            this.editAwardToolStripMenuItem.Name = "editAwardToolStripMenuItem";
            this.editAwardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editAwardToolStripMenuItem.Text = "Edit Award";
            // 
            // removeAwardToolStripMenuItem
            // 
            this.removeAwardToolStripMenuItem.Name = "removeAwardToolStripMenuItem";
            this.removeAwardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeAwardToolStripMenuItem.Text = "Remove Award";
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
            this.Text = "Users and awards";
            this.ctlTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlUsersGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlAwardsGrid)).EndInit();
            this.ctlMainMenu.ResumeLayout(false);
            this.ctlMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl ctlTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ctlUsersGrid;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnAddAward;
        private System.Windows.Forms.DataGridView ctlAwardsGrid;
        private System.Windows.Forms.Button btnDeleteAward;
        private System.Windows.Forms.Button btnEditAward;
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
    }
}

