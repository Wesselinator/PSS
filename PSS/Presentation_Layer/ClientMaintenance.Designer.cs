
namespace PSS.Presentation_Layer
{
    partial class ClientMaintenance
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
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.lblBusinessName = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCM = new System.Windows.Forms.Button();
            this.Contract = new System.Windows.Forms.GroupBox();
            this.cbxCurentContract = new System.Windows.Forms.ComboBox();
            this.lsbxPreviousContracts = new System.Windows.Forms.ListBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.lblClientType = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.cbxClientPerson = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grbBPeople = new System.Windows.Forms.GroupBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.btnAddToBP = new System.Windows.Forms.Button();
            this.lsbxBusinessPeople = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudPostalCode = new PSS.Presentation_Layer.ArrowlessNumericUpDown();
            this.cbxProvince = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.rbtnBusiness = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtnIndvidual = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.grbPerson = new System.Windows.Forms.GroupBox();
            this.btnModifyPerson = new System.Windows.Forms.Button();
            this.btnNewPerson = new System.Windows.Forms.Button();
            this.lblExistingPerson = new System.Windows.Forms.Label();
            this.lsbxExistingPeople = new System.Windows.Forms.ListBox();
            this.btnPerson = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtCellphone = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblClientMaintenance = new System.Windows.Forms.Label();
            this.cbxChooseClient = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.Contract.SuspendLayout();
            this.grbBPeople.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostalCode)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grbPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.Location = new System.Drawing.Point(156, 195);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(226, 26);
            this.txtBusinessName.TabIndex = 48;
            this.txtBusinessName.Visible = false;
            // 
            // lblBusinessName
            // 
            this.lblBusinessName.AutoSize = true;
            this.lblBusinessName.Location = new System.Drawing.Point(26, 200);
            this.lblBusinessName.Name = "lblBusinessName";
            this.lblBusinessName.Size = new System.Drawing.Size(118, 20);
            this.lblBusinessName.TabIndex = 47;
            this.lblBusinessName.Text = "Business name";
            this.lblBusinessName.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCM);
            this.groupBox3.Controls.Add(this.Contract);
            this.groupBox3.Controls.Add(this.cbxType);
            this.groupBox3.Controls.Add(this.lblClientType);
            this.groupBox3.Controls.Add(this.lblPerson);
            this.groupBox3.Controls.Add(this.btnClient);
            this.groupBox3.Controls.Add(this.cbxClientPerson);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtBusinessName);
            this.groupBox3.Controls.Add(this.grbBPeople);
            this.groupBox3.Controls.Add(this.lblBusinessName);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.cbxStatus);
            this.groupBox3.Controls.Add(this.rbtnBusiness);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.rbtnIndvidual);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(470, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1023, 746);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client Management";
            // 
            // btnCM
            // 
            this.btnCM.Location = new System.Drawing.Point(782, 302);
            this.btnCM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCM.Name = "btnCM";
            this.btnCM.Size = new System.Drawing.Size(225, 49);
            this.btnCM.TabIndex = 50;
            this.btnCM.Text = "Open Contract Maintence";
            this.btnCM.UseVisualStyleBackColor = true;
            this.btnCM.Click += new System.EventHandler(this.btnCM_Click);
            // 
            // Contract
            // 
            this.Contract.Controls.Add(this.cbxCurentContract);
            this.Contract.Controls.Add(this.lsbxPreviousContracts);
            this.Contract.Location = new System.Drawing.Point(782, 57);
            this.Contract.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Contract.Name = "Contract";
            this.Contract.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Contract.Size = new System.Drawing.Size(234, 234);
            this.Contract.TabIndex = 57;
            this.Contract.TabStop = false;
            this.Contract.Text = "Contracts";
            // 
            // cbxCurentContract
            // 
            this.cbxCurentContract.FormattingEnabled = true;
            this.cbxCurentContract.Location = new System.Drawing.Point(8, 28);
            this.cbxCurentContract.Name = "cbxCurentContract";
            this.cbxCurentContract.Size = new System.Drawing.Size(217, 28);
            this.cbxCurentContract.TabIndex = 35;
            this.cbxCurentContract.Text = "Choose a contract...";
            // 
            // lsbxPreviousContracts
            // 
            this.lsbxPreviousContracts.Enabled = false;
            this.lsbxPreviousContracts.FormattingEnabled = true;
            this.lsbxPreviousContracts.ItemHeight = 20;
            this.lsbxPreviousContracts.Location = new System.Drawing.Point(9, 68);
            this.lsbxPreviousContracts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lsbxPreviousContracts.Name = "lsbxPreviousContracts";
            this.lsbxPreviousContracts.Size = new System.Drawing.Size(214, 144);
            this.lsbxPreviousContracts.TabIndex = 56;
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Need-Based Customers",
            "Loyal Customers",
            "Discount Customers",
            "Impulsive Customers",
            "Potential Customers",
            "New Customers",
            "Wandering Customers"});
            this.cbxType.Location = new System.Drawing.Point(156, 149);
            this.cbxType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(226, 28);
            this.cbxType.TabIndex = 55;
            this.cbxType.Text = "Choose Type...";
            // 
            // lblClientType
            // 
            this.lblClientType.AutoSize = true;
            this.lblClientType.Location = new System.Drawing.Point(26, 158);
            this.lblClientType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientType.Name = "lblClientType";
            this.lblClientType.Size = new System.Drawing.Size(43, 20);
            this.lblClientType.TabIndex = 54;
            this.lblClientType.Text = "Type";
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(26, 85);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(59, 20);
            this.lblPerson.TabIndex = 52;
            this.lblPerson.Text = "Person";
            this.lblPerson.Visible = false;
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(30, 663);
            this.btnClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(723, 35);
            this.btnClient.TabIndex = 50;
            this.btnClient.Text = "Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // cbxClientPerson
            // 
            this.cbxClientPerson.FormattingEnabled = true;
            this.cbxClientPerson.Location = new System.Drawing.Point(156, 80);
            this.cbxClientPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxClientPerson.Name = "cbxClientPerson";
            this.cbxClientPerson.Size = new System.Drawing.Size(226, 28);
            this.cbxClientPerson.TabIndex = 51;
            this.cbxClientPerson.Text = "Choose Person...";
            this.cbxClientPerson.SelectedIndexChanged += new System.EventHandler(this.cbxClientPerson_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(558, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Address";
            // 
            // grbBPeople
            // 
            this.grbBPeople.Controls.Add(this.lblRole);
            this.grbBPeople.Controls.Add(this.txtRole);
            this.grbBPeople.Controls.Add(this.btnAddToBP);
            this.grbBPeople.Controls.Add(this.lsbxBusinessPeople);
            this.grbBPeople.Location = new System.Drawing.Point(30, 431);
            this.grbBPeople.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbBPeople.Name = "grbBPeople";
            this.grbBPeople.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbBPeople.Size = new System.Drawing.Size(723, 223);
            this.grbBPeople.TabIndex = 50;
            this.grbBPeople.TabStop = false;
            this.grbBPeople.Text = "Business People";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(12, 169);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(42, 20);
            this.lblRole.TabIndex = 52;
            this.lblRole.Text = "Role";
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(64, 165);
            this.txtRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(288, 26);
            this.txtRole.TabIndex = 51;
            // 
            // btnAddToBP
            // 
            this.btnAddToBP.Location = new System.Drawing.Point(363, 162);
            this.btnAddToBP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddToBP.Name = "btnAddToBP";
            this.btnAddToBP.Size = new System.Drawing.Size(344, 35);
            this.btnAddToBP.TabIndex = 34;
            this.btnAddToBP.Text = "Add To Business";
            this.btnAddToBP.UseVisualStyleBackColor = true;
            this.btnAddToBP.Click += new System.EventHandler(this.btnAddToBP_Click);
            // 
            // lsbxBusinessPeople
            // 
            this.lsbxBusinessPeople.FormattingEnabled = true;
            this.lsbxBusinessPeople.ItemHeight = 20;
            this.lsbxBusinessPeople.Location = new System.Drawing.Point(16, 29);
            this.lsbxBusinessPeople.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lsbxBusinessPeople.Name = "lsbxBusinessPeople";
            this.lsbxBusinessPeople.Size = new System.Drawing.Size(688, 124);
            this.lsbxBusinessPeople.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudPostalCode);
            this.panel2.Controls.Add(this.cbxProvince);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtCity);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtStreet);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Location = new System.Drawing.Point(416, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 198);
            this.panel2.TabIndex = 30;
            // 
            // nudPostalCode
            // 
            this.nudPostalCode.Location = new System.Drawing.Point(128, 105);
            this.nudPostalCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPostalCode.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPostalCode.Name = "nudPostalCode";
            this.nudPostalCode.Size = new System.Drawing.Size(78, 26);
            this.nudPostalCode.TabIndex = 24;
            // 
            // cbxProvince
            // 
            this.cbxProvince.FormattingEnabled = true;
            this.cbxProvince.Items.AddRange(new object[] {
            "Eastern Cape",
            "Free State",
            "Gauteng",
            "Kwazulu-Natal",
            "Limpopo",
            "Mpumulanga",
            "Northern Cape",
            "North West",
            "Western Cape"});
            this.cbxProvince.Location = new System.Drawing.Point(128, 155);
            this.cbxProvince.Name = "cbxProvince";
            this.cbxProvince.Size = new System.Drawing.Size(192, 28);
            this.cbxProvince.TabIndex = 23;
            this.cbxProvince.Text = "Choose...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "Province";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 20);
            this.label17.TabIndex = 20;
            this.label17.Text = "Postal Code";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(128, 62);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(192, 26);
            this.txtCity.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 20);
            this.label18.TabIndex = 18;
            this.label18.Text = "City";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(128, 20);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(192, 26);
            this.txtStreet.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 20);
            this.label19.TabIndex = 16;
            this.label19.Text = "Street";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtbNotes);
            this.groupBox4.Location = new System.Drawing.Point(30, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(723, 143);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Notes";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(16, 25);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(688, 96);
            this.rtbNotes.TabIndex = 0;
            this.rtbNotes.Text = "";
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Stat",
            "Status 2",
            "Status"});
            this.cbxStatus.Location = new System.Drawing.Point(156, 235);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(226, 28);
            this.cbxStatus.TabIndex = 24;
            this.cbxStatus.Text = "Choose Status...";
            // 
            // rbtnBusiness
            // 
            this.rbtnBusiness.AutoSize = true;
            this.rbtnBusiness.Location = new System.Drawing.Point(284, 26);
            this.rbtnBusiness.Name = "rbtnBusiness";
            this.rbtnBusiness.Size = new System.Drawing.Size(99, 24);
            this.rbtnBusiness.TabIndex = 43;
            this.rbtnBusiness.TabStop = true;
            this.rbtnBusiness.Text = "Business";
            this.rbtnBusiness.UseVisualStyleBackColor = true;
            this.rbtnBusiness.CheckedChanged += new System.EventHandler(this.rbtnBusiness_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Status";
            // 
            // rbtnIndvidual
            // 
            this.rbtnIndvidual.AutoSize = true;
            this.rbtnIndvidual.Location = new System.Drawing.Point(158, 26);
            this.rbtnIndvidual.Name = "rbtnIndvidual";
            this.rbtnIndvidual.Size = new System.Drawing.Size(100, 24);
            this.rbtnIndvidual.TabIndex = 42;
            this.rbtnIndvidual.TabStop = true;
            this.rbtnIndvidual.Text = "Individual";
            this.rbtnIndvidual.UseVisualStyleBackColor = true;
            this.rbtnIndvidual.CheckedChanged += new System.EventHandler(this.rbtnIndvidual_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Client Type";
            // 
            // grbPerson
            // 
            this.grbPerson.Controls.Add(this.btnModifyPerson);
            this.grbPerson.Controls.Add(this.btnNewPerson);
            this.grbPerson.Controls.Add(this.lblExistingPerson);
            this.grbPerson.Controls.Add(this.lsbxExistingPeople);
            this.grbPerson.Controls.Add(this.btnPerson);
            this.grbPerson.Controls.Add(this.txtEmail);
            this.grbPerson.Controls.Add(this.label20);
            this.grbPerson.Controls.Add(this.txtTelephone);
            this.grbPerson.Controls.Add(this.label21);
            this.grbPerson.Controls.Add(this.dtpDOB);
            this.grbPerson.Controls.Add(this.txtCellphone);
            this.grbPerson.Controls.Add(this.label22);
            this.grbPerson.Controls.Add(this.label23);
            this.grbPerson.Controls.Add(this.txtSurname);
            this.grbPerson.Controls.Add(this.txtName);
            this.grbPerson.Controls.Add(this.label24);
            this.grbPerson.Controls.Add(this.label25);
            this.grbPerson.Location = new System.Drawing.Point(28, 128);
            this.grbPerson.Name = "grbPerson";
            this.grbPerson.Size = new System.Drawing.Size(414, 746);
            this.grbPerson.TabIndex = 44;
            this.grbPerson.TabStop = false;
            this.grbPerson.Text = "Person Details";
            // 
            // btnModifyPerson
            // 
            this.btnModifyPerson.Location = new System.Drawing.Point(267, 663);
            this.btnModifyPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModifyPerson.Name = "btnModifyPerson";
            this.btnModifyPerson.Size = new System.Drawing.Size(120, 35);
            this.btnModifyPerson.TabIndex = 35;
            this.btnModifyPerson.Text = "Modify";
            this.btnModifyPerson.UseVisualStyleBackColor = true;
            this.btnModifyPerson.Click += new System.EventHandler(this.btnModifyPerson_Click);
            // 
            // btnNewPerson
            // 
            this.btnNewPerson.Location = new System.Drawing.Point(51, 663);
            this.btnNewPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewPerson.Name = "btnNewPerson";
            this.btnNewPerson.Size = new System.Drawing.Size(114, 35);
            this.btnNewPerson.TabIndex = 33;
            this.btnNewPerson.Text = "New";
            this.btnNewPerson.UseVisualStyleBackColor = true;
            this.btnNewPerson.Click += new System.EventHandler(this.btnNewPerson_Click);
            // 
            // lblExistingPerson
            // 
            this.lblExistingPerson.AutoSize = true;
            this.lblExistingPerson.Location = new System.Drawing.Point(46, 378);
            this.lblExistingPerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExistingPerson.Name = "lblExistingPerson";
            this.lblExistingPerson.Size = new System.Drawing.Size(117, 20);
            this.lblExistingPerson.TabIndex = 32;
            this.lblExistingPerson.Text = "Existing People";
            // 
            // lsbxExistingPeople
            // 
            this.lsbxExistingPeople.FormattingEnabled = true;
            this.lsbxExistingPeople.ItemHeight = 20;
            this.lsbxExistingPeople.Location = new System.Drawing.Point(51, 408);
            this.lsbxExistingPeople.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lsbxExistingPeople.Name = "lsbxExistingPeople";
            this.lsbxExistingPeople.Size = new System.Drawing.Size(334, 244);
            this.lsbxExistingPeople.TabIndex = 31;
            this.lsbxExistingPeople.SelectedIndexChanged += new System.EventHandler(this.lsbxExistingPeople_SelectedIndexChanged);
            // 
            // btnPerson
            // 
            this.btnPerson.Enabled = false;
            this.btnPerson.Location = new System.Drawing.Point(51, 302);
            this.btnPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(336, 35);
            this.btnPerson.TabIndex = 30;
            this.btnPerson.Text = "Person";
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(160, 255);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 26);
            this.txtEmail.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(46, 260);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 20);
            this.label20.TabIndex = 28;
            this.label20.Text = "Email";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(160, 212);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(224, 26);
            this.txtTelephone.TabIndex = 27;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(46, 217);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 20);
            this.label21.TabIndex = 26;
            this.label21.Text = "Telephone";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(160, 134);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(224, 26);
            this.dtpDOB.TabIndex = 25;
            // 
            // txtCellphone
            // 
            this.txtCellphone.Location = new System.Drawing.Point(160, 171);
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(224, 26);
            this.txtCellphone.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(46, 178);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 20);
            this.label22.TabIndex = 23;
            this.label22.Text = "Cellphone";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(46, 137);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 20);
            this.label23.TabIndex = 22;
            this.label23.Text = "Date of Birth";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(160, 89);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(224, 26);
            this.txtSurname.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(224, 26);
            this.txtName.TabIndex = 20;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(46, 94);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 20);
            this.label24.TabIndex = 19;
            this.label24.Text = "Surname";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(46, 57);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 20);
            this.label25.TabIndex = 18;
            this.label25.Text = "First name";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(24, 69);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(183, 20);
            this.lblTask.TabIndex = 40;
            this.lblTask.Text = "Choose Client to Update";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1275, 38);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(202, 51);
            this.btnBack.TabIndex = 36;
            this.btnBack.Text = "Return To Call Centre";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblClientMaintenance
            // 
            this.lblClientMaintenance.AutoSize = true;
            this.lblClientMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientMaintenance.Location = new System.Drawing.Point(634, 9);
            this.lblClientMaintenance.Name = "lblClientMaintenance";
            this.lblClientMaintenance.Size = new System.Drawing.Size(278, 32);
            this.lblClientMaintenance.TabIndex = 34;
            this.lblClientMaintenance.Text = "Client Maintenance";
            // 
            // cbxChooseClient
            // 
            this.cbxChooseClient.FormattingEnabled = true;
            this.cbxChooseClient.Location = new System.Drawing.Point(234, 65);
            this.cbxChooseClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxChooseClient.Name = "cbxChooseClient";
            this.cbxChooseClient.Size = new System.Drawing.Size(206, 28);
            this.cbxChooseClient.TabIndex = 49;
            this.cbxChooseClient.SelectedIndexChanged += new System.EventHandler(this.cbxChooseClient_SelectedIndexChanged);
            // 
            // ClientMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 888);
            this.Controls.Add(this.cbxChooseClient);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grbPerson);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblClientMaintenance);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClientMaintenance";
            this.Text = "Client Maintenance";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Contract.ResumeLayout(false);
            this.grbBPeople.ResumeLayout(false);
            this.grbBPeople.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostalCode)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.grbPerson.ResumeLayout(false);
            this.grbPerson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.Label lblBusinessName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxCurentContract;
        private System.Windows.Forms.GroupBox grbPerson;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxProvince;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtCellphone;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RadioButton rbtnBusiness;
        private System.Windows.Forms.RadioButton rbtnIndvidual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblClientMaintenance;
        private System.Windows.Forms.ListBox lsbxBusinessPeople;
        private System.Windows.Forms.GroupBox grbBPeople;
        private System.Windows.Forms.ComboBox cbxChooseClient;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.ComboBox cbxClientPerson;
        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Label lblExistingPerson;
        private System.Windows.Forms.ListBox lsbxExistingPeople;
        private System.Windows.Forms.Button btnModifyPerson;
        private System.Windows.Forms.Button btnAddToBP;
        private System.Windows.Forms.Button btnNewPerson;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label lblClientType;
        private System.Windows.Forms.ListBox lsbxPreviousContracts;
        private System.Windows.Forms.Button btnCM;
        private ArrowlessNumericUpDown nudPostalCode;
        private System.Windows.Forms.GroupBox Contract;
    }
}