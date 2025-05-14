namespace Presentation_Layer
{
    partial class UsersList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.UsersOperationsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterItems = new System.Windows.Forms.ComboBox();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.cbActiveMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tsmiShowDetailsUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.UsersOperationsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.ContextMenuStrip = this.UsersOperationsMenu;
            this.dgvUsersList.Location = new System.Drawing.Point(12, 388);
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.RowHeadersWidth = 51;
            this.dgvUsersList.RowTemplate.Height = 24;
            this.dgvUsersList.Size = new System.Drawing.Size(1257, 307);
            this.dgvUsersList.TabIndex = 1;
            // 
            // UsersOperationsMenu
            // 
            this.UsersOperationsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.UsersOperationsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowDetailsUser,
            this.toolStripSeparator1,
            this.tsmiAddNewUser,
            this.tsmiEditUser,
            this.tsmiDelete,
            this.tsmiChangePassword,
            this.toolStripSeparator2,
            this.tsmiSendEmail,
            this.tsmiPhoneCall});
            this.UsersOperationsMenu.Name = "contextMenuStrip1";
            this.UsersOperationsMenu.Size = new System.Drawing.Size(215, 226);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(12, 731);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(143, 22);
            this.lblRecordsCount.TabIndex = 3;
            this.lblRecordsCount.Text = "# Records:  ***";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by:";
            // 
            // cbFilterItems
            // 
            this.cbFilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterItems.FormattingEnabled = true;
            this.cbFilterItems.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Username",
            "Person ID",
            "Full name",
            "Is Active"});
            this.cbFilterItems.Location = new System.Drawing.Point(116, 342);
            this.cbFilterItems.Name = "cbFilterItems";
            this.cbFilterItems.Size = new System.Drawing.Size(260, 26);
            this.cbFilterItems.TabIndex = 5;
            this.cbFilterItems.SelectedIndexChanged += new System.EventHandler(this.cbFilterItems_SelectedIndexChanged);
            // 
            // txtFilterText
            // 
            this.txtFilterText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterText.Location = new System.Drawing.Point(416, 342);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(260, 24);
            this.txtFilterText.TabIndex = 7;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            this.txtFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            // 
            // cbActiveMode
            // 
            this.cbActiveMode.AutoCompleteCustomSource.AddRange(new string[] {
            "All",
            "Active",
            "Not Active"});
            this.cbActiveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActiveMode.FormattingEnabled = true;
            this.cbActiveMode.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbActiveMode.Location = new System.Drawing.Point(416, 344);
            this.cbActiveMode.Name = "cbActiveMode";
            this.cbActiveMode.Size = new System.Drawing.Size(186, 24);
            this.cbActiveMode.TabIndex = 8;
            this.cbActiveMode.SelectedIndexChanged += new System.EventHandler(this.cbActiveMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1253, 52);
            this.label2.TabIndex = 9;
            this.label2.Text = "Manage users";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Image = global::Presentation_Layer.Properties.Resources.Add_New_User_72;
            this.btnAddNewUser.Location = new System.Drawing.Point(1153, 288);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(116, 80);
            this.btnAddNewUser.TabIndex = 10;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(449, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(368, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1073, 722);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(196, 43);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tsmiShowDetailsUser
            // 
            this.tsmiShowDetailsUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiShowDetailsUser.Image = global::Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.tsmiShowDetailsUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowDetailsUser.Name = "tsmiShowDetailsUser";
            this.tsmiShowDetailsUser.Size = new System.Drawing.Size(214, 26);
            this.tsmiShowDetailsUser.Text = "Show details";
            this.tsmiShowDetailsUser.Click += new System.EventHandler(this.tsmiShowDetailsUser_Click);
            // 
            // tsmiAddNewUser
            // 
            this.tsmiAddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiAddNewUser.Image = global::Presentation_Layer.Properties.Resources.Add_New_User_32;
            this.tsmiAddNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiAddNewUser.Name = "tsmiAddNewUser";
            this.tsmiAddNewUser.Size = new System.Drawing.Size(214, 26);
            this.tsmiAddNewUser.Text = "Add new user";
            this.tsmiAddNewUser.Click += new System.EventHandler(this.tsmiAddNewUser_Click);
            // 
            // tsmiEditUser
            // 
            this.tsmiEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiEditUser.Image = global::Presentation_Layer.Properties.Resources.edit_32;
            this.tsmiEditUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiEditUser.Name = "tsmiEditUser";
            this.tsmiEditUser.Size = new System.Drawing.Size(214, 26);
            this.tsmiEditUser.Text = "Edit";
            this.tsmiEditUser.Click += new System.EventHandler(this.tsmiEditUser_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiDelete.Image = global::Presentation_Layer.Properties.Resources.Delete_32;
            this.tsmiDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(214, 26);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiChangePassword.Image = global::Presentation_Layer.Properties.Resources.Password_32;
            this.tsmiChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(214, 26);
            this.tsmiChangePassword.Text = "Change password";
            this.tsmiChangePassword.Click += new System.EventHandler(this.tsmiChangePassword_Click);
            // 
            // tsmiSendEmail
            // 
            this.tsmiSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiSendEmail.Image = global::Presentation_Layer.Properties.Resources.send_email_32;
            this.tsmiSendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiSendEmail.Name = "tsmiSendEmail";
            this.tsmiSendEmail.Size = new System.Drawing.Size(214, 26);
            this.tsmiSendEmail.Text = "Send email";
            // 
            // tsmiPhoneCall
            // 
            this.tsmiPhoneCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiPhoneCall.Image = global::Presentation_Layer.Properties.Resources.call_32;
            this.tsmiPhoneCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiPhoneCall.Name = "tsmiPhoneCall";
            this.tsmiPhoneCall.Size = new System.Drawing.Size(214, 26);
            this.tsmiPhoneCall.Text = "Phone call";
            // 
            // UsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 793);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbActiveMode);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvUsersList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UsersList";
            this.Text = "UsersList";
            this.Load += new System.EventHandler(this.UsersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.UsersOperationsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterItems;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.ComboBox cbActiveMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.ContextMenuStrip UsersOperationsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDetailsUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiPhoneCall;
    }
}