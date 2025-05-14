namespace Presentation_Layer
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.lblLocalLicensesCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tpInernationalLicenses = new System.Windows.Forms.TabPage();
            this.lblInternationalLicensesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmInternaitonalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowInternaitonalLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.tpInernationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.cmLocalLicenses.SuspendLayout();
            this.cmInternaitonalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tpLocalLicenses);
            this.tabControl1.Controls.Add(this.tpInernationalLicenses);
            this.tabControl1.Location = new System.Drawing.Point(18, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1129, 260);
            this.tabControl1.TabIndex = 0;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpLocalLicenses.Controls.Add(this.lblLocalLicensesCount);
            this.tpLocalLicenses.Controls.Add(this.label3);
            this.tpLocalLicenses.Controls.Add(this.label1);
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicenses);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 30);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(1121, 226);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local";
            this.tpLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // lblLocalLicensesCount
            // 
            this.lblLocalLicensesCount.AutoSize = true;
            this.lblLocalLicensesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesCount.Location = new System.Drawing.Point(103, 183);
            this.lblLocalLicensesCount.Name = "lblLocalLicensesCount";
            this.lblLocalLicensesCount.Size = new System.Drawing.Size(26, 18);
            this.lblLocalLicensesCount.TabIndex = 6;
            this.lblLocalLicensesCount.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenses History:";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.cmLocalLicenses;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(16, 45);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.RowHeadersWidth = 51;
            this.dgvLocalLicenses.RowTemplate.Height = 24;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1097, 118);
            this.dgvLocalLicenses.TabIndex = 0;
            // 
            // tpInernationalLicenses
            // 
            this.tpInernationalLicenses.Controls.Add(this.lblInternationalLicensesCount);
            this.tpInernationalLicenses.Controls.Add(this.label4);
            this.tpInernationalLicenses.Controls.Add(this.label2);
            this.tpInernationalLicenses.Controls.Add(this.dgvInternationalLicenses);
            this.tpInernationalLicenses.Location = new System.Drawing.Point(4, 30);
            this.tpInernationalLicenses.Name = "tpInernationalLicenses";
            this.tpInernationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpInernationalLicenses.Size = new System.Drawing.Size(1121, 226);
            this.tpInernationalLicenses.TabIndex = 1;
            this.tpInernationalLicenses.Text = "Inernational";
            this.tpInernationalLicenses.UseVisualStyleBackColor = true;
            // 
            // lblInternationalLicensesCount
            // 
            this.lblInternationalLicensesCount.AutoSize = true;
            this.lblInternationalLicensesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicensesCount.Location = new System.Drawing.Point(103, 188);
            this.lblInternationalLicensesCount.Name = "lblInternationalLicensesCount";
            this.lblInternationalLicensesCount.Size = new System.Drawing.Size(26, 18);
            this.lblInternationalLicensesCount.TabIndex = 5;
            this.lblInternationalLicensesCount.Text = "??";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "# Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "International Licenses History:";
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmInternaitonalLicenses;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(18, 45);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 24;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1097, 123);
            this.dgvInternationalLicenses.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1153, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // cmLocalLicenses
            // 
            this.cmLocalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowLicenseInfo});
            this.cmLocalLicenses.Name = "cmLocalLicenses";
            this.cmLocalLicenses.Size = new System.Drawing.Size(183, 42);
            // 
            // tsmiShowLicenseInfo
            // 
            this.tsmiShowLicenseInfo.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.tsmiShowLicenseInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowLicenseInfo.Name = "tsmiShowLicenseInfo";
            this.tsmiShowLicenseInfo.Size = new System.Drawing.Size(182, 38);
            this.tsmiShowLicenseInfo.Text = "Show License";
            this.tsmiShowLicenseInfo.Click += new System.EventHandler(this.tsmiShowLicenseInfo_Click);
            // 
            // cmInternaitonalLicenses
            // 
            this.cmInternaitonalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmInternaitonalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowInternaitonalLicenseInfo});
            this.cmInternaitonalLicenses.Name = "cmInternaitonalLicenses";
            this.cmInternaitonalLicenses.Size = new System.Drawing.Size(301, 42);
            // 
            // tsmiShowInternaitonalLicenseInfo
            // 
            this.tsmiShowInternaitonalLicenseInfo.Image = global::Presentation_Layer.Properties.Resources.International_32;
            this.tsmiShowInternaitonalLicenseInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowInternaitonalLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowInternaitonalLicenseInfo.Name = "tsmiShowInternaitonalLicenseInfo";
            this.tsmiShowInternaitonalLicenseInfo.Size = new System.Drawing.Size(300, 38);
            this.tsmiShowInternaitonalLicenseInfo.Text = "Show Internaitonal License Info";
            this.tsmiShowInternaitonalLicenseInfo.Click += new System.EventHandler(this.tsmiShowInternaitonalLicenseInfo_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1170, 317);
            this.Load += new System.EventHandler(this.ctrlDriverLicenses_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.tpInernationalLicenses.ResumeLayout(false);
            this.tpInernationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.cmLocalLicenses.ResumeLayout(false);
            this.cmInternaitonalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.TabPage tpInernationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternationalLicensesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLocalLicensesCount;
        private System.Windows.Forms.ContextMenuStrip cmLocalLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicenseInfo;
        private System.Windows.Forms.ContextMenuStrip cmInternaitonalLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowInternaitonalLicenseInfo;
    }
}
