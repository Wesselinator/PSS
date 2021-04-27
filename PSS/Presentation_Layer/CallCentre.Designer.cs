
namespace PSS.Presentation_Layer
{
    partial class CallCentre
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
            this.grbxProblem = new System.Windows.Forms.GroupBox();
            this.cbxProblemType = new System.Windows.Forms.ComboBox();
            this.lblProblemTitleTag = new System.Windows.Forms.Label();
            this.txtProblemTitle = new System.Windows.Forms.TextBox();
            this.btnUpdateSR = new System.Windows.Forms.Button();
            this.rtbProblem = new System.Windows.Forms.RichTextBox();
            this.grbxContractInfo = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grbxTransfer = new System.Windows.Forms.GroupBox();
            this.btnClientSatisfaction = new System.Windows.Forms.Button();
            this.btnServiceDept = new System.Windows.Forms.Button();
            this.btnClientMaintence = new System.Windows.Forms.Button();
            this.ciwMain = new PSS.Presentation_Layer.ClientInfoWidgit();
            this.grbxProblem.SuspendLayout();
            this.grbxContractInfo.SuspendLayout();
            this.grbxTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxProblem
            // 
            this.grbxProblem.Controls.Add(this.cbxProblemType);
            this.grbxProblem.Controls.Add(this.lblProblemTitleTag);
            this.grbxProblem.Controls.Add(this.txtProblemTitle);
            this.grbxProblem.Controls.Add(this.btnUpdateSR);
            this.grbxProblem.Controls.Add(this.rtbProblem);
            this.grbxProblem.Location = new System.Drawing.Point(18, 183);
            this.grbxProblem.Name = "grbxProblem";
            this.grbxProblem.Size = new System.Drawing.Size(770, 240);
            this.grbxProblem.TabIndex = 1;
            this.grbxProblem.TabStop = false;
            this.grbxProblem.Text = "Problem";
            // 
            // cbxProblemType
            // 
            this.cbxProblemType.FormattingEnabled = true;
            this.cbxProblemType.Items.AddRange(new object[] {
            "Unknown Problem",
            "Maintainance",
            "Printers",
            "Computers",
            "Servers",
            "Cellphone"});
            this.cbxProblemType.Location = new System.Drawing.Point(624, 19);
            this.cbxProblemType.Name = "cbxProblemType";
            this.cbxProblemType.Size = new System.Drawing.Size(128, 21);
            this.cbxProblemType.TabIndex = 17;
            this.cbxProblemType.Text = "Type...";
            // 
            // lblProblemTitleTag
            // 
            this.lblProblemTitleTag.AutoSize = true;
            this.lblProblemTitleTag.Location = new System.Drawing.Point(9, 22);
            this.lblProblemTitleTag.Name = "lblProblemTitleTag";
            this.lblProblemTitleTag.Size = new System.Drawing.Size(71, 13);
            this.lblProblemTitleTag.TabIndex = 16;
            this.lblProblemTitleTag.Text = "Problem Title:";
            this.lblProblemTitleTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProblemTitle
            // 
            this.txtProblemTitle.Location = new System.Drawing.Point(86, 19);
            this.txtProblemTitle.Name = "txtProblemTitle";
            this.txtProblemTitle.Size = new System.Drawing.Size(510, 20);
            this.txtProblemTitle.TabIndex = 3;
            this.txtProblemTitle.Text = "Problem Title";
            // 
            // btnUpdateSR
            // 
            this.btnUpdateSR.Location = new System.Drawing.Point(278, 193);
            this.btnUpdateSR.Name = "btnUpdateSR";
            this.btnUpdateSR.Size = new System.Drawing.Size(202, 41);
            this.btnUpdateSR.TabIndex = 2;
            this.btnUpdateSR.Text = "Update Service Request";
            this.btnUpdateSR.UseVisualStyleBackColor = true;
            this.btnUpdateSR.Click += new System.EventHandler(this.btnUpdateTicket_Click);
            // 
            // rtbProblem
            // 
            this.rtbProblem.Location = new System.Drawing.Point(6, 45);
            this.rtbProblem.Name = "rtbProblem";
            this.rtbProblem.Size = new System.Drawing.Size(746, 142);
            this.rtbProblem.TabIndex = 1;
            this.rtbProblem.Text = "Problem Description...";
            // 
            // grbxContractInfo
            // 
            this.grbxContractInfo.Controls.Add(this.richTextBox1);
            this.grbxContractInfo.Location = new System.Drawing.Point(12, 12);
            this.grbxContractInfo.Name = "grbxContractInfo";
            this.grbxContractInfo.Size = new System.Drawing.Size(776, 165);
            this.grbxContractInfo.TabIndex = 1;
            this.grbxContractInfo.TabStop = false;
            this.grbxContractInfo.Text = "Contract Information";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(764, 140);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // grbxTransfer
            // 
            this.grbxTransfer.Controls.Add(this.btnClientSatisfaction);
            this.grbxTransfer.Controls.Add(this.btnServiceDept);
            this.grbxTransfer.Controls.Add(this.btnClientMaintence);
            this.grbxTransfer.Location = new System.Drawing.Point(794, 228);
            this.grbxTransfer.Name = "grbxTransfer";
            this.grbxTransfer.Size = new System.Drawing.Size(332, 195);
            this.grbxTransfer.TabIndex = 2;
            this.grbxTransfer.TabStop = false;
            this.grbxTransfer.Text = "Transfer";
            // 
            // btnClientSatisfaction
            // 
            this.btnClientSatisfaction.Location = new System.Drawing.Point(109, 148);
            this.btnClientSatisfaction.Name = "btnClientSatisfaction";
            this.btnClientSatisfaction.Size = new System.Drawing.Size(142, 31);
            this.btnClientSatisfaction.TabIndex = 5;
            this.btnClientSatisfaction.Text = "Client Satisfaction";
            this.btnClientSatisfaction.UseVisualStyleBackColor = true;
            this.btnClientSatisfaction.Click += new System.EventHandler(this.btnClientSatisfaction_Click);
            // 
            // btnServiceDept
            // 
            this.btnServiceDept.Location = new System.Drawing.Point(109, 87);
            this.btnServiceDept.Name = "btnServiceDept";
            this.btnServiceDept.Size = new System.Drawing.Size(142, 31);
            this.btnServiceDept.TabIndex = 4;
            this.btnServiceDept.Text = "Service Dept.";
            this.btnServiceDept.UseVisualStyleBackColor = true;
            this.btnServiceDept.Click += new System.EventHandler(this.btnServiceDept_Click);
            // 
            // btnClientMaintence
            // 
            this.btnClientMaintence.Location = new System.Drawing.Point(109, 19);
            this.btnClientMaintence.Name = "btnClientMaintence";
            this.btnClientMaintence.Size = new System.Drawing.Size(142, 31);
            this.btnClientMaintence.TabIndex = 3;
            this.btnClientMaintence.Text = "Client Maintence";
            this.btnClientMaintence.UseVisualStyleBackColor = true;
            this.btnClientMaintence.Click += new System.EventHandler(this.btnClientMaintence_Click);
            // 
            // ciwMain
            // 
            this.ciwMain.AutoSize = true;
            this.ciwMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ciwMain.Client = null;
            this.ciwMain.Location = new System.Drawing.Point(794, 12);
            this.ciwMain.Name = "ciwMain";
            this.ciwMain.Size = new System.Drawing.Size(332, 207);
            this.ciwMain.TabIndex = 3;
            // 
            // CallCentre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 429);
            this.Controls.Add(this.ciwMain);
            this.Controls.Add(this.grbxTransfer);
            this.Controls.Add(this.grbxContractInfo);
            this.Controls.Add(this.grbxProblem);
            this.Name = "CallCentre";
            this.Text = "Call Center";
            this.grbxProblem.ResumeLayout(false);
            this.grbxProblem.PerformLayout();
            this.grbxContractInfo.ResumeLayout(false);
            this.grbxTransfer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbxProblem;
        private System.Windows.Forms.GroupBox grbxContractInfo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnUpdateSR;
        private System.Windows.Forms.RichTextBox rtbProblem;
        private System.Windows.Forms.GroupBox grbxTransfer;
        private System.Windows.Forms.Button btnClientMaintence;
        private System.Windows.Forms.Button btnClientSatisfaction;
        private System.Windows.Forms.Button btnServiceDept;
        private System.Windows.Forms.Label lblProblemTitleTag;
        private System.Windows.Forms.TextBox txtProblemTitle;
        private System.Windows.Forms.ComboBox cbxProblemType;
        private ClientInfoWidgit ciwMain;
    }
}