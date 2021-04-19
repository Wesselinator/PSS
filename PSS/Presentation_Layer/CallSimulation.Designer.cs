
namespace PSS.Presentation_Layer
{
    partial class CallSimulation
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFollowUp = new System.Windows.Forms.Button();
            this.btnLogRequest = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.cbClientDropDown = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.btnMakeCall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PSS.Properties.Resources.Phone;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 623);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFollowUp
            // 
            this.btnFollowUp.Location = new System.Drawing.Point(24, 349);
            this.btnFollowUp.Name = "btnFollowUp";
            this.btnFollowUp.Size = new System.Drawing.Size(244, 64);
            this.btnFollowUp.TabIndex = 9;
            this.btnFollowUp.Text = "3. Client Follow up";
            this.btnFollowUp.UseVisualStyleBackColor = true;
            // 
            // btnLogRequest
            // 
            this.btnLogRequest.Location = new System.Drawing.Point(24, 279);
            this.btnLogRequest.Name = "btnLogRequest";
            this.btnLogRequest.Size = new System.Drawing.Size(244, 64);
            this.btnLogRequest.TabIndex = 8;
            this.btnLogRequest.Text = "2. Log a request";
            this.btnLogRequest.UseVisualStyleBackColor = true;
            this.btnLogRequest.Click += new System.EventHandler(this.btnLogRequest_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(24, 209);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(244, 64);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "1. Register as new client";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // cbClientDropDown
            // 
            this.cbClientDropDown.FormattingEnabled = true;
            this.cbClientDropDown.Items.AddRange(new object[] {
            "Name - number",
            "Name - number",
            "Name - number"});
            this.cbClientDropDown.Location = new System.Drawing.Point(25, 105);
            this.cbClientDropDown.Name = "cbClientDropDown";
            this.cbClientDropDown.Size = new System.Drawing.Size(244, 21);
            this.cbClientDropDown.TabIndex = 11;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(129, 89);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(34, 13);
            this.lblTimer.TabIndex = 10;
            this.lblTimer.Text = "00:00";
            // 
            // btnEndCall
            // 
            this.btnEndCall.Location = new System.Drawing.Point(150, 480);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(119, 52);
            this.btnEndCall.TabIndex = 13;
            this.btnEndCall.Text = "End Call";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // btnMakeCall
            // 
            this.btnMakeCall.Location = new System.Drawing.Point(25, 480);
            this.btnMakeCall.Name = "btnMakeCall";
            this.btnMakeCall.Size = new System.Drawing.Size(119, 52);
            this.btnMakeCall.TabIndex = 12;
            this.btnMakeCall.Text = "Call PSS";
            this.btnMakeCall.UseVisualStyleBackColor = true;
            this.btnMakeCall.Click += new System.EventHandler(this.btnMakeCall_Click);
            // 
            // CallSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 622);
            this.Controls.Add(this.btnEndCall);
            this.Controls.Add(this.btnMakeCall);
            this.Controls.Add(this.cbClientDropDown);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnFollowUp);
            this.Controls.Add(this.btnLogRequest);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CallSimulation";
            this.Text = "CallSimulation";
            this.Load += new System.EventHandler(this.CallSimulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFollowUp;
        private System.Windows.Forms.Button btnLogRequest;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox cbClientDropDown;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnEndCall;
        private System.Windows.Forms.Button btnMakeCall;
    }
}