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

namespace PSS.Presentation_Layer
{
    public partial class CallSimulation : Form
    {
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
        }

        private void LoadDropDown()
        {
            cbClientDropDown.DisplayMember = "CBXString";

            //cbClientDropDown.Items.AddRange();
        }
    }
}
