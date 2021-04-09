
namespace PSS
{
    partial class Form1
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
            this.cbClientDropDown = new System.Windows.Forms.ComboBox();
            this.Counter = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnFollowUp = new System.Windows.Forms.Button();
            this.btnMakeCall = new System.Windows.Forms.Button();
            this.btnEndCall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PSS.Properties.Resources.Phone;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 629);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbClientDropDown
            // 
            this.cbClientDropDown.FormattingEnabled = true;
            this.cbClientDropDown.Location = new System.Drawing.Point(26, 105);
            this.cbClientDropDown.Name = "cbClientDropDown";
            this.cbClientDropDown.Size = new System.Drawing.Size(245, 21);
            this.cbClientDropDown.TabIndex = 1;
            // 
            // Counter
            // 
            this.Counter.AutoSize = true;
            this.Counter.Location = new System.Drawing.Point(131, 89);
            this.Counter.Name = "Counter";
            this.Counter.Size = new System.Drawing.Size(34, 13);
            this.Counter.TabIndex = 2;
            this.Counter.Text = "00:00";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(26, 190);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(244, 82);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "1. Register as new client";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(26, 275);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(244, 82);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "2. Log a request";
            this.btnLogIn.UseVisualStyleBackColor = true;
            // 
            // btnFollowUp
            // 
            this.btnFollowUp.Location = new System.Drawing.Point(26, 363);
            this.btnFollowUp.Name = "btnFollowUp";
            this.btnFollowUp.Size = new System.Drawing.Size(244, 82);
            this.btnFollowUp.TabIndex = 5;
            this.btnFollowUp.Text = "3. Client follow up";
            this.btnFollowUp.UseVisualStyleBackColor = true;
            // 
            // btnMakeCall
            // 
            this.btnMakeCall.Location = new System.Drawing.Point(26, 480);
            this.btnMakeCall.Name = "btnMakeCall";
            this.btnMakeCall.Size = new System.Drawing.Size(122, 54);
            this.btnMakeCall.TabIndex = 6;
            this.btnMakeCall.Text = "Call PSS";
            this.btnMakeCall.UseVisualStyleBackColor = true;
            // 
            // btnEndCall
            // 
            this.btnEndCall.Location = new System.Drawing.Point(149, 480);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(122, 54);
            this.btnEndCall.TabIndex = 7;
            this.btnEndCall.Text = "End Call";
            this.btnEndCall.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 632);
            this.Controls.Add(this.btnEndCall);
            this.Controls.Add(this.btnMakeCall);
            this.Controls.Add(this.btnFollowUp);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.Counter);
            this.Controls.Add(this.cbClientDropDown);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "MakeCall";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbClientDropDown;
        private System.Windows.Forms.Label Counter;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnFollowUp;
        private System.Windows.Forms.Button btnMakeCall;
        private System.Windows.Forms.Button btnEndCall;
    }
}

