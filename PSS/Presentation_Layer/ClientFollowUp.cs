using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSS.Data_Access;

namespace PSS.Presentation_Layer
{
    public partial class ClientFollowUp : Form
    {
        public ClientFollowUp()
        {
            InitializeComponent();
        }

        private void btnGetProgressReport_Click(object sender, EventArgs e)
        {
            
            rtxtRaport.Text = DataEngine.GetProgressRapport(txtTicketNumber.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCallClient_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
