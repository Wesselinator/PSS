using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    public partial class ServiceDepartment : Form
    {
        private ServiceRequest currentRequest = null;
        //private string requestType = null;

        //TODO: Should Service Dept. ever be accesed without a client?
        private ServiceDepartment()
        {
            InitializeComponent();
            LoadViews();
            ClearTaskControls();
            cbxClient.Enabled = true;
        }

        public ServiceDepartment(Client client) : this()
        { 
            this.currentClient = client;
            lblCurentClient.Text = client.Person.FullName;

            AllClients.RemoveAll(c => c.ClientID == currentClient.ClientID);
            AllClients.Add(currentClient);

            cbxClient.Enabled = false;

            PopulateClients();
            PopulateUnclaimedClientServiceRequests();
        }

        private void LoadViews()
        {
            PopulateAvailableTechnicians();
            PopulateTaskList();
            PopulateTree();
        }

        #region Data

        //wont update with database
        //change '=' to '=>' if update is prefered
        private readonly List<Client> AllClients = Client.GetAllClients(); 

        private readonly BaseList<Technician> AllTechnicians = BaseList<Technician>.GrabAll(); //we do need all technicians becuase we want all. If you have a problem, write a DataEngine for this
        private readonly BaseList<TechnicianTask> AllTechnicianTasks = BaseList<TechnicianTask>.GrabAll();
        private readonly BaseList<Task> AllUnfinishedTasks = Task.GetAllUnFinishedTasks();

        #endregion

        #region Populate

        private BaseList<ServiceRequest> ClientServiceRequests => currentClient.GetServiceRequests();
        private BaseList<ServiceRequest> UnClaimedClientServiceRequests => ClientServiceRequests.Except(AllUnfinishedTasks.Select(task => task.ServiceRequest)).ToBaseList();
        private void PopulateUnclaimedClientServiceRequests()
        {
            lsbxUnclaimedServiceRequests.DisplayMember = "DisplayMember";
            lsbxUnclaimedServiceRequests.DataSource = UnClaimedClientServiceRequests;
        }

        private readonly BaseList<Technician> AvailableTechnicians = Technician.GetAllAvailableClients();

        private void PopulateAvailableTechnicians()
        {
            lsbxAvailableTechnicians.DisplayMember = "DisplayMember";
            lsbxAvailableTechnicians.DataSource = AvailableTechnicians;
        }

        private void PopulateClients()
        {
            cbxClient.DisplayMember = "DisplayMember";
            cbxClient.Items.AddRange(AllClients.ToArray());
            cbxClient.SelectedItem = currentClient; //this line usually breaks things
        }

        private void PopulateTaskList()
        {
            lsbxActiveTasks.DataSource = null;
            lsbxActiveTasks.DataSource = AllUnfinishedTasks;
            //Tech Feedback tab
            cbxSchedueledTask.DisplayMember = "DisplayMember";
            cbxSchedueledTask.Items.Clear();
            cbxSchedueledTask.Items.AddRange(TechnicianTask.GetUnfinishedTechTasks().ToArray());
        }

        private void PopulateTask()
        {
            if (techTaskToModify is null)
            {
                return;
            }

            txtTaskTitle.Text = techTaskToModify.Task.Title;
            txtTaskType.Text = techTaskToModify.Task.Type;
            txtTaskDescription.Text = techTaskToModify.Task.Description;
            dtpDeparture.Value = techTaskToModify.TimeToDepart;
            dtpArival.Value = techTaskToModify.TimeToArrive;
            rtbNotes.Text = techTaskToModify.Task.Notes;
        }

        #region Tree
        private TreeNode[] TechnicianTaskNodes(Technician t) => AllTechnicianTasks.Where(tt => tt.Technician.TechnicianID == t.TechnicianID).Select(tt => new TreeNode(tt.Task.Title)).ToArray(); //TODO: order
        private TreeNode[] TechnicianNodes => AllTechnicians.Select(t => new TreeNode(t.Person.FullName, TechnicianTaskNodes(t))).ToArray();

        private TreeNode[] DanglingTaskNodes => Task.GetAllDanglingTasks().Select(t => new TreeNode(t.Title)).ToArray();
        private TreeNode UnassignedNode => new TreeNode("Unassigned Tasks", DanglingTaskNodes);
        private void PopulateTree()
        {
            tvTrack.Nodes.Clear();
            tvTrack.Nodes.AddRange(TechnicianNodes);
            tvTrack.Nodes.Add(UnassignedNode);
        }
        #endregion

        #endregion

        #region Things Change

        private Technician currentTech = null;
        private void lsbxAvailableTechnicians_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTech = (Technician)lsbxAvailableTechnicians.SelectedItem;
            rtbTechDetails.Text = currentTech.ToFormattedString();
        }


        private void lsbxUnclaimedServiceRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentRequest = (ServiceRequest)lsbxUnclaimedServiceRequests.SelectedItem;
            rtbSLDetails.Text = currentRequest.ToString();
            ClearTaskControls();
        }


        private Client currentClient = null;
        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentClient = (Client)cbxClient.SelectedItem;
            PopulateUnclaimedClientServiceRequests();
        }

        private TechnicianTask techTaskToModify = null;
        private void lsbxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task taskToModify = (Task)lsbxActiveTasks.SelectedItem;
            techTaskToModify = AllTechnicianTasks.Find(tt => tt.Task.TaskID == taskToModify?.TaskID); //might not find it?
            if (!(techTaskToModify is null))
            {
                txtCurrentTech.Text = techTaskToModify.Technician.Person.FullName; //can I do this with a datasource?
            }

            PopulateTask(); //quality of life
            btnReAssignTech.Enabled = true;
        }

        private void tcTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            switch (tabControl.SelectedIndex)
            {
                case 0:
                case 1:
                    grbTask.Enabled = true;
                    grbxAvailableTechnicians.Enabled = true;
                    break;

                case 2:
                    PopulateTree();
                    goto default;
                default:
                    grbTask.Enabled = false;
                    grbxAvailableTechnicians.Enabled = false;
                    break;
            }
        }

        private void dtpDeparture_ValueChanged(object sender, EventArgs e)
        {
            dtpArival.Value = dtpArival.Value.AddHours(2);
        }

        private void ClearTaskControls()
        {
            txtTaskTitle.Clear();
            txtTaskType.Clear();
            txtTaskDescription.Clear();
            dtpDeparture.Value = DateTime.Now;
            dtpArival.Value = DateTime.Now.AddHours(2);
            rtbNotes.Clear();
        }

        #endregion

        #region Buttons
        private void btnReAssignTask_Click(object sender, EventArgs e)
        {
            techTaskToModify.Task.Title = txtTaskTitle.Text;
            techTaskToModify.Task.Description = txtTaskDescription.Text;
            techTaskToModify.Task.DateProcessed = DateTime.Now;
            techTaskToModify.TimeToArrive = dtpArival.Value;
            techTaskToModify.TimeToDepart = dtpDeparture.Value;
            techTaskToModify.Task.Notes = rtbNotes.Text;

            //the technician SHOULD have been changed...
            AllTechnicians.Remove(techTaskToModify.Technician); //reduce database accesses

            techTaskToModify.Save();

            MessageBox.Show("Task Updated and Re-Assigned", "Success");
        }

        private void btnReAssignTech_Click(object sender, EventArgs e)
        {
            Technician technician = (Technician)lsbxAvailableTechnicians.SelectedItem;

            AvailableTechnicians.Add(techTaskToModify.Technician);
            AvailableTechnicians.Remove(technician);                //reduce database accesses

            techTaskToModify.Technician = technician;

            txtCurrentTech.Text = technician.Person.FullName; //can I do this with a datasource?
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            Task aTask = new Task(txtTaskTitle.Text, txtTaskDescription.Text, txtTaskType.Text, rtbNotes.Text, currentRequest, DateTime.Now, false); //New task created
            TechnicianTask techTask = new TechnicianTask(aTask, currentTech, dtpDeparture.Value, dtpArival.Value); //New Tech Task

            AllUnfinishedTasks.Add(aTask);      //reduce database calls
            AllTechnicianTasks.Add(techTask);   //reduce database calls

            techTask.Save(); //actually put in database

            // TODO: (fix) Update Unclaimed service request and active tasks
            PopulateUnclaimedClientServiceRequests();
            PopulateTaskList();

            MessageBox.Show("Task Created and Assigned", "Success");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("No changes will be saved! Are you sure you want to go back?", "Discard and Go Back", MessageBoxButtons.YesNo))
            {
                case DialogResult.None:
                case DialogResult.No:
                    goto default; //fall-through goto default incase we want to add additional functionality.

                case DialogResult.Yes:
                    this.Close();
                    break;

                default:
                    return;
            }
        }

        #endregion

        private void cbxSchedueledTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            techTaskToModify = (TechnicianTask)cbxSchedueledTask.SelectedItem;

            lblTaskServiceRequest.Text = techTaskToModify.Task.ServiceRequest.ToString();

            PopulateTask();
            //Change DateTimePicker controls to select the day the tech is suppose to arrive, makes sure that the correct Date is already selected.
            dtpActualTimeArrived.Value = techTaskToModify.TimeToArrive;
            dtpActualTimeDep.Value = techTaskToModify.TimeToArrive;
        }
        
        private void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            if (cbxReportStatus.SelectedIndex == 0)
            {
                techTaskToModify.Task.IsFinished = true;
                cbxSchedueledTask.Items.Remove(techTaskToModify);
            }
            TechnicianTaskFeedback technicianTaskFeedback = new TechnicianTaskFeedback();
            technicianTaskFeedback.SetNextID();
            technicianTaskFeedback.TimeArived = dtpActualTimeArrived.Value;
            technicianTaskFeedback.TimeDeparture = dtpActualTimeDep.Value;
            technicianTaskFeedback.Notes = rtbFeedbackNotes.Text;
            technicianTaskFeedback.Status = cbxReportStatus.SelectedItem.ToString();
            technicianTaskFeedback.TechnicianTask = techTaskToModify;
            technicianTaskFeedback.Save();

            //Update Active Task lists
            PopulateTaskList();

            MessageBox.Show("Task Feedback succesfully submitted", "Success!");
        }
    }
}
