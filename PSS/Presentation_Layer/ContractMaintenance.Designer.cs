
namespace PSS.Presentation_Layer
{
    partial class ContractMaintenance
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
            this.gbxCreateModifyServices = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rbModifyService = new System.Windows.Forms.RadioButton();
            this.rbCreateService = new System.Windows.Forms.RadioButton();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.cbxServiceType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmService = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtServiceDescription = new System.Windows.Forms.TextBox();
            this.txtServiceType = new System.Windows.Forms.Label();
            this.cbxServiceChange = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tcContractMaintance = new System.Windows.Forms.TabControl();
            this.tpContracts = new System.Windows.Forms.TabPage();
            this.btnNewContract = new System.Windows.Forms.Button();
            this.btnStopContract = new System.Windows.Forms.Button();
            this.grbxContractInfo = new System.Windows.Forms.GroupBox();
            this.lsbxCurrentService = new System.Windows.Forms.ListBox();
            this.numDuration = new PSS.Presentation_Layer.ArrowlessNumericUpDown();
            this.nudMonthlyFee = new PSS.Presentation_Layer.ArrowlessNumericUpDown();
            this.grbxServSLA = new System.Windows.Forms.GroupBox();
            this.nudSpecificQuanity = new System.Windows.Forms.NumericUpDown();
            this.rbSpecifiedQuantity = new System.Windows.Forms.RadioButton();
            this.rbUnlimited = new System.Windows.Forms.RadioButton();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.rtbAgreement = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAddServiceToContract = new System.Windows.Forms.Button();
            this.lblServices = new System.Windows.Forms.Label();
            this.cbxContractService = new System.Windows.Forms.ComboBox();
            this.btnConfirmContract = new System.Windows.Forms.Button();
            this.lblCotractName = new System.Windows.Forms.Label();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.lblCurentServs = new System.Windows.Forms.Label();
            this.btnRemoveCurrentService = new System.Windows.Forms.Button();
            this.lblMonthlyFee = new System.Windows.Forms.Label();
            this.lblServiceLevel = new System.Windows.Forms.Label();
            this.cbxContractSL = new System.Windows.Forms.ComboBox();
            this.lblContractDuration = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpContractEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpContractStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.cbxAllContracts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpService = new System.Windows.Forms.TabPage();
            this.grbxWho = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxServiceForSL = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tpPerformance = new System.Windows.Forms.TabPage();
            this.lsbxContracts = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.rtbPerformance = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rtbContractDetails = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbxCreateModifyServices.SuspendLayout();
            this.tcContractMaintance.SuspendLayout();
            this.tpContracts.SuspendLayout();
            this.grbxContractInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonthlyFee)).BeginInit();
            this.grbxServSLA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecificQuanity)).BeginInit();
            this.tpService.SuspendLayout();
            this.grbxWho.SuspendLayout();
            this.tpPerformance.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCreateModifyServices
            // 
            this.gbxCreateModifyServices.Controls.Add(this.label18);
            this.gbxCreateModifyServices.Controls.Add(this.rbModifyService);
            this.gbxCreateModifyServices.Controls.Add(this.rbCreateService);
            this.gbxCreateModifyServices.Controls.Add(this.txtServiceName);
            this.gbxCreateModifyServices.Controls.Add(this.cbxServiceType);
            this.gbxCreateModifyServices.Controls.Add(this.label2);
            this.gbxCreateModifyServices.Controls.Add(this.btnConfirmService);
            this.gbxCreateModifyServices.Controls.Add(this.label9);
            this.gbxCreateModifyServices.Controls.Add(this.txtServiceDescription);
            this.gbxCreateModifyServices.Controls.Add(this.txtServiceType);
            this.gbxCreateModifyServices.Controls.Add(this.cbxServiceChange);
            this.gbxCreateModifyServices.Controls.Add(this.label6);
            this.gbxCreateModifyServices.Location = new System.Drawing.Point(16, 10);
            this.gbxCreateModifyServices.Margin = new System.Windows.Forms.Padding(1);
            this.gbxCreateModifyServices.Name = "gbxCreateModifyServices";
            this.gbxCreateModifyServices.Padding = new System.Windows.Forms.Padding(1);
            this.gbxCreateModifyServices.Size = new System.Drawing.Size(235, 179);
            this.gbxCreateModifyServices.TabIndex = 47;
            this.gbxCreateModifyServices.TabStop = false;
            this.gbxCreateModifyServices.Text = "Create or Modify Services";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 25);
            this.label18.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Operation";
            // 
            // rbModifyService
            // 
            this.rbModifyService.AutoSize = true;
            this.rbModifyService.Location = new System.Drawing.Point(150, 23);
            this.rbModifyService.Margin = new System.Windows.Forms.Padding(2);
            this.rbModifyService.Name = "rbModifyService";
            this.rbModifyService.Size = new System.Drawing.Size(56, 17);
            this.rbModifyService.TabIndex = 38;
            this.rbModifyService.TabStop = true;
            this.rbModifyService.Text = "Modify";
            this.rbModifyService.UseVisualStyleBackColor = true;
            this.rbModifyService.CheckedChanged += new System.EventHandler(this.rbModifyService_CheckedChanged);
            // 
            // rbCreateService
            // 
            this.rbCreateService.AutoSize = true;
            this.rbCreateService.Location = new System.Drawing.Point(90, 23);
            this.rbCreateService.Margin = new System.Windows.Forms.Padding(2);
            this.rbCreateService.Name = "rbCreateService";
            this.rbCreateService.Size = new System.Drawing.Size(56, 17);
            this.rbCreateService.TabIndex = 37;
            this.rbCreateService.TabStop = true;
            this.rbCreateService.Text = "Create";
            this.rbCreateService.UseVisualStyleBackColor = true;
            this.rbCreateService.CheckedChanged += new System.EventHandler(this.rbCreateService_CheckedChanged);
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(92, 70);
            this.txtServiceName.Margin = new System.Windows.Forms.Padding(1);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(132, 20);
            this.txtServiceName.TabIndex = 33;
            // 
            // cbxServiceType
            // 
            this.cbxServiceType.FormattingEnabled = true;
            this.cbxServiceType.Location = new System.Drawing.Point(92, 92);
            this.cbxServiceType.Margin = new System.Windows.Forms.Padding(1);
            this.cbxServiceType.Name = "cbxServiceType";
            this.cbxServiceType.Size = new System.Drawing.Size(132, 21);
            this.cbxServiceType.TabIndex = 36;
            this.cbxServiceType.Text = "Choose or type...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Service Name";
            // 
            // btnConfirmService
            // 
            this.btnConfirmService.Enabled = false;
            this.btnConfirmService.Location = new System.Drawing.Point(49, 150);
            this.btnConfirmService.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmService.Name = "btnConfirmService";
            this.btnConfirmService.Size = new System.Drawing.Size(115, 21);
            this.btnConfirmService.TabIndex = 34;
            this.btnConfirmService.Text = "Confirm Service";
            this.btnConfirmService.UseVisualStyleBackColor = true;
            this.btnConfirmService.Click += new System.EventHandler(this.btnConfirmService_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 119);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Description";
            // 
            // txtServiceDescription
            // 
            this.txtServiceDescription.Location = new System.Drawing.Point(92, 116);
            this.txtServiceDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtServiceDescription.Name = "txtServiceDescription";
            this.txtServiceDescription.Size = new System.Drawing.Size(132, 20);
            this.txtServiceDescription.TabIndex = 34;
            // 
            // txtServiceType
            // 
            this.txtServiceType.AutoSize = true;
            this.txtServiceType.Location = new System.Drawing.Point(46, 95);
            this.txtServiceType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.Size = new System.Drawing.Size(31, 13);
            this.txtServiceType.TabIndex = 32;
            this.txtServiceType.Text = "Type";
            // 
            // cbxServiceChange
            // 
            this.cbxServiceChange.FormattingEnabled = true;
            this.cbxServiceChange.Items.AddRange(new object[] {
            "Gauteng",
            "Free State",
            "North West"});
            this.cbxServiceChange.Location = new System.Drawing.Point(92, 47);
            this.cbxServiceChange.Margin = new System.Windows.Forms.Padding(1);
            this.cbxServiceChange.Name = "cbxServiceChange";
            this.cbxServiceChange.Size = new System.Drawing.Size(132, 21);
            this.cbxServiceChange.TabIndex = 24;
            this.cbxServiceChange.Text = "Choose or type...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Service";
            // 
            // tcContractMaintance
            // 
            this.tcContractMaintance.Controls.Add(this.tpContracts);
            this.tcContractMaintance.Controls.Add(this.tpService);
            this.tcContractMaintance.Controls.Add(this.tpPerformance);
            this.tcContractMaintance.Location = new System.Drawing.Point(12, 41);
            this.tcContractMaintance.Name = "tcContractMaintance";
            this.tcContractMaintance.SelectedIndex = 0;
            this.tcContractMaintance.Size = new System.Drawing.Size(513, 373);
            this.tcContractMaintance.TabIndex = 48;
            // 
            // tpContracts
            // 
            this.tpContracts.Controls.Add(this.btnNewContract);
            this.tpContracts.Controls.Add(this.btnStopContract);
            this.tpContracts.Controls.Add(this.grbxContractInfo);
            this.tpContracts.Controls.Add(this.cbxAllContracts);
            this.tpContracts.Controls.Add(this.label1);
            this.tpContracts.Location = new System.Drawing.Point(4, 22);
            this.tpContracts.Name = "tpContracts";
            this.tpContracts.Padding = new System.Windows.Forms.Padding(2);
            this.tpContracts.Size = new System.Drawing.Size(505, 347);
            this.tpContracts.TabIndex = 0;
            this.tpContracts.Text = "Contracts";
            this.tpContracts.UseVisualStyleBackColor = true;
            // 
            // btnNewContract
            // 
            this.btnNewContract.Location = new System.Drawing.Point(329, 23);
            this.btnNewContract.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewContract.Name = "btnNewContract";
            this.btnNewContract.Size = new System.Drawing.Size(91, 21);
            this.btnNewContract.TabIndex = 56;
            this.btnNewContract.Text = "Create New Contract";
            this.btnNewContract.UseVisualStyleBackColor = true;
            this.btnNewContract.Click += new System.EventHandler(this.btnNewContract_Click);
            // 
            // btnStopContract
            // 
            this.btnStopContract.Location = new System.Drawing.Point(221, 23);
            this.btnStopContract.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopContract.Name = "btnStopContract";
            this.btnStopContract.Size = new System.Drawing.Size(91, 21);
            this.btnStopContract.TabIndex = 55;
            this.btnStopContract.Text = "Stop Contract";
            this.btnStopContract.UseVisualStyleBackColor = true;
            this.btnStopContract.Click += new System.EventHandler(this.btnStopContract_Click);
            // 
            // grbxContractInfo
            // 
            this.grbxContractInfo.Controls.Add(this.lsbxCurrentService);
            this.grbxContractInfo.Controls.Add(this.numDuration);
            this.grbxContractInfo.Controls.Add(this.nudMonthlyFee);
            this.grbxContractInfo.Controls.Add(this.grbxServSLA);
            this.grbxContractInfo.Controls.Add(this.btnConfirmContract);
            this.grbxContractInfo.Controls.Add(this.lblCotractName);
            this.grbxContractInfo.Controls.Add(this.txtContractName);
            this.grbxContractInfo.Controls.Add(this.lblCurentServs);
            this.grbxContractInfo.Controls.Add(this.btnRemoveCurrentService);
            this.grbxContractInfo.Controls.Add(this.lblMonthlyFee);
            this.grbxContractInfo.Controls.Add(this.lblServiceLevel);
            this.grbxContractInfo.Controls.Add(this.cbxContractSL);
            this.grbxContractInfo.Controls.Add(this.lblContractDuration);
            this.grbxContractInfo.Controls.Add(this.lblStartDate);
            this.grbxContractInfo.Controls.Add(this.dtpContractEnd);
            this.grbxContractInfo.Controls.Add(this.dtpContractStart);
            this.grbxContractInfo.Controls.Add(this.lblEndDate);
            this.grbxContractInfo.Enabled = false;
            this.grbxContractInfo.Location = new System.Drawing.Point(19, 67);
            this.grbxContractInfo.Name = "grbxContractInfo";
            this.grbxContractInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grbxContractInfo.Size = new System.Drawing.Size(476, 274);
            this.grbxContractInfo.TabIndex = 46;
            this.grbxContractInfo.TabStop = false;
            this.grbxContractInfo.Text = "Contract Information";
            // 
            // lsbxCurrentService
            // 
            this.lsbxCurrentService.FormattingEnabled = true;
            this.lsbxCurrentService.Location = new System.Drawing.Point(224, 49);
            this.lsbxCurrentService.Name = "lsbxCurrentService";
            this.lsbxCurrentService.Size = new System.Drawing.Size(247, 43);
            this.lsbxCurrentService.TabIndex = 58;
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(125, 120);
            this.numDuration.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(82, 20);
            this.numDuration.TabIndex = 57;
            // 
            // nudMonthlyFee
            // 
            this.nudMonthlyFee.DecimalPlaces = 2;
            this.nudMonthlyFee.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMonthlyFee.Location = new System.Drawing.Point(87, 146);
            this.nudMonthlyFee.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMonthlyFee.Name = "nudMonthlyFee";
            this.nudMonthlyFee.Size = new System.Drawing.Size(120, 20);
            this.nudMonthlyFee.TabIndex = 56;
            // 
            // grbxServSLA
            // 
            this.grbxServSLA.Controls.Add(this.nudSpecificQuanity);
            this.grbxServSLA.Controls.Add(this.rbSpecifiedQuantity);
            this.grbxServSLA.Controls.Add(this.rbUnlimited);
            this.grbxServSLA.Controls.Add(this.lblQuantity);
            this.grbxServSLA.Controls.Add(this.rtbAgreement);
            this.grbxServSLA.Controls.Add(this.label14);
            this.grbxServSLA.Controls.Add(this.btnAddServiceToContract);
            this.grbxServSLA.Controls.Add(this.lblServices);
            this.grbxServSLA.Controls.Add(this.cbxContractService);
            this.grbxServSLA.Location = new System.Drawing.Point(223, 98);
            this.grbxServSLA.Margin = new System.Windows.Forms.Padding(2);
            this.grbxServSLA.Name = "grbxServSLA";
            this.grbxServSLA.Padding = new System.Windows.Forms.Padding(2);
            this.grbxServSLA.Size = new System.Drawing.Size(248, 172);
            this.grbxServSLA.TabIndex = 55;
            this.grbxServSLA.TabStop = false;
            this.grbxServSLA.Text = "Contract Services and SAL";
            // 
            // nudSpecificQuanity
            // 
            this.nudSpecificQuanity.Enabled = false;
            this.nudSpecificQuanity.Location = new System.Drawing.Point(128, 113);
            this.nudSpecificQuanity.Margin = new System.Windows.Forms.Padding(2);
            this.nudSpecificQuanity.Name = "nudSpecificQuanity";
            this.nudSpecificQuanity.Size = new System.Drawing.Size(43, 20);
            this.nudSpecificQuanity.TabIndex = 57;
            // 
            // rbSpecifiedQuantity
            // 
            this.rbSpecifiedQuantity.AutoSize = true;
            this.rbSpecifiedQuantity.Location = new System.Drawing.Point(61, 113);
            this.rbSpecifiedQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.rbSpecifiedQuantity.Name = "rbSpecifiedQuantity";
            this.rbSpecifiedQuantity.Size = new System.Drawing.Size(63, 17);
            this.rbSpecifiedQuantity.TabIndex = 56;
            this.rbSpecifiedQuantity.TabStop = true;
            this.rbSpecifiedQuantity.Text = "Specific";
            this.rbSpecifiedQuantity.UseVisualStyleBackColor = true;
            this.rbSpecifiedQuantity.CheckedChanged += new System.EventHandler(this.rbSpecifiedQuantity_CheckedChanged);
            // 
            // rbUnlimited
            // 
            this.rbUnlimited.AutoSize = true;
            this.rbUnlimited.Location = new System.Drawing.Point(61, 92);
            this.rbUnlimited.Margin = new System.Windows.Forms.Padding(2);
            this.rbUnlimited.Name = "rbUnlimited";
            this.rbUnlimited.Size = new System.Drawing.Size(68, 17);
            this.rbUnlimited.TabIndex = 55;
            this.rbUnlimited.TabStop = true;
            this.rbUnlimited.Text = "Unlimited";
            this.rbUnlimited.UseVisualStyleBackColor = true;
            this.rbUnlimited.CheckedChanged += new System.EventHandler(this.rbUnlimited_CheckedChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(11, 94);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 54;
            this.lblQuantity.Text = "Quantity";
            // 
            // rtbAgreement
            // 
            this.rtbAgreement.Location = new System.Drawing.Point(12, 56);
            this.rtbAgreement.Margin = new System.Windows.Forms.Padding(2);
            this.rtbAgreement.Name = "rtbAgreement";
            this.rtbAgreement.Size = new System.Drawing.Size(220, 32);
            this.rtbAgreement.TabIndex = 53;
            this.rtbAgreement.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 42);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Agreement";
            // 
            // btnAddServiceToContract
            // 
            this.btnAddServiceToContract.Location = new System.Drawing.Point(61, 137);
            this.btnAddServiceToContract.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddServiceToContract.Name = "btnAddServiceToContract";
            this.btnAddServiceToContract.Size = new System.Drawing.Size(110, 21);
            this.btnAddServiceToContract.TabIndex = 51;
            this.btnAddServiceToContract.Text = "Add Service to contract";
            this.btnAddServiceToContract.UseVisualStyleBackColor = true;
            this.btnAddServiceToContract.Click += new System.EventHandler(this.btnAddServiceToContract_Click);
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(10, 23);
            this.lblServices.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(43, 13);
            this.lblServices.TabIndex = 49;
            this.lblServices.Text = "Service";
            // 
            // cbxContractService
            // 
            this.cbxContractService.FormattingEnabled = true;
            this.cbxContractService.Location = new System.Drawing.Point(74, 21);
            this.cbxContractService.Margin = new System.Windows.Forms.Padding(1);
            this.cbxContractService.Name = "cbxContractService";
            this.cbxContractService.Size = new System.Drawing.Size(158, 21);
            this.cbxContractService.TabIndex = 50;
            this.cbxContractService.Text = "Choose...";
            // 
            // btnConfirmContract
            // 
            this.btnConfirmContract.Location = new System.Drawing.Point(55, 211);
            this.btnConfirmContract.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmContract.Name = "btnConfirmContract";
            this.btnConfirmContract.Size = new System.Drawing.Size(91, 21);
            this.btnConfirmContract.TabIndex = 54;
            this.btnConfirmContract.Text = "Confirm Contract";
            this.btnConfirmContract.UseVisualStyleBackColor = true;
            this.btnConfirmContract.Click += new System.EventHandler(this.btnConfirmContract_Click);
            // 
            // lblCotractName
            // 
            this.lblCotractName.AutoSize = true;
            this.lblCotractName.Location = new System.Drawing.Point(13, 28);
            this.lblCotractName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCotractName.Name = "lblCotractName";
            this.lblCotractName.Size = new System.Drawing.Size(78, 13);
            this.lblCotractName.TabIndex = 34;
            this.lblCotractName.Text = "Contract Name";
            // 
            // txtContractName
            // 
            this.txtContractName.Location = new System.Drawing.Point(93, 25);
            this.txtContractName.Margin = new System.Windows.Forms.Padding(1);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(114, 20);
            this.txtContractName.TabIndex = 35;
            // 
            // lblCurentServs
            // 
            this.lblCurentServs.AutoSize = true;
            this.lblCurentServs.Location = new System.Drawing.Point(220, 28);
            this.lblCurentServs.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCurentServs.Name = "lblCurentServs";
            this.lblCurentServs.Size = new System.Drawing.Size(128, 13);
            this.lblCurentServs.TabIndex = 48;
            this.lblCurentServs.Text = "Current Contract Services";
            // 
            // btnRemoveCurrentService
            // 
            this.btnRemoveCurrentService.Location = new System.Drawing.Point(352, 23);
            this.btnRemoveCurrentService.Name = "btnRemoveCurrentService";
            this.btnRemoveCurrentService.Size = new System.Drawing.Size(119, 22);
            this.btnRemoveCurrentService.TabIndex = 48;
            this.btnRemoveCurrentService.Text = "Remove Selected";
            this.btnRemoveCurrentService.UseVisualStyleBackColor = true;
            this.btnRemoveCurrentService.Click += new System.EventHandler(this.btnRemoveCurrentService_Click);
            // 
            // lblMonthlyFee
            // 
            this.lblMonthlyFee.AutoSize = true;
            this.lblMonthlyFee.Location = new System.Drawing.Point(13, 149);
            this.lblMonthlyFee.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMonthlyFee.Name = "lblMonthlyFee";
            this.lblMonthlyFee.Size = new System.Drawing.Size(65, 13);
            this.lblMonthlyFee.TabIndex = 44;
            this.lblMonthlyFee.Text = "Monthly Fee";
            // 
            // lblServiceLevel
            // 
            this.lblServiceLevel.AutoSize = true;
            this.lblServiceLevel.Location = new System.Drawing.Point(13, 51);
            this.lblServiceLevel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblServiceLevel.Name = "lblServiceLevel";
            this.lblServiceLevel.Size = new System.Drawing.Size(72, 13);
            this.lblServiceLevel.TabIndex = 36;
            this.lblServiceLevel.Text = "Service Level";
            // 
            // cbxContractSL
            // 
            this.cbxContractSL.FormattingEnabled = true;
            this.cbxContractSL.Items.AddRange(new object[] {
            "1- Peasant",
            "2- Commoner",
            "3- Noble",
            "4- Feudal lord"});
            this.cbxContractSL.Location = new System.Drawing.Point(93, 48);
            this.cbxContractSL.Margin = new System.Windows.Forms.Padding(1);
            this.cbxContractSL.Name = "cbxContractSL";
            this.cbxContractSL.Size = new System.Drawing.Size(114, 21);
            this.cbxContractSL.TabIndex = 37;
            this.cbxContractSL.Text = "Choose...";
            // 
            // lblContractDuration
            // 
            this.lblContractDuration.AutoSize = true;
            this.lblContractDuration.Location = new System.Drawing.Point(13, 122);
            this.lblContractDuration.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblContractDuration.Name = "lblContractDuration";
            this.lblContractDuration.Size = new System.Drawing.Size(108, 13);
            this.lblContractDuration.TabIndex = 42;
            this.lblContractDuration.Text = "Contract Duration (M)";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(13, 75);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(81, 13);
            this.lblStartDate.TabIndex = 38;
            this.lblStartDate.Text = "Offer Start Date";
            // 
            // dtpContractEnd
            // 
            this.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractEnd.Location = new System.Drawing.Point(105, 94);
            this.dtpContractEnd.Margin = new System.Windows.Forms.Padding(1);
            this.dtpContractEnd.Name = "dtpContractEnd";
            this.dtpContractEnd.Size = new System.Drawing.Size(102, 20);
            this.dtpContractEnd.TabIndex = 41;
            // 
            // dtpContractStart
            // 
            this.dtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractStart.Location = new System.Drawing.Point(105, 72);
            this.dtpContractStart.Margin = new System.Windows.Forms.Padding(1);
            this.dtpContractStart.Name = "dtpContractStart";
            this.dtpContractStart.Size = new System.Drawing.Size(102, 20);
            this.dtpContractStart.TabIndex = 39;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(13, 98);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(78, 13);
            this.lblEndDate.TabIndex = 40;
            this.lblEndDate.Text = "Offer End Date";
            // 
            // cbxAllContracts
            // 
            this.cbxAllContracts.FormattingEnabled = true;
            this.cbxAllContracts.Items.AddRange(new object[] {
            "Gauteng",
            "Free State",
            "North West"});
            this.cbxAllContracts.Location = new System.Drawing.Point(85, 24);
            this.cbxAllContracts.Margin = new System.Windows.Forms.Padding(1);
            this.cbxAllContracts.Name = "cbxAllContracts";
            this.cbxAllContracts.Size = new System.Drawing.Size(118, 21);
            this.cbxAllContracts.TabIndex = 26;
            this.cbxAllContracts.Text = "Choose...";
            this.cbxAllContracts.SelectedIndexChanged += new System.EventHandler(this.cbxAllContracts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "All Contracts";
            // 
            // tpService
            // 
            this.tpService.Controls.Add(this.grbxWho);
            this.tpService.Controls.Add(this.gbxCreateModifyServices);
            this.tpService.Location = new System.Drawing.Point(4, 22);
            this.tpService.Name = "tpService";
            this.tpService.Padding = new System.Windows.Forms.Padding(2);
            this.tpService.Size = new System.Drawing.Size(505, 347);
            this.tpService.TabIndex = 1;
            this.tpService.Text = "Services";
            this.tpService.UseVisualStyleBackColor = true;
            // 
            // grbxWho
            // 
            this.grbxWho.Controls.Add(this.button6);
            this.grbxWho.Controls.Add(this.button5);
            this.grbxWho.Controls.Add(this.button4);
            this.grbxWho.Controls.Add(this.button2);
            this.grbxWho.Controls.Add(this.cbxServiceForSL);
            this.grbxWho.Controls.Add(this.label3);
            this.grbxWho.Location = new System.Drawing.Point(16, 202);
            this.grbxWho.Margin = new System.Windows.Forms.Padding(1);
            this.grbxWho.Name = "grbxWho";
            this.grbxWho.Padding = new System.Windows.Forms.Padding(2);
            this.grbxWho.Size = new System.Drawing.Size(375, 121);
            this.grbxWho.TabIndex = 48;
            this.grbxWho.TabStop = false;
            this.grbxWho.Text = "wut is this?";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(29, 69);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 32);
            this.button6.TabIndex = 36;
            this.button6.Text = "Confirm";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(259, 69);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 32);
            this.button5.TabIndex = 50;
            this.button5.Text = "Lower Priority";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(259, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 32);
            this.button4.TabIndex = 49;
            this.button4.Text = "Raise Priority";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 32);
            this.button2.TabIndex = 25;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbxServiceForSL
            // 
            this.cbxServiceForSL.FormattingEnabled = true;
            this.cbxServiceForSL.Items.AddRange(new object[] {
            "Peasant",
            "Commoner",
            "Noble",
            "Feudal lord"});
            this.cbxServiceForSL.Location = new System.Drawing.Point(72, 23);
            this.cbxServiceForSL.Margin = new System.Windows.Forms.Padding(1);
            this.cbxServiceForSL.Name = "cbxServiceForSL";
            this.cbxServiceForSL.Size = new System.Drawing.Size(114, 21);
            this.cbxServiceForSL.TabIndex = 24;
            this.cbxServiceForSL.Text = "Choose...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Service";
            // 
            // tpPerformance
            // 
            this.tpPerformance.Controls.Add(this.lsbxContracts);
            this.tpPerformance.Controls.Add(this.label17);
            this.tpPerformance.Controls.Add(this.rtbPerformance);
            this.tpPerformance.Controls.Add(this.label15);
            this.tpPerformance.Controls.Add(this.rtbContractDetails);
            this.tpPerformance.Controls.Add(this.label16);
            this.tpPerformance.Location = new System.Drawing.Point(4, 22);
            this.tpPerformance.Name = "tpPerformance";
            this.tpPerformance.Size = new System.Drawing.Size(505, 347);
            this.tpPerformance.TabIndex = 2;
            this.tpPerformance.Text = "Performance";
            this.tpPerformance.UseVisualStyleBackColor = true;
            // 
            // lsbxContracts
            // 
            this.lsbxContracts.FormattingEnabled = true;
            this.lsbxContracts.Location = new System.Drawing.Point(21, 32);
            this.lsbxContracts.Name = "lsbxContracts";
            this.lsbxContracts.Size = new System.Drawing.Size(430, 95);
            this.lsbxContracts.TabIndex = 13;
            this.lsbxContracts.SelectedIndexChanged += new System.EventHandler(this.lsbxContracts_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 199);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Contract Performance";
            // 
            // rtbPerformance
            // 
            this.rtbPerformance.Location = new System.Drawing.Point(21, 215);
            this.rtbPerformance.Name = "rtbPerformance";
            this.rtbPerformance.Size = new System.Drawing.Size(430, 116);
            this.rtbPerformance.TabIndex = 11;
            this.rtbPerformance.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Contract Details";
            // 
            // rtbContractDetails
            // 
            this.rtbContractDetails.Location = new System.Drawing.Point(21, 148);
            this.rtbContractDetails.Name = "rtbContractDetails";
            this.rtbContractDetails.Size = new System.Drawing.Size(430, 48);
            this.rtbContractDetails.TabIndex = 9;
            this.rtbContractDetails.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "All Contracts";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(394, 11);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 25);
            this.btnBack.TabIndex = 49;
            this.btnBack.Text = "Return to Call Centre";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ContractMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 419);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tcContractMaintance);
            this.Name = "ContractMaintenance";
            this.Text = "ContractMaintenance";
            this.gbxCreateModifyServices.ResumeLayout(false);
            this.gbxCreateModifyServices.PerformLayout();
            this.tcContractMaintance.ResumeLayout(false);
            this.tpContracts.ResumeLayout(false);
            this.tpContracts.PerformLayout();
            this.grbxContractInfo.ResumeLayout(false);
            this.grbxContractInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonthlyFee)).EndInit();
            this.grbxServSLA.ResumeLayout(false);
            this.grbxServSLA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecificQuanity)).EndInit();
            this.tpService.ResumeLayout(false);
            this.grbxWho.ResumeLayout(false);
            this.grbxWho.PerformLayout();
            this.tpPerformance.ResumeLayout(false);
            this.tpPerformance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCreateModifyServices;
        private System.Windows.Forms.ComboBox cbxServiceChange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtServiceDescription;
        private System.Windows.Forms.Label txtServiceType;
        private System.Windows.Forms.TabControl tcContractMaintance;
        private System.Windows.Forms.TabPage tpContracts;
        private System.Windows.Forms.TabPage tpService;
        private System.Windows.Forms.GroupBox grbxWho;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxServiceForSL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmService;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbxContractSL;
        private System.Windows.Forms.Label lblServiceLevel;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.Label lblCotractName;
        private System.Windows.Forms.ComboBox cbxAllContracts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpContractStart;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblMonthlyFee;
        private System.Windows.Forms.Label lblContractDuration;
        private System.Windows.Forms.DateTimePicker dtpContractEnd;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.GroupBox grbxContractInfo;
        private System.Windows.Forms.Button btnRemoveCurrentService;
        private System.Windows.Forms.Label lblCurentServs;
        private System.Windows.Forms.Button btnAddServiceToContract;
        private System.Windows.Forms.ComboBox cbxContractService;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Button btnNewContract;
        private System.Windows.Forms.Button btnStopContract;
        private System.Windows.Forms.Button btnConfirmContract;
        private System.Windows.Forms.RichTextBox rtbAgreement;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tpPerformance;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtbContractDetails;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox rtbPerformance;
        private System.Windows.Forms.GroupBox grbxServSLA;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rbModifyService;
        private System.Windows.Forms.RadioButton rbCreateService;
        private System.Windows.Forms.ComboBox cbxServiceType;
        private System.Windows.Forms.NumericUpDown nudSpecificQuanity;
        private System.Windows.Forms.RadioButton rbSpecifiedQuantity;
        private System.Windows.Forms.RadioButton rbUnlimited;
        private System.Windows.Forms.Label lblQuantity;
        private ArrowlessNumericUpDown numDuration;
        private ArrowlessNumericUpDown nudMonthlyFee;
        private System.Windows.Forms.ListBox lsbxContracts;
        private System.Windows.Forms.ListBox lsbxCurrentService;
    }
}