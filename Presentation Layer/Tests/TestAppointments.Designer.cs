namespace Presentation_Layer
{
    partial class TestAppointments
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvTestAppointmentsList = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnAddTestAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbTestTypeImag = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new Presentation_Layer.ctrlLocalDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmentsList)).BeginInit();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImag)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 68);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(823, 46);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Vision Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTestAppointmentsList
            // 
            this.dgvTestAppointmentsList.AllowUserToAddRows = false;
            this.dgvTestAppointmentsList.AllowUserToDeleteRows = false;
            this.dgvTestAppointmentsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestAppointmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointmentsList.ContextMenuStrip = this.ContextMenuStrip;
            this.dgvTestAppointmentsList.Location = new System.Drawing.Point(17, 617);
            this.dgvTestAppointmentsList.Name = "dgvTestAppointmentsList";
            this.dgvTestAppointmentsList.ReadOnly = true;
            this.dgvTestAppointmentsList.RowHeadersWidth = 51;
            this.dgvTestAppointmentsList.RowTemplate.Height = 24;
            this.dgvTestAppointmentsList.Size = new System.Drawing.Size(818, 167);
            this.dgvTestAppointmentsList.TabIndex = 3;
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiTakeTest});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(227, 108);
            this.ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Opening);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::Presentation_Layer.Properties.Resources.edit_32;
            this.tsmiEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(226, 38);
            this.tsmiEdit.Text = "Edit";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiTakeTest
            // 
            this.tsmiTakeTest.Image = global::Presentation_Layer.Properties.Resources.Test_32;
            this.tsmiTakeTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiTakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiTakeTest.Name = "tsmiTakeTest";
            this.tsmiTakeTest.Size = new System.Drawing.Size(226, 38);
            this.tsmiTakeTest.Text = "Take Test";
            this.tsmiTakeTest.Click += new System.EventHandler(this.tsmiTakeTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 575);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Appointments:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 807);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Records:   ";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(131, 807);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(40, 22);
            this.lblRecordsCount.TabIndex = 7;
            this.lblRecordsCount.Text = "???";
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTestAppointment.Image = global::Presentation_Layer.Properties.Resources.AddAppointment_32;
            this.btnAddTestAppointment.Location = new System.Drawing.Point(759, 566);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(76, 45);
            this.btnAddTestAppointment.TabIndex = 5;
            this.btnAddTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddTestAppointment.Click += new System.EventHandler(this.btnAddTestAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(654, 790);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(181, 48);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbTestTypeImag
            // 
            this.pbTestTypeImag.Image = global::Presentation_Layer.Properties.Resources.Vision_512;
            this.pbTestTypeImag.Location = new System.Drawing.Point(385, 0);
            this.pbTestTypeImag.Name = "pbTestTypeImag";
            this.pbTestTypeImag.Size = new System.Drawing.Size(115, 65);
            this.pbTestTypeImag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImag.TabIndex = 1;
            this.pbTestTypeImag.TabStop = false;
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.EnableShowLicenseInfoLink = false;
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 117);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(832, 455);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 9;
            // 
            // TestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 844);
            this.Controls.Add(this.btnAddTestAppointment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTestAppointmentsList);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbTestTypeImag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestAppointments";
            this.Text = "TestAppointments";
            this.Load += new System.EventHandler(this.TestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmentsList)).EndInit();
            this.ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.PictureBox pbTestTypeImag;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvTestAppointmentsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTestAppointment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTakeTest;
    }
}