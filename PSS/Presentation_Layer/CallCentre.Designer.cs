
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
            this.grbxTransfer = new System.Windows.Forms.GroupBox();
            this.btnClientSatisfaction = new System.Windows.Forms.Button();
            this.btnServiceDept = new System.Windows.Forms.Button();
            this.btnClientMaintence = new System.Windows.Forms.Button();
            this.ciwMain = new PSS.Presentation_Layer.ClientInfoWidgit();
            this.iwCallContract = new PSS.Presentation_Layer.ContractInfoWidget();
            this.lsbxServices = new System.Windows.Forms.ListBox();
            this.rtbServiceDetails = new System.Windows.Forms.RichTextBox();
            this.lsbxPreviousCalls = new System.Windows.Forms.ListBox();
            this.grbxPreviousCalls = new System.Windows.Forms.GroupBox();
            this.rtbCallDescription = new System.Windows.Forms.RichTextBox();
            this.grbxProblem.SuspendLayout();
            this.grbxTransfer.SuspendLayout();
            this.grbxPreviousCalls.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxProblem
            // 
            this.grbxProblem.Controls.Add(this.cbxProblemType);
            this.grbxProblem.Controls.Add(this.lblProblemTitleTag);
            this.grbxProblem.Controls.Add(this.txtProblemTitle);
            this.grbxProblem.Controls.Add(this.btnUpdateSR);
            this.grbxProblem.Controls.Add(this.rtbProblem);
            this.grbxProblem.Location = new System.Drawing.Point(18, 12);
            this.grbxProblem.Name = "grbxProblem";
            this.grbxProblem.Size = new System.Drawing.Size(731, 240);
            this.grbxProblem.TabIndex = 1;
            this.grbxProblem.TabStop = false;
            this.grbxProblem.Text = "Problem";
            // 
            // cbxProblemType
            // 
            this.cbxProblemType.FormattingEnabled = true;
            this.cbxProblemType.Items.AddRange(new object[] {
            "Unknown Problem",
            "Printers",
            "Computer Hardware",
            "Computer Software",
            "Servers Hardware",
            "Server Software",
            "Cellphone"});
            this.cbxProblemType.Location = new System.Drawing.Point(588, 18);
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
            this.txtProblemTitle.Size = new System.Drawing.Size(478, 20);
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
            this.rtbProblem.Size = new System.Drawing.Size(710, 142);
            this.rtbProblem.TabIndex = 1;
            this.rtbProblem.Text = "Problem Description...";
            // 
            // grbxTransfer
            // 
            this.grbxTransfer.Controls.Add(this.btnClientSatisfaction);
            this.grbxTransfer.Controls.Add(this.btnServiceDept);
            this.grbxTransfer.Controls.Add(this.btnClientMaintence);
            this.grbxTransfer.Location = new System.Drawing.Point(18, 267);
            this.grbxTransfer.Name = "grbxTransfer";
            this.grbxTransfer.Size = new System.Drawing.Size(731, 72);
            this.grbxTransfer.TabIndex = 2;
            this.grbxTransfer.TabStop = false;
            this.grbxTransfer.Text = "Transfer";
            // 
            // btnClientSatisfaction
            // 
            this.btnClientSatisfaction.Location = new System.Drawing.Point(464, 19);
            this.btnClientSatisfaction.Name = "btnClientSatisfaction";
            this.btnClientSatisfaction.Size = new System.Drawing.Size(142, 31);
            this.btnClientSatisfaction.TabIndex = 5;
            this.btnClientSatisfaction.Text = "Client Satisfaction";
            this.btnClientSatisfaction.UseVisualStyleBackColor = true;
            this.btnClientSatisfaction.Click += new System.EventHandler(this.btnClientSatisfaction_Click);
            // 
            // btnServiceDept
            // 
            this.btnServiceDept.Location = new System.Drawing.Point(291, 19);
            this.btnServiceDept.Name = "btnServiceDept";
            this.btnServiceDept.Size = new System.Drawing.Size(142, 31);
            this.btnServiceDept.TabIndex = 4;
            this.btnServiceDept.Text = "Service Dept.";
            this.btnServiceDept.UseVisualStyleBackColor = true;
            this.btnServiceDept.Click += new System.EventHandler(this.btnServiceDept_Click);
            // 
            // btnClientMaintence
            // 
            this.btnClientMaintence.Location = new System.Drawing.Point(110, 19);
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
            this.ciwMain.Location = new System.Drawing.Point(761, 12);
            this.ciwMain.Name = "ciwMain";
            this.ciwMain.Size = new System.Drawing.Size(356, 207);
            this.ciwMain.TabIndex = 3;
            // 
            // iwCallContract
            // 
            this.iwCallContract.Contract = null;
            this.iwCallContract.Location = new System.Drawing.Point(761, 228);
            this.iwCallContract.Name = "iwCallContract";
            this.iwCallContract.Size = new System.Drawing.Size(356, 158);
            this.iwCallContract.TabIndex = 4;
            // 
            // lsbxServices
            // 
            this.lsbxServices.FormattingEnabled = true;
            this.lsbxServices.Location = new System.Drawing.Point(761, 392);
            this.lsbxServices.Name = "lsbxServices";
            this.lsbxServices.Size = new System.Drawing.Size(356, 82);
            this.lsbxServices.TabIndex = 5;
            this.lsbxServices.SelectedIndexChanged += new System.EventHandler(this.lsbxServices_SelectedIndexChanged);
            // 
            // rtbServiceDetails
            // 
            this.rtbServiceDetails.Location = new System.Drawing.Point(761, 481);
            this.rtbServiceDetails.Name = "rtbServiceDetails";
            this.rtbServiceDetails.Size = new System.Drawing.Size(356, 64);
            this.rtbServiceDetails.TabIndex = 6;
            this.rtbServiceDetails.Text = "";
            // 
            // lsbxPreviousCalls
            // 
            this.lsbxPreviousCalls.FormattingEnabled = true;
            this.lsbxPreviousCalls.Location = new System.Drawing.Point(6, 19);
            this.lsbxPreviousCalls.Name = "lsbxPreviousCalls";
            this.lsbxPreviousCalls.Size = new System.Drawing.Size(378, 147);
            this.lsbxPreviousCalls.TabIndex = 7;
            this.lsbxPreviousCalls.SelectedIndexChanged += new System.EventHandler(this.lsbxPreviousCalls_SelectedIndexChanged);
            // 
            // grbxPreviousCalls
            // 
            this.grbxPreviousCalls.Controls.Add(this.rtbCallDescription);
            this.grbxPreviousCalls.Controls.Add(this.lsbxPreviousCalls);
            this.grbxPreviousCalls.Location = new System.Drawing.Point(18, 362);
            this.grbxPreviousCalls.Name = "grbxPreviousCalls";
            this.grbxPreviousCalls.Size = new System.Drawing.Size(731, 183);
            this.grbxPreviousCalls.TabIndex = 8;
            this.grbxPreviousCalls.TabStop = false;
            this.grbxPreviousCalls.Text = "Previous Calls";
            // 
            // rtbCallDescription
            // 
            this.rtbCallDescription.Location = new System.Drawing.Point(390, 19);
            this.rtbCallDescription.Name = "rtbCallDescription";
            this.rtbCallDescription.Size = new System.Drawing.Size(326, 147);
            this.rtbCallDescription.TabIndex = 9;
            this.rtbCallDescription.Text = "";
            // 
            // CallCentre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 557);
            this.Controls.Add(this.grbxPreviousCalls);
            this.Controls.Add(this.rtbServiceDetails);
            this.Controls.Add(this.lsbxServices);
            this.Controls.Add(this.iwCallContract);
            this.Controls.Add(this.ciwMain);
            this.Controls.Add(this.grbxTransfer);
            this.Controls.Add(this.grbxProblem);
            this.Name = "CallCentre";
            this.Text = "Call Center";
            this.grbxProblem.ResumeLayout(false);
            this.grbxProblem.PerformLayout();
            this.grbxTransfer.ResumeLayout(false);
            this.grbxPreviousCalls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbxProblem;
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
        private ContractInfoWidget iwCallContract;
        private System.Windows.Forms.ListBox lsbxServices;
        private System.Windows.Forms.RichTextBox rtbServiceDetails;
        private System.Windows.Forms.ListBox lsbxPreviousCalls;
        private System.Windows.Forms.GroupBox grbxPreviousCalls;
        private System.Windows.Forms.RichTextBox rtbCallDescription;
    }
}