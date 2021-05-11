﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    //TODO: refresh
    public partial class ServiceDepartment : Form
    {
        private ServiceRequest currentRequest = null;
        //private string requestType = null;

        //TODO: Should Service Dept. ever be accesed without a client?
        private ServiceDepartment()
        {
            InitializeComponent();
            LoadViews();
            //TODO: Enable cbx
        }

        public ServiceDepartment(Client client) : this()
        { 
            this.currentClient = client;
            lblCurentClient.Text = client.Person.FullName;

            AllClients.RemoveAll(c => c.ClientID == currentClient.ClientID);
            AllClients.Add(currentClient);

            PopulateClients();
            PopulateUnclaimedClientServiceRequests();
            PopulateSLA();
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
            //TODO: apparntly this is supposed to be the client's unclaimed service request? That'll always be one right?

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
            lsbxActiveTasks.DataSource = AllUnfinishedTasks;
            //Tech Feedback tab
            cbxSchedueledTask.DisplayMember = "DisplayMember";
            cbxSchedueledTask.Items.AddRange(TechnicianTask.GetUnfinishedTechTasks().ToArray());
        }

        private void PopulateTask()
        {
            if (techTaskToModify is null)
            {
                return;
            }

            txtTaskTitle.Text = techTaskToModify.Task.Title;
            txtTaskDescription.Text = techTaskToModify.Task.Descripion;
            dtpTaskDate.Value = techTaskToModify.Task.DateProcessed;
            rtbNotes.Text = techTaskToModify.Task.Notes;
        }

        private void PopulateSLA()
        {
            //TODO: the frick is this?
        }

        private TreeNode[] TechnicianTaskNodes(Technician t) => AllTechnicianTasks.Where(tt => tt.Technician.TechnicianID == t.TechnicianID).Select(tt => new TreeNode(tt.Task.Title)).ToArray(); //TODO: order
        private TreeNode[] TechnicianNodes => AllTechnicians.Select(t => new TreeNode(t.Person.FullName, TechnicianTaskNodes(t))).ToArray();
        private void PopulateTree()
        {
            tvTrack.Nodes.Clear();
            tvTrack.Nodes.AddRange(TechnicianNodes);
        }

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
            techTaskToModify = AllTechnicianTasks.Find(tt => tt.Task.TaskID == taskToModify.TaskID); //might not find it?
            //Console.WriteLine(string.Format("{0} was found in {1}", taskToModify.Title, techTaskToModify?.ToString()));
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
                case 3:
                    grbTask.Enabled = false;
                    grbxAvailableTechnicians.Enabled = false;
                    break;

                case 2:
                    PopulateTree();
                    goto default;
                default:
                    grbTask.Enabled = true;
                    grbxAvailableTechnicians.Enabled = true;
                    break;
            }
        }

        #endregion

        #region Buttons
        private void btnReAssignTask_Click(object sender, EventArgs e)
        {
            techTaskToModify.Task.Title = txtTaskTitle.Text;
            techTaskToModify.Task.Descripion = txtTaskDescription.Text;
            techTaskToModify.Task.DateProcessed = dtpTaskDate.Value;
            techTaskToModify.Task.Notes = rtbNotes.Text;

            //the technician SHOULD have been changed...
            AllTechnicians.Remove(techTaskToModify.Technician); //reduce database accesses

            techTaskToModify.Save();
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
            //TODO: Add Task type
            Task aTask = new Task(txtTaskTitle.Text, txtTaskDescription.Text, "", rtbNotes.Text, currentRequest, dtpTaskDate.Value, false); //New task created
            TechnicianTask techTask = new TechnicianTask(aTask, currentTech, dtpTaskDate.Value, dtpTaskDate.Value.AddDays(30)); //New Tech Task //TODO: add datetodepart

            AllUnfinishedTasks.Add(aTask);      //reduce database calls
            AllTechnicianTasks.Add(techTask);   //reduce database calls

            techTask.Save(); //actually put in database

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

        private void ServiceDepartment_Load(object sender, EventArgs e)
        {
            //TODO: move populates here? Keep in constructor?
        }

        private void cbxSchedueledTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Check if working
            techTaskToModify = (TechnicianTask)cbxSchedueledTask.SelectedItem;

            lblTaskServiceRequest.Text = techTaskToModify.Task.ServiceRequest.ToString();
            PopulateTask();
        }
        
        private void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            techTaskToModify.Task.IsFinished = true;
            TechnicianTaskFeedback technicianTaskFeedback = new TechnicianTaskFeedback();
            technicianTaskFeedback.SetNextID();
            technicianTaskFeedback.TimeArived = dtpActualTimeArrived.Value;
            technicianTaskFeedback.TimeDeparture = dtpTimeDep.Value;
            technicianTaskFeedback.Notes = rtbFeedbackNotes.Text;
            technicianTaskFeedback.Status = cmbStatus.SelectedItem.ToString();
            technicianTaskFeedback.TechnicianTask = techTaskToModify;
            techTaskToModify.Save();
            MessageBox.Show("Task Feedback succesfully submitted");
        }
    }
}
