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
            ciwMain = new ClientInfoWidgit(client);
        }

        public CallCentre(Client client, ServiceRequest existingRequest) : this(client)
        {
            //TODO: existing request exists or add if doesn't
            currentRequest = existingRequest;
        }


        private ServiceRequest currentRequest = null;
        private Client currentClient = null;
        public void Populate(Client client)
        {
            ServiceRequest sr = new ServiceRequest("Unknown", "Unkown Type", "Unknown Problem", client);

            Populate(client, sr);
        }


        private void btnClientMaintence_Click(object sender, EventArgs e)
        {
            //ClientMaintenance.ReceiveClient(currentClient); //I think this is the method?
            //ClientMaintenance.Show();
            Hide();
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
                MessageBox.Show("Service Request Not Updated! No Active Service Request", "Failure!");
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
