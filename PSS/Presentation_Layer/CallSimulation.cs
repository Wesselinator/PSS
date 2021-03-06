using System;
using System.Windows.Forms;
using PSS.Business_Logic;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace PSS.Presentation_Layer
{
    public partial class CallSimulation : Form
    {
        DateTime startTime;
        DateTime endTime;
        

        Timer timer;
        Stopwatch sw;

        public Client SelectedClient { get => (Client)cbClientDropDown.SelectedItem; }

        public CallSimulation()
        {
            InitializeComponent();
        }

        string description = string.Empty;

        private void EnterDescription()
        {
            while (description.Equals(string.Empty))
            {
                description = Interaction.InputBox("Please enter a description", "Description", "Please enter a description", -1, -1);
                if (!description.Equals(string.Empty)) break;
                MessageBox.Show("Please enter something!");
            }
        }

        private void CallSimulation_Load(object sender, EventArgs e)
        {
            LoadDropDown();
            btnLogRequest.Hide();
            btnRegister.Hide();
            btnFollowUp.Hide();
            btnEndCall.Enabled = false;
        }

        private void LoadDropDown()
        {
            cbClientDropDown.DisplayMember = "DisplayMember";

            cbClientDropDown.Items.AddRange(Client.GetAllClients().ToArray());
        }

        private void btnMakeCall_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;

            timer = new Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);

            sw = new Stopwatch();
            timer.Start();
            sw.Start();

            if (cbClientDropDown.SelectedIndex == -1) //Nothing sellected
            {
                btnLogRequest.Show();
                btnLogRequest.Enabled = false;
                btnFollowUp.Show();
                btnFollowUp.Enabled = false;
                btnRegister.Show();
                btnRegister.Enabled = true;
            }
            else
            {
                btnLogRequest.Show();
                btnEndCall.Enabled = true;
                btnFollowUp.Show();
                btnFollowUp.Enabled = true;
                btnRegister.Show();
                btnRegister.Enabled = false;
            }

            cbClientDropDown.Enabled = false;
            btnEndCall.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int sec = sw.Elapsed.Seconds;
            int min = sw.Elapsed.Minutes;

            lblTimer.Text = string.Format("{0:00}:{1:00}", min, sec);
            Application.DoEvents();
        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            endTime = DateTime.Now;

            EnterDescription();

            Call call = new Call(startTime, endTime, description);
            CallChangeAssociation association = new CallChangeAssociation(call, SelectedClient.TableName, SelectedClient.ClientID.ToString());
            association.Save();


            Application.Exit();
        }

        private void btnLogRequest_Click(object sender, EventArgs e)
        {
            CallCentre callCentreForm = new CallCentre(SelectedClient);
            callCentreForm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ClientMaintenance clientMaintenanceForm = new ClientMaintenance();
            clientMaintenanceForm.ShowDialog();
            Client newClient = clientMaintenanceForm.GetNewlyRegistered();
            clientMaintenanceForm.Close();

            if (newClient is null)
            {
                Close();
            }
            else
            {
                cbClientDropDown.DataSource = null;
                cbClientDropDown.Items.Add(newClient);
                cbClientDropDown.SelectedItem = newClient;
            }

            
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("call forwarded to clientsatisfaction department");
            try
            {
                showLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to fine webpage");
            }   
        }

        private void showLink()
        {
            System.Diagnostics.Process.Start("http://localhost:1337/"); 
            
        }

    }
}
