
namespace PSS.Presentation_Layer
{
    partial class ServiceInfoWidget
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
            this.lblServiceName = new System.Windows.Forms.Label();
            this.lblHeadingType = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.lblHeadingDesc = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.Location = new System.Drawing.Point(13, 12);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(227, 41);
            this.lblServiceName.TabIndex = 2;
            this.lblServiceName.Text = "Service Name";
            this.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeadingType
            // 
            this.lblHeadingType.AutoSize = true;
            this.lblHeadingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingType.Location = new System.Drawing.Point(23, 55);
            this.lblHeadingType.Name = "lblHeadingType";
            this.lblHeadingType.Size = new System.Drawing.Size(79, 15);
            this.lblHeadingType.TabIndex = 3;
            this.lblHeadingType.Text = "Service Type:";
            // 
            // lblServiceType
            // 
            this.lblServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceType.Location = new System.Drawing.Point(108, 57);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(66, 14);
            this.lblServiceType.TabIndex = 4;
            this.lblServiceType.Text = "Service type";
            // 
            // lblHeadingDesc
            // 
            this.lblHeadingDesc.AutoSize = true;
            this.lblHeadingDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadingDesc.Location = new System.Drawing.Point(30, 79);
            this.lblHeadingDesc.Name = "lblHeadingDesc";
            this.lblHeadingDesc.Size = new System.Drawing.Size(72, 15);
            this.lblHeadingDesc.TabIndex = 5;
            this.lblHeadingDesc.Text = "Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(111, 78);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(260, 72);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.Text = "";
            // 
            // ServiceInfoWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblHeadingDesc);
            this.Controls.Add(this.lblServiceType);
            this.Controls.Add(this.lblHeadingType);
            this.Controls.Add(this.lblServiceName);
            this.Name = "ServiceInfoWidget";
            this.Size = new System.Drawing.Size(388, 166);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblHeadingType;
        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.Label lblHeadingDesc;
        private System.Windows.Forms.RichTextBox rtbDescription;
    }
}
