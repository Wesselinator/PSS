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
    public partial class CallCentre : Form
    {
        public CallCentre()
        {
            InitializeComponent();
        }

        public bool Populate(Client client, Ticket existingTicket)
        {

        }

        private bool PopulateClient(Client client)
        {
            lblName.Text = client.FullName;

        }

        private void btnClientMaintence_Click(object sender, EventArgs e)
        {

        }

        private void btnServiceDept_Click(object sender, EventArgs e)
        {

        }

        private void btnClientSatisfaction_Click(object sender, EventArgs e)
        {

        }
    }
}
