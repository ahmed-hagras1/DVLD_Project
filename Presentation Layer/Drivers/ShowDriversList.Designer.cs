namespace Presentation_Layer
{
    partial class ShowDriversList
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterItems = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.dgvDriversList = new System.Windows.Forms.DataGridView();
            this.cmsDrivers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowPersonLicensesHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDriversCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversList)).BeginInit();
            this.cmsDrivers.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(583, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Drivers";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Driver_Main;
            this.pictureBox1.Location = new System.Drawing.Point(461, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterItems
            // 
            this.cbFilterItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterItems.FormattingEnabled = true;
            this.cbFilterItems.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No",
            "Full Name"});
            this.cbFilterItems.Location = new System.Drawing.Point(124, 256);
            this.cbFilterItems.Name = "cbFilterItems";
            this.cbFilterItems.Size = new System.Drawing.Size(245, 24);
            this.cbFilterItems.TabIndex = 3;
            this.cbFilterItems.SelectedIndexChanged += new System.EventHandler(this.cbFilterItems_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(390, 258);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(245, 22);
            this.txtFilterValue.TabIndex = 4;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // dgvDriversList
            // 
            this.dgvDriversList.AllowUserToAddRows = false;
            this.dgvDriversList.AllowUserToDeleteRows = false;
            this.dgvDriversList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDriversList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriversList.ContextMenuStrip = this.cmsDrivers;
            this.dgvDriversList.Location = new System.Drawing.Point(12, 298);
            this.dgvDriversList.Name = "dgvDriversList";
            this.dgvDriversList.ReadOnly = true;
            this.dgvDriversList.RowHeadersWidth = 51;
            this.dgvDriversList.RowTemplate.Height = 24;
            this.dgvDriversList.Size = new System.Drawing.Size(1249, 255);
            this.dgvDriversList.TabIndex = 5;
            // 
            // cmsDrivers
            // 
            this.cmsDrivers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDrivers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPersonInfo,
            this.toolStripSeparator2,
            this.tsmiShowPersonLicensesHistory});
            this.cmsDrivers.Name = "cmsDrivers";
            this.cmsDrivers.Size = new System.Drawing.Size(287, 114);
            // 
            // tsmiShowPersonInfo
            // 
            this.tsmiShowPersonInfo.Image = global::Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.tsmiShowPersonInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowPersonInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonInfo.Name = "tsmiShowPersonInfo";
            this.tsmiShowPersonInfo.Size = new System.Drawing.Size(286, 38);
            this.tsmiShowPersonInfo.Text = "Show Person Info";
            this.tsmiShowPersonInfo.Click += new System.EventHandler(this.tsmiShowPersonInfo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(283, 6);
            // 
            // tsmiShowPersonLicensesHistory
            // 
            this.tsmiShowPersonLicensesHistory.Image = global::Presentation_Layer.Properties.Resources.PersonLicenseHistory_32;
            this.tsmiShowPersonLicensesHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowPersonLicensesHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonLicensesHistory.Name = "tsmiShowPersonLicensesHistory";
            this.tsmiShowPersonLicensesHistory.Size = new System.Drawing.Size(286, 38);
            this.tsmiShowPersonLicensesHistory.Text = "Show Person Licenses History";
            this.tsmiShowPersonLicensesHistory.Click += new System.EventHandler(this.tsmiShowPersonLicensesHistory_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1097, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 47);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblDriversCount
            // 
            this.lblDriversCount.AutoSize = true;
            this.lblDriversCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriversCount.Location = new System.Drawing.Point(109, 572);
            this.lblDriversCount.Name = "lblDriversCount";
            this.lblDriversCount.Size = new System.Drawing.Size(26, 18);
            this.lblDriversCount.TabIndex = 35;
            this.lblDriversCount.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "# Records:";
            // 
            // ShowDriversList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 616);
            this.Controls.Add(this.lblDriversCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDriversList);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowDriversList";
            this.Text = "ShowDriversList";
            this.Load += new System.EventHandler(this.ShowDriversList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversList)).EndInit();
            this.cmsDrivers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterItems;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvDriversList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDriversCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicensesHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}