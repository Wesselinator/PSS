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

namespace PSS.Presentation_Layer
{
    public partial class CallSimulation : Form
    {
        DateTime startTime;
        DateTime endTime;
        string description = string.Empty;

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
        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            endTime = DateTime.Now;

            description = Interaction.InputBox("Please enter a description","Description","Please enter a description", -1, -1);

            Call calll = new Call(startTime, endTime, description);
            calll.Save();
        }

        
    }
}
