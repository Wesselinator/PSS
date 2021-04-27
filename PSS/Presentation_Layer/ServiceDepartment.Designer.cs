
namespace PSS.Presentation_Layer
{
    partial class ServiceDepartment
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
            this.lstvServiceRequests = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lstvAvailableTechs = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNewTitle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpNewJobDate = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNewDescription = new System.Windows.Forms.TextBox();
            this.rtbNewNotes = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateJob = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbTechDetails = new System.Windows.Forms.RichTextBox();
            this.rtbSALdetails = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReAssignJob = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReAssignTech = new System.Windows.Forms.Button();
            this.txtCurrentTech = new System.Windows.Forms.TextBox();
            this.lblCurrentTech = new System.Windows.Forms.Label();
            this.lstvChangeTech = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rtbNewTechDetails = new System.Windows.Forms.RichTextBox();
            this.dtpChangeJobDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChangeDesc = new System.Windows.Forms.TextBox();
            this.rtbChangeNotes = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstvChangeTitle = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstvJobs = new System.Windows.Forms.ListView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvServiceRequests
            // 
            this.lstvServiceRequests.HideSelection = false;
            this.lstvServiceRequests.Location = new System.Drawing.Point(22, 54);
            this.lstvServiceRequests.Name = "lstvServiceRequests";
            this.lstvServiceRequests.Size = new System.Drawing.Size(290, 109);
            this.lstvServiceRequests.TabIndex = 0;
            this.lstvServiceRequests.UseCompatibleStateImageBehavior = false;
            this.lstvServiceRequests.View = System.Windows.Forms.View.List;
            this.lstvServiceRequests.SelectedIndexChanged += new System.EventHandler(this.lstvServiceRequests_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Active Service Requests";
            // 
            // lstvAvailableTechs
            // 
            this.lstvAvailableTechs.HideSelection = false;
            this.lstvAvailableTechs.Location = new System.Drawing.Point(22, 204);
            this.lstvAvailableTechs.Name = "lstvAvailableTechs";
            this.lstvAvailableTechs.Size = new System.Drawing.Size(290, 93);
            this.lstvAvailableTechs.TabIndex = 2;
            this.lstvAvailableTechs.UseCompatibleStateImageBehavior = false;
            this.lstvAvailableTechs.View = System.Windows.Forms.View.List;
            this.lstvAvailableTechs.SelectedIndexChanged += new System.EventHandler(this.lstvAvailableTechs_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Available Technicians";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(914, 530);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNewTitle);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.dtpNewJobDate);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtNewDescription);
            this.tabPage1.Controls.Add(this.rtbNewNotes);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnCreateJob);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.rtbTechDetails);
            this.tabPage1.Controls.Add(this.rtbSALdetails);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lstvAvailableTechs);
            this.tabPage1.Controls.Add(this.lstvServiceRequests);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(906, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Job";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNewTitle
            // 
            this.txtNewTitle.Location = new System.Drawing.Point(98, 321);
            this.txtNewTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewTitle.Name = "txtNewTitle";
            this.txtNewTitle.Size = new System.Drawing.Size(190, 20);
            this.txtNewTitle.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 324);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Task Title";
            // 
            // dtpNewJobDate
            // 
            this.dtpNewJobDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpNewJobDate.Location = new System.Drawing.Point(557, 353);
            this.dtpNewJobDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNewJobDate.Name = "dtpNewJobDate";
            this.dtpNewJobDate.Size = new System.Drawing.Size(151, 20);
            this.dtpNewJobDate.TabIndex = 27;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(443, 359);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 13);
            this.label23.TabIndex = 26;
            this.label23.Text = "Job Date and TIme";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Description";
            // 
            // txtNewDescription
            // 
            this.txtNewDescription.Location = new System.Drawing.Point(98, 356);
            this.txtNewDescription.Name = "txtNewDescription";
            this.txtNewDescription.Size = new System.Drawing.Size(252, 20);
            this.txtNewDescription.TabIndex = 11;
            // 
            // rtbNewNotes
            // 
            this.rtbNewNotes.Location = new System.Drawing.Point(22, 415);
            this.rtbNewNotes.Name = "rtbNewNotes";
            this.rtbNewNotes.Size = new System.Drawing.Size(591, 58);
            this.rtbNewNotes.TabIndex = 10;
            this.rtbNewNotes.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Notes";
            // 
            // btnCreateJob
            // 
            this.btnCreateJob.Location = new System.Drawing.Point(660, 424);
            this.btnCreateJob.Name = "btnCreateJob";
            this.btnCreateJob.Size = new System.Drawing.Size(182, 36);
            this.btnCreateJob.TabIndex = 8;
            this.btnCreateJob.Text = "Assign Job to selected Technician";
            this.btnCreateJob.UseVisualStyleBackColor = true;
            this.btnCreateJob.Click += new System.EventHandler(this.btnCreateJob_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maintenance technician details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Service level agreement details";
            // 
            // rtbTechDetails
            // 
            this.rtbTechDetails.Location = new System.Drawing.Point(348, 226);
            this.rtbTechDetails.Name = "rtbTechDetails";
            this.rtbTechDetails.Size = new System.Drawing.Size(430, 71);
            this.rtbTechDetails.TabIndex = 5;
            this.rtbTechDetails.Text = "";
            // 
            // rtbSALdetails
            // 
            this.rtbSALdetails.Location = new System.Drawing.Point(348, 82);
            this.rtbSALdetails.Name = "rtbSALdetails";
            this.rtbSALdetails.Size = new System.Drawing.Size(430, 81);
            this.rtbSALdetails.TabIndex = 4;
            this.rtbSALdetails.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReAssignJob);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dtpChangeJobDate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtChangeDesc);
            this.tabPage2.Controls.Add(this.rtbChangeNotes);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.lstvChangeTitle);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.lstvJobs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(906, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Track Job";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReAssignJob
            // 
            this.btnReAssignJob.Location = new System.Drawing.Point(638, 374);
            this.btnReAssignJob.Name = "btnReAssignJob";
            this.btnReAssignJob.Size = new System.Drawing.Size(182, 38);
            this.btnReAssignJob.TabIndex = 39;
            this.btnReAssignJob.Text = "Re-assign Job";
            this.btnReAssignJob.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReAssignTech);
            this.groupBox1.Controls.Add(this.txtCurrentTech);
            this.groupBox1.Controls.Add(this.lblCurrentTech);
            this.groupBox1.Controls.Add(this.lstvChangeTech);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.rtbNewTechDetails);
            this.groupBox1.Location = new System.Drawing.Point(402, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 309);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maintenance Technician";
            // 
            // btnReAssignTech
            // 
            this.btnReAssignTech.Location = new System.Drawing.Point(147, 251);
            this.btnReAssignTech.Name = "btnReAssignTech";
            this.btnReAssignTech.Size = new System.Drawing.Size(182, 38);
            this.btnReAssignTech.TabIndex = 10;
            this.btnReAssignTech.Text = "Assign Technician";
            this.btnReAssignTech.UseVisualStyleBackColor = true;
            this.btnReAssignTech.Click += new System.EventHandler(this.btnReAssignTech_Click);
            // 
            // txtCurrentTech
            // 
            this.txtCurrentTech.Enabled = false;
            this.txtCurrentTech.Location = new System.Drawing.Point(147, 22);
            this.txtCurrentTech.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrentTech.Name = "txtCurrentTech";
            this.txtCurrentTech.Size = new System.Drawing.Size(168, 20);
            this.txtCurrentTech.TabIndex = 39;
            // 
            // lblCurrentTech
            // 
            this.lblCurrentTech.AutoSize = true;
            this.lblCurrentTech.Location = new System.Drawing.Point(22, 25);
            this.lblCurrentTech.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentTech.Name = "lblCurrentTech";
            this.lblCurrentTech.Size = new System.Drawing.Size(97, 13);
            this.lblCurrentTech.TabIndex = 38;
            this.lblCurrentTech.Text = "Current Technician";
            // 
            // lstvChangeTech
            // 
            this.lstvChangeTech.HideSelection = false;
            this.lstvChangeTech.Location = new System.Drawing.Point(25, 73);
            this.lstvChangeTech.Name = "lstvChangeTech";
            this.lstvChangeTech.Size = new System.Drawing.Size(290, 72);
            this.lstvChangeTech.TabIndex = 34;
            this.lstvChangeTech.UseCompatibleStateImageBehavior = false;
            this.lstvChangeTech.View = System.Windows.Forms.View.List;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Maintenance technician details";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Change Technician";
            // 
            // rtbNewTechDetails
            // 
            this.rtbNewTechDetails.Location = new System.Drawing.Point(25, 172);
            this.rtbNewTechDetails.Name = "rtbNewTechDetails";
            this.rtbNewTechDetails.Size = new System.Drawing.Size(430, 71);
            this.rtbNewTechDetails.TabIndex = 36;
            this.rtbNewTechDetails.Text = "";
            // 
            // dtpChangeJobDate
            // 
            this.dtpChangeJobDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpChangeJobDate.Location = new System.Drawing.Point(132, 277);
            this.dtpChangeJobDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpChangeJobDate.Name = "dtpChangeJobDate";
            this.dtpChangeJobDate.Size = new System.Drawing.Size(151, 20);
            this.dtpChangeJobDate.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 283);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Job Date and Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Description";
            // 
            // txtChangeDesc
            // 
            this.txtChangeDesc.Location = new System.Drawing.Point(132, 242);
            this.txtChangeDesc.Name = "txtChangeDesc";
            this.txtChangeDesc.Size = new System.Drawing.Size(254, 20);
            this.txtChangeDesc.TabIndex = 30;
            // 
            // rtbChangeNotes
            // 
            this.rtbChangeNotes.Location = new System.Drawing.Point(19, 341);
            this.rtbChangeNotes.Name = "rtbChangeNotes";
            this.rtbChangeNotes.Size = new System.Drawing.Size(591, 94);
            this.rtbChangeNotes.TabIndex = 29;
            this.rtbChangeNotes.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Notes";
            // 
            // lstvChangeTitle
            // 
            this.lstvChangeTitle.Location = new System.Drawing.Point(132, 207);
            this.lstvChangeTitle.Margin = new System.Windows.Forms.Padding(2);
            this.lstvChangeTitle.Name = "lstvChangeTitle";
            this.lstvChangeTitle.Size = new System.Drawing.Size(177, 20);
            this.lstvChangeTitle.TabIndex = 22;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 210);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 21;
            this.label25.Text = "Task Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Active Jobs";
            // 
            // lstvJobs
            // 
            this.lstvJobs.HideSelection = false;
            this.lstvJobs.Location = new System.Drawing.Point(19, 44);
            this.lstvJobs.Name = "lstvJobs";
            this.lstvJobs.Size = new System.Drawing.Size(290, 141);
            this.lstvJobs.TabIndex = 2;
            this.lstvJobs.UseCompatibleStateImageBehavior = false;
            this.lstvJobs.View = System.Windows.Forms.View.List;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(364, 548);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(182, 38);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return to Call Centre";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // ServiceDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 598);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.tabControl1);
            this.Name = "ServiceDepartment";
            this.Text = "ServiceDepartment";
            this.Load += new System.EventHandler(this.ServiceDepartment_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstvAvailableTechs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstvServiceRequests;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbTechDetails;
        private System.Windows.Forms.RichTextBox rtbSALdetails;
        private System.Windows.Forms.Button btnCreateJob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lstvJobs;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNewDescription;
        private System.Windows.Forms.RichTextBox rtbNewNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lstvChangeTitle;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dtpNewJobDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpChangeJobDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChangeDesc;
        private System.Windows.Forms.RichTextBox rtbChangeNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReAssignTech;
        private System.Windows.Forms.TextBox txtCurrentTech;
        private System.Windows.Forms.Label lblCurrentTech;
        private System.Windows.Forms.ListView lstvChangeTech;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtbNewTechDetails;
        private System.Windows.Forms.Button btnReAssignJob;
        private System.Windows.Forms.TextBox txtNewTitle;
        private System.Windows.Forms.Label label14;
    }
}