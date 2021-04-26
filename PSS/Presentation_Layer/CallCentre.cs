using System;
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

        public CallCentre(Client client) : this()
        {
            currentClient = client;
            ciwMain.Client = client;
        }

        public CallCentre(Client client, ServiceRequest existingRequest) : this(client)
        {
            //TODO: existing request exists or add if doesn't
            currentRequest = existingRequest;
        }


        private ServiceRequest currentRequest = null;
        private readonly Client currentClient = null; //readonly becuase i never change anything on this client


        private void btnClientMaintence_Click(object sender, EventArgs e)
        {
            ClientMaintenance cm = new ClientMaintenance(currentClient);
            Hide(); //TODO: this works?
            cm.ShowDialog(); 
            Show();
        }

        private void btnServiceDept_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnClientSatisfaction_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            if (currentRequest is null)
            {
                currentRequest = new ServiceRequest("Unknown", "Unkown Type", "Unknown Problem", currentClient);
            }
            else
            {
                currentRequest.Title = txtProblemTitle.Text;
                currentRequest.Description = rtbProblem.Text;
                currentRequest.Type = cbxProblemType.SelectedItem.ToString();
                MessageBox.Show("Ticket Updated!", "Success!");
            }
        }
    }
}
