
namespace PSS.Presentation_Layer
{
    partial class ClientFollowUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientFollowUp));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.btnGetProgressReport = new System.Windows.Forms.Button();
            this.rtxtRaport = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCallClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket Number";
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Location = new System.Drawing.Point(15, 25);
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.Size = new System.Drawing.Size(153, 20);
            this.txtTicketNumber.TabIndex = 1;
            // 
            // btnGetProgressReport
            // 
            this.btnGetProgressReport.Location = new System.Drawing.Point(15, 51);
            this.btnGetProgressReport.Name = "btnGetProgressReport";
            this.btnGetProgressReport.Size = new System.Drawing.Size(153, 23);
            this.btnGetProgressReport.TabIndex = 2;
            this.btnGetProgressReport.Text = "Get progress raport";
            this.btnGetProgressReport.UseVisualStyleBackColor = true;
            this.btnGetProgressReport.Click += new System.EventHandler(this.btnGetProgressReport_Click);
            // 
            // rtxtRaport
            // 
            this.rtxtRaport.Location = new System.Drawing.Point(15, 80);
            this.rtxtRaport.Name = "rtxtRaport";
            this.rtxtRaport.Size = new System.Drawing.Size(153, 116);
            this.rtxtRaport.TabIndex = 3;
            this.rtxtRaport.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 202);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(93, 202);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(202, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 409);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnCallClient
            // 
            this.btnCallClient.Location = new System.Drawing.Point(215, 69);
            this.btnCallClient.Name = "btnCallClient";
            this.btnCallClient.Size = new System.Drawing.Size(177, 23);
            this.btnCallClient.TabIndex = 7;
            this.btnCallClient.Text = "Call Client";
            this.btnCallClient.UseVisualStyleBackColor = true;
            this.btnCallClient.Click += new System.EventHandler(this.btnCallClient_Click);
            // 
            // ClientFollowUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 450);
            this.Controls.Add(this.btnCallClient);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.rtxtRaport);
            this.Controls.Add(this.btnGetProgressReport);
            this.Controls.Add(this.txtTicketNumber);
            this.Controls.Add(this.label1);
            this.Name = "ClientFollowUp";
            this.Text = "ClientFollowUp";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.Button btnGetProgressReport;
        private System.Windows.Forms.RichTextBox rtxtRaport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCallClient;
    }
}