
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
            this.label1 = new System.Windows.Forms.Label();
            this.tcTask = new System.Windows.Forms.TabControl();
            this.tpCreate = new System.Windows.Forms.TabPage();
            this.lblCurentClient = new System.Windows.Forms.Label();
            this.grbCreate = new System.Windows.Forms.GroupBox();
            this.rtbSLDetails = new System.Windows.Forms.RichTextBox();
            this.lsbxUnclaimedServiceRequests = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateJob = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.cbxClient = new System.Windows.Forms.ComboBox();
            this.tpModify = new System.Windows.Forms.TabPage();
            this.lsbxActiveTasks = new System.Windows.Forms.ListBox();
            this.grbModify = new System.Windows.Forms.GroupBox();
            this.gpbxAssignedTechnician = new System.Windows.Forms.GroupBox();
            this.btnReAssignTech = new System.Windows.Forms.Button();
            this.txtCurrentTech = new System.Windows.Forms.TextBox();
            this.lblCurrentTech = new System.Windows.Forms.Label();
            this.btnReAssignTask = new System.Windows.Forms.Button();
            this.lblTasks = new System.Windows.Forms.Label();
            this.tpTrack = new System.Windows.Forms.TabPage();
            this.tvTrack = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxSchedueledTask = new System.Windows.Forms.ComboBox();
            this.btnSubmitFeedback = new System.Windows.Forms.Button();
            this.lblTaskServiceRequest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbFeedbackNotes = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTechArrived = new System.Windows.Forms.Label();
            this.dtpActualTimeDep = new System.Windows.Forms.DateTimePicker();
            this.dtpActualTimeArrived = new System.Windows.Forms.DateTimePicker();
            this.lblTechDep = new System.Windows.Forms.Label();
            this.cbxReportStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.dtpDeparture = new System.Windows.Forms.DateTimePicker();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbTechDetails = new System.Windows.Forms.RichTextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lsbxAvailableTechnicians = new System.Windows.Forms.ListBox();
            this.grbxAvailableTechnicians = new System.Windows.Forms.GroupBox();
            this.grbTask = new System.Windows.Forms.GroupBox();
            this.dtpArival = new System.Windows.Forms.DateTimePicker();
            this.lblArival = new System.Windows.Forms.Label();
            this.txtTaskType = new System.Windows.Forms.TextBox();
            this.lblTaskType = new System.Windows.Forms.Label();
            this.tcTask.SuspendLayout();
            this.tpCreate.SuspendLayout();
            this.grbCreate.SuspendLayout();
            this.tpModify.SuspendLayout();
            this.grbModify.SuspendLayout();
            this.gpbxAssignedTechnician.SuspendLayout();
            this.tpTrack.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbxAvailableTechnicians.SuspendLayout();
            this.grbTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unclaimed Service Requests";
            // 
            // tcTask
            // 
            this.tcTask.Controls.Add(this.tpCreate);
            this.tcTask.Controls.Add(this.tpModify);
            this.tcTask.Controls.Add(this.tpTrack);
            this.tcTask.Controls.Add(this.tabPage1);
            this.tcTask.Location = new System.Drawing.Point(12, 56);
            this.tcTask.Name = "tcTask";
            this.tcTask.SelectedIndex = 0;
            this.tcTask.Size = new System.Drawing.Size(570, 297);
            this.tcTask.TabIndex = 3;
            this.tcTask.SelectedIndexChanged += new System.EventHandler(this.tcTask_SelectedIndexChanged);
            // 
            // tpCreate
            // 
            this.tpCreate.Controls.Add(this.lblCurentClient);
            this.tpCreate.Controls.Add(this.grbCreate);
            this.tpCreate.Controls.Add(this.lblClient);
            this.tpCreate.Controls.Add(this.cbxClient);
            this.tpCreate.Location = new System.Drawing.Point(4, 22);
            this.tpCreate.Name = "tpCreate";
            this.tpCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreate.Size = new System.Drawing.Size(562, 271);
            this.tpCreate.TabIndex = 0;
            this.tpCreate.Text = "Create Task";
            this.tpCreate.UseVisualStyleBackColor = true;
            // 
            // lblCurentClient
            // 
            this.lblCurentClient.AutoSize = true;
            this.lblCurentClient.Location = new System.Drawing.Point(5, 47);
            this.lblCurentClient.Name = "lblCurentClient";
            this.lblCurentClient.Size = new System.Drawing.Size(70, 13);
            this.lblCurentClient.TabIndex = 34;
            this.lblCurentClient.Text = "Current Client";
            // 
            // grbCreate
            // 
            this.grbCreate.Controls.Add(this.label1);
            this.grbCreate.Controls.Add(this.rtbSLDetails);
            this.grbCreate.Controls.Add(this.lsbxUnclaimedServiceRequests);
            this.grbCreate.Controls.Add(this.label3);
            this.grbCreate.Controls.Add(this.btnCreateJob);
            this.grbCreate.Location = new System.Drawing.Point(6, 72);
            this.grbCreate.Name = "grbCreate";
            this.grbCreate.Size = new System.Drawing.Size(550, 193);
            this.grbCreate.TabIndex = 33;
            this.grbCreate.TabStop = false;
            this.grbCreate.Text = "Create";
            // 
            // rtbSLDetails
            // 
            this.rtbSLDetails.Location = new System.Drawing.Point(277, 42);
            this.rtbSLDetails.Name = "rtbSLDetails";
            this.rtbSLDetails.Size = new System.Drawing.Size(267, 95);
            this.rtbSLDetails.TabIndex = 4;
            this.rtbSLDetails.Text = "";
            // 
            // lsbxUnclaimedServiceRequests
            // 
            this.lsbxUnclaimedServiceRequests.FormattingEnabled = true;
            this.lsbxUnclaimedServiceRequests.Location = new System.Drawing.Point(9, 42);
            this.lsbxUnclaimedServiceRequests.Name = "lsbxUnclaimedServiceRequests";
            this.lsbxUnclaimedServiceRequests.Size = new System.Drawing.Size(262, 95);
            this.lsbxUnclaimedServiceRequests.TabIndex = 31;
            this.lsbxUnclaimedServiceRequests.SelectedIndexChanged += new System.EventHandler(this.lsbxUnclaimedServiceRequests_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Service Request Details";
            // 
            // btnCreateJob
            // 
            this.btnCreateJob.Location = new System.Drawing.Point(337, 143);
            this.btnCreateJob.Name = "btnCreateJob";
            this.btnCreateJob.Size = new System.Drawing.Size(207, 36);
            this.btnCreateJob.TabIndex = 8;
            this.btnCreateJob.Text = "Assign Task to selected Technician";
            this.btnCreateJob.UseVisualStyleBackColor = true;
            this.btnCreateJob.Click += new System.EventHandler(this.btnCreateJob_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(6, 3);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(72, 13);
            this.lblClient.TabIndex = 32;
            this.lblClient.Text = "Choose Client";
            // 
            // cbxClient
            // 
            this.cbxClient.Enabled = false;
            this.cbxClient.FormattingEnabled = true;
            this.cbxClient.Location = new System.Drawing.Point(5, 19);
            this.cbxClient.Name = "cbxClient";
            this.cbxClient.Size = new System.Drawing.Size(195, 21);
            this.cbxClient.TabIndex = 10;
            this.cbxClient.SelectedIndexChanged += new System.EventHandler(this.cbxClient_SelectedIndexChanged);
            // 
            // tpModify
            // 
            this.tpModify.Controls.Add(this.lsbxActiveTasks);
            this.tpModify.Controls.Add(this.grbModify);
            this.tpModify.Controls.Add(this.lblTasks);
            this.tpModify.Location = new System.Drawing.Point(4, 22);
            this.tpModify.Name = "tpModify";
            this.tpModify.Padding = new System.Windows.Forms.Padding(3);
            this.tpModify.Size = new System.Drawing.Size(562, 271);
            this.tpModify.TabIndex = 1;
            this.tpModify.Text = "Modify Task";
            this.tpModify.UseVisualStyleBackColor = true;
            // 
            // lsbxActiveTasks
            // 
            this.lsbxActiveTasks.FormattingEnabled = true;
            this.lsbxActiveTasks.Location = new System.Drawing.Point(9, 36);
            this.lsbxActiveTasks.Name = "lsbxActiveTasks";
            this.lsbxActiveTasks.Size = new System.Drawing.Size(547, 82);
            this.lsbxActiveTasks.TabIndex = 41;
            this.lsbxActiveTasks.SelectedIndexChanged += new System.EventHandler(this.lsbxTasks_SelectedIndexChanged);
            // 
            // grbModify
            // 
            this.grbModify.Controls.Add(this.gpbxAssignedTechnician);
            this.grbModify.Controls.Add(this.btnReAssignTask);
            this.grbModify.Location = new System.Drawing.Point(9, 124);
            this.grbModify.Name = "grbModify";
            this.grbModify.Size = new System.Drawing.Size(547, 141);
            this.grbModify.TabIndex = 40;
            this.grbModify.TabStop = false;
            this.grbModify.Text = "Modify";
            // 
            // gpbxAssignedTechnician
            // 
            this.gpbxAssignedTechnician.Controls.Add(this.btnReAssignTech);
            this.gpbxAssignedTechnician.Controls.Add(this.txtCurrentTech);
            this.gpbxAssignedTechnician.Controls.Add(this.lblCurrentTech);
            this.gpbxAssignedTechnician.Location = new System.Drawing.Point(10, 27);
            this.gpbxAssignedTechnician.Name = "gpbxAssignedTechnician";
            this.gpbxAssignedTechnician.Size = new System.Drawing.Size(328, 97);
            this.gpbxAssignedTechnician.TabIndex = 38;
            this.gpbxAssignedTechnician.TabStop = false;
            this.gpbxAssignedTechnician.Text = "Assigned Technician";
            // 
            // btnReAssignTech
            // 
            this.btnReAssignTech.Enabled = false;
            this.btnReAssignTech.Location = new System.Drawing.Point(67, 43);
            this.btnReAssignTech.Name = "btnReAssignTech";
            this.btnReAssignTech.Size = new System.Drawing.Size(182, 38);
            this.btnReAssignTech.TabIndex = 10;
            this.btnReAssignTech.Text = "Assign New Technician";
            this.btnReAssignTech.UseVisualStyleBackColor = true;
            this.btnReAssignTech.Click += new System.EventHandler(this.btnReAssignTech_Click);
            // 
            // txtCurrentTech
            // 
            this.txtCurrentTech.Enabled = false;
            this.txtCurrentTech.Location = new System.Drawing.Point(106, 18);
            this.txtCurrentTech.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrentTech.Name = "txtCurrentTech";
            this.txtCurrentTech.Size = new System.Drawing.Size(166, 20);
            this.txtCurrentTech.TabIndex = 39;
            // 
            // lblCurrentTech
            // 
            this.lblCurrentTech.AutoSize = true;
            this.lblCurrentTech.Location = new System.Drawing.Point(5, 22);
            this.lblCurrentTech.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentTech.Name = "lblCurrentTech";
            this.lblCurrentTech.Size = new System.Drawing.Size(97, 13);
            this.lblCurrentTech.TabIndex = 38;
            this.lblCurrentTech.Text = "Current Technician";
            // 
            // btnReAssignTask
            // 
            this.btnReAssignTask.Location = new System.Drawing.Point(359, 90);
            this.btnReAssignTask.Name = "btnReAssignTask";
            this.btnReAssignTask.Size = new System.Drawing.Size(182, 34);
            this.btnReAssignTask.TabIndex = 39;
            this.btnReAssignTask.Text = "Re-Assign Task";
            this.btnReAssignTask.UseVisualStyleBackColor = true;
            this.btnReAssignTask.Click += new System.EventHandler(this.btnReAssignTask_Click);
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(6, 20);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(69, 13);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "Active Tasks";
            // 
            // tpTrack
            // 
            this.tpTrack.Controls.Add(this.tvTrack);
            this.tpTrack.Location = new System.Drawing.Point(4, 22);
            this.tpTrack.Name = "tpTrack";
            this.tpTrack.Size = new System.Drawing.Size(562, 271);
            this.tpTrack.TabIndex = 2;
            this.tpTrack.Text = "Track Tasks";
            this.tpTrack.UseVisualStyleBackColor = true;
            // 
            // tvTrack
            // 
            this.tvTrack.Location = new System.Drawing.Point(5, 3);
            this.tvTrack.Name = "tvTrack";
            this.tvTrack.Size = new System.Drawing.Size(551, 265);
            this.tvTrack.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cbxSchedueledTask);
            this.tabPage1.Controls.Add(this.btnSubmitFeedback);
            this.tabPage1.Controls.Add(this.lblTaskServiceRequest);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.rtbFeedbackNotes);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblTechArrived);
            this.tabPage1.Controls.Add(this.dtpActualTimeDep);
            this.tabPage1.Controls.Add(this.dtpActualTimeArrived);
            this.tabPage1.Controls.Add(this.lblTechDep);
            this.tabPage1.Controls.Add(this.cbxReportStatus);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 271);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Tech Feedback";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Choose Schedueled Task";
            // 
            // cbxSchedueledTask
            // 
            this.cbxSchedueledTask.FormattingEnabled = true;
            this.cbxSchedueledTask.Location = new System.Drawing.Point(161, 19);
            this.cbxSchedueledTask.Name = "cbxSchedueledTask";
            this.cbxSchedueledTask.Size = new System.Drawing.Size(325, 21);
            this.cbxSchedueledTask.TabIndex = 49;
            this.cbxSchedueledTask.SelectedIndexChanged += new System.EventHandler(this.cbxSchedueledTask_SelectedIndexChanged);
            // 
            // btnSubmitFeedback
            // 
            this.btnSubmitFeedback.Location = new System.Drawing.Point(196, 220);
            this.btnSubmitFeedback.Name = "btnSubmitFeedback";
            this.btnSubmitFeedback.Size = new System.Drawing.Size(182, 34);
            this.btnSubmitFeedback.TabIndex = 48;
            this.btnSubmitFeedback.Text = "Submit Feedback";
            this.btnSubmitFeedback.UseVisualStyleBackColor = true;
            this.btnSubmitFeedback.Click += new System.EventHandler(this.btnSubmitFeedback_Click);
            // 
            // lblTaskServiceRequest
            // 
            this.lblTaskServiceRequest.AutoSize = true;
            this.lblTaskServiceRequest.Location = new System.Drawing.Point(158, 52);
            this.lblTaskServiceRequest.Name = "lblTaskServiceRequest";
            this.lblTaskServiceRequest.Size = new System.Drawing.Size(121, 13);
            this.lblTaskServiceRequest.TabIndex = 47;
            this.lblTaskServiceRequest.Text = "Service Request Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Task Service Request";
            // 
            // rtbFeedbackNotes
            // 
            this.rtbFeedbackNotes.Location = new System.Drawing.Point(161, 146);
            this.rtbFeedbackNotes.Name = "rtbFeedbackNotes";
            this.rtbFeedbackNotes.Size = new System.Drawing.Size(325, 41);
            this.rtbFeedbackNotes.TabIndex = 31;
            this.rtbFeedbackNotes.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Notes";
            // 
            // lblTechArrived
            // 
            this.lblTechArrived.AutoSize = true;
            this.lblTechArrived.Location = new System.Drawing.Point(16, 91);
            this.lblTechArrived.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTechArrived.Name = "lblTechArrived";
            this.lblTechArrived.Size = new System.Drawing.Size(66, 13);
            this.lblTechArrived.TabIndex = 42;
            this.lblTechArrived.Text = "Time Arrived";
            // 
            // dtpActualTimeDep
            // 
            this.dtpActualTimeDep.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpActualTimeDep.Location = new System.Drawing.Point(161, 109);
            this.dtpActualTimeDep.Margin = new System.Windows.Forms.Padding(1);
            this.dtpActualTimeDep.Name = "dtpActualTimeDep";
            this.dtpActualTimeDep.Size = new System.Drawing.Size(102, 20);
            this.dtpActualTimeDep.TabIndex = 45;
            // 
            // dtpActualTimeArrived
            // 
            this.dtpActualTimeArrived.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpActualTimeArrived.Location = new System.Drawing.Point(161, 87);
            this.dtpActualTimeArrived.Margin = new System.Windows.Forms.Padding(1);
            this.dtpActualTimeArrived.Name = "dtpActualTimeArrived";
            this.dtpActualTimeArrived.Size = new System.Drawing.Size(102, 20);
            this.dtpActualTimeArrived.TabIndex = 43;
            // 
            // lblTechDep
            // 
            this.lblTechDep.AutoSize = true;
            this.lblTechDep.Location = new System.Drawing.Point(16, 115);
            this.lblTechDep.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTechDep.Name = "lblTechDep";
            this.lblTechDep.Size = new System.Drawing.Size(77, 13);
            this.lblTechDep.TabIndex = 44;
            this.lblTechDep.Text = "Time Departed";
            // 
            // cbxReportStatus
            // 
            this.cbxReportStatus.FormattingEnabled = true;
            this.cbxReportStatus.Items.AddRange(new object[] {
            "Completed",
            "In progress",
            "Could not complete"});
            this.cbxReportStatus.Location = new System.Drawing.Point(161, 196);
            this.cbxReportStatus.Name = "cbxReportStatus";
            this.cbxReportStatus.Size = new System.Drawing.Size(159, 21);
            this.cbxReportStatus.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Status";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(10, 38);
            this.txtTaskTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(220, 20);
            this.txtTaskTitle.TabIndex = 29;
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.Location = new System.Drawing.Point(7, 23);
            this.lblTaskTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(57, 13);
            this.lblTaskTitle.TabIndex = 28;
            this.lblTaskTitle.Text = "Task Title:";
            // 
            // dtpDeparture
            // 
            this.dtpDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDeparture.Location = new System.Drawing.Point(109, 119);
            this.dtpDeparture.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDeparture.Name = "dtpDeparture";
            this.dtpDeparture.Size = new System.Drawing.Size(121, 20);
            this.dtpDeparture.TabIndex = 27;
            this.dtpDeparture.ValueChanged += new System.EventHandler(this.dtpDeparture_ValueChanged);
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(6, 121);
            this.lblDepart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(102, 13);
            this.lblDepart.TabIndex = 26;
            this.lblDepart.Text = "Expected Departure";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 92);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description:";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(72, 89);
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(158, 20);
            this.txtTaskDescription.TabIndex = 11;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(9, 187);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(221, 52);
            this.rtbNotes.TabIndex = 10;
            this.rtbNotes.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(8, 171);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = "Notes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maintenance technician details";
            // 
            // rtbTechDetails
            // 
            this.rtbTechDetails.Location = new System.Drawing.Point(9, 137);
            this.rtbTechDetails.Name = "rtbTechDetails";
            this.rtbTechDetails.Size = new System.Drawing.Size(309, 100);
            this.rtbTechDetails.TabIndex = 5;
            this.rtbTechDetails.Text = "";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(396, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(182, 38);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return to Call Centre";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lsbxAvailableTechnicians
            // 
            this.lsbxAvailableTechnicians.FormattingEnabled = true;
            this.lsbxAvailableTechnicians.Location = new System.Drawing.Point(6, 23);
            this.lsbxAvailableTechnicians.Name = "lsbxAvailableTechnicians";
            this.lsbxAvailableTechnicians.Size = new System.Drawing.Size(312, 95);
            this.lsbxAvailableTechnicians.TabIndex = 30;
            this.lsbxAvailableTechnicians.SelectedIndexChanged += new System.EventHandler(this.lsbxAvailableTechnicians_SelectedIndexChanged);
            // 
            // grbxAvailableTechnicians
            // 
            this.grbxAvailableTechnicians.Controls.Add(this.lsbxAvailableTechnicians);
            this.grbxAvailableTechnicians.Controls.Add(this.label4);
            this.grbxAvailableTechnicians.Controls.Add(this.rtbTechDetails);
            this.grbxAvailableTechnicians.Location = new System.Drawing.Point(12, 359);
            this.grbxAvailableTechnicians.Name = "grbxAvailableTechnicians";
            this.grbxAvailableTechnicians.Size = new System.Drawing.Size(324, 245);
            this.grbxAvailableTechnicians.TabIndex = 31;
            this.grbxAvailableTechnicians.TabStop = false;
            this.grbxAvailableTechnicians.Text = "AvailableTechnicians";
            // 
            // grbTask
            // 
            this.grbTask.Controls.Add(this.dtpArival);
            this.grbTask.Controls.Add(this.lblArival);
            this.grbTask.Controls.Add(this.txtTaskType);
            this.grbTask.Controls.Add(this.lblTaskType);
            this.grbTask.Controls.Add(this.dtpDeparture);
            this.grbTask.Controls.Add(this.lblTaskTitle);
            this.grbTask.Controls.Add(this.txtTaskTitle);
            this.grbTask.Controls.Add(this.lblDescription);
            this.grbTask.Controls.Add(this.rtbNotes);
            this.grbTask.Controls.Add(this.lblNotes);
            this.grbTask.Controls.Add(this.txtTaskDescription);
            this.grbTask.Controls.Add(this.lblDepart);
            this.grbTask.Location = new System.Drawing.Point(342, 359);
            this.grbTask.Name = "grbTask";
            this.grbTask.Size = new System.Drawing.Size(240, 245);
            this.grbTask.TabIndex = 32;
            this.grbTask.TabStop = false;
            this.grbTask.Text = "Task";
            // 
            // dtpArival
            // 
            this.dtpArival.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpArival.Location = new System.Drawing.Point(109, 144);
            this.dtpArival.Name = "dtpArival";
            this.dtpArival.Size = new System.Drawing.Size(121, 20);
            this.dtpArival.TabIndex = 33;
            // 
            // lblArival
            // 
            this.lblArival.AutoSize = true;
            this.lblArival.Location = new System.Drawing.Point(6, 150);
            this.lblArival.Name = "lblArival";
            this.lblArival.Size = new System.Drawing.Size(81, 13);
            this.lblArival.TabIndex = 32;
            this.lblArival.Text = "Expected Arival";
            // 
            // txtTaskType
            // 
            this.txtTaskType.Location = new System.Drawing.Point(72, 63);
            this.txtTaskType.Name = "txtTaskType";
            this.txtTaskType.Size = new System.Drawing.Size(158, 20);
            this.txtTaskType.TabIndex = 31;
            // 
            // lblTaskType
            // 
            this.lblTaskType.AutoSize = true;
            this.lblTaskType.Location = new System.Drawing.Point(6, 66);
            this.lblTaskType.Name = "lblTaskType";
            this.lblTaskType.Size = new System.Drawing.Size(34, 13);
            this.lblTaskType.TabIndex = 30;
            this.lblTaskType.Text = "Type:";
            // 
            // ServiceDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 608);
            this.Controls.Add(this.grbTask);
            this.Controls.Add(this.grbxAvailableTechnicians);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.tcTask);
            this.Name = "ServiceDepartment";
            this.Text = "ServiceDepartment";
            this.tcTask.ResumeLayout(false);
            this.tpCreate.ResumeLayout(false);
            this.tpCreate.PerformLayout();
            this.grbCreate.ResumeLayout(false);
            this.grbCreate.PerformLayout();
            this.tpModify.ResumeLayout(false);
            this.tpModify.PerformLayout();
            this.grbModify.ResumeLayout(false);
            this.gpbxAssignedTechnician.ResumeLayout(false);
            this.gpbxAssignedTechnician.PerformLayout();
            this.tpTrack.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grbxAvailableTechnicians.ResumeLayout(false);
            this.grbxAvailableTechnicians.PerformLayout();
            this.grbTask.ResumeLayout(false);
            this.grbTask.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcTask;
        private System.Windows.Forms.TabPage tpCreate;
        private System.Windows.Forms.TabPage tpModify;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbTechDetails;
        private System.Windows.Forms.RichTextBox rtbSLDetails;
        private System.Windows.Forms.Button btnCreateJob;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.DateTimePicker dtpDeparture;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.GroupBox gpbxAssignedTechnician;
        private System.Windows.Forms.Button btnReAssignTech;
        private System.Windows.Forms.TextBox txtCurrentTech;
        private System.Windows.Forms.Label lblCurrentTech;
        private System.Windows.Forms.Button btnReAssignTask;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.Label lblTaskTitle;
        private System.Windows.Forms.ListBox lsbxAvailableTechnicians;
        private System.Windows.Forms.ListBox lsbxUnclaimedServiceRequests;
        private System.Windows.Forms.ComboBox cbxClient;
        private System.Windows.Forms.GroupBox grbxAvailableTechnicians;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.GroupBox grbTask;
        private System.Windows.Forms.GroupBox grbCreate;
        private System.Windows.Forms.GroupBox grbModify;
        private System.Windows.Forms.ListBox lsbxActiveTasks;
        private System.Windows.Forms.Label lblCurentClient;
        private System.Windows.Forms.TabPage tpTrack;
        private System.Windows.Forms.TreeView tvTrack;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbxReportStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbFeedbackNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTechArrived;
        private System.Windows.Forms.DateTimePicker dtpActualTimeDep;
        private System.Windows.Forms.DateTimePicker dtpActualTimeArrived;
        private System.Windows.Forms.Label lblTechDep;
        private System.Windows.Forms.Button btnSubmitFeedback;
        private System.Windows.Forms.Label lblTaskServiceRequest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxSchedueledTask;
        private System.Windows.Forms.TextBox txtTaskType;
        private System.Windows.Forms.Label lblTaskType;
        private System.Windows.Forms.Label lblArival;
        private System.Windows.Forms.DateTimePicker dtpArival;
    }
}