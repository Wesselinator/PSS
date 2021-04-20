using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        string description = string.Empty;

        Timer timer;
        Stopwatch sw;

        public static ClientMaintenance ClientMaintenance = new ClientMaintenance(); //Master
        public static CallCentre CallCentre = new CallCentre(); //Master

        public Client SelectedClient { get => (Client)cbClientDropDown.SelectedItem; }

        public CallSimulation()
        {
            InitializeComponent();
        }

        private void btnLogRequest_Click(object sender, EventArgs e)
        {
            CallCentre.Populate(SelectedClient);
            CallCentre.Show();
        }

        private void CallSimulation_Load(object sender, EventArgs e)
        {
            LoadDropDown();
            btnLogRequest.Hide();
            btnRegister.Hide();
            btnFollowUp.Hide();
        }

        private void LoadDropDown()
        {
            cbClientDropDown.DisplayMember = "CBXString";

            //cbClientDropDown.Items.AddRange();
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
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string TimerInString;
            int sec = sw.Elapsed.Seconds;
            int min = 0;

            TimerInString = ((min < 10) ? "0" + min.ToString() : min.ToString());
            TimerInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());

            lblTimer.Text = TimerInString;
            Application.DoEvents();
        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            endTime = DateTime.Now;

            description = Interaction.InputBox("Please enter a description","Description","Please enter a description", -1, -1);

            Call calll = new Call(startTime, endTime, description);
            calll.Save();


            Application.Exit();
        }

        
    }
}
