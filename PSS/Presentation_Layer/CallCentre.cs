using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    public partial class CallCentre : Form
    {
        public CallCentre()
        {
            InitializeComponent();
            DisableTransfer();
        }

        public CallCentre(Client client) : this()
        {
            currentClient = client;
            ciwMain.Client = client;

            List<string> lines = new List<string>();
            foreach (Contract contract in client.GetContracts())
            {
                lines.Add(contract.ToString());
            }
            rtbContracts.Lines = lines.ToArray();
        }

        //TODO: Consider removal
        public CallCentre(Client client, ServiceRequest existingRequest) : this(client)
        {
            currentRequest = existingRequest; //assumes existing requesst reffers to an object in client
        }

        #region Transfer
        private void DisableTransfer()
        {
            grbxTransfer.Enabled = false;
        }

        private void EnableTransfer()
        {
            grbxTransfer.Enabled = true;
        }
        #endregion


        private ServiceRequest currentRequest = null;
        private readonly Client currentClient = null; //I shouldn't set client


        private void btnClientMaintence_Click(object sender, EventArgs e)
        {
            ClientMaintenance cm = new ClientMaintenance(currentClient);
            Hide();
            cm.ShowDialog(); 
            Show();
        }

        private void btnServiceDept_Click(object sender, EventArgs e)
        {
            ServiceDepartment sd = new ServiceDepartment(currentClient);
            Hide();
            sd.ShowDialog();
            Show();
        }

        private void btnClientSatisfaction_Click(object sender, EventArgs e)
        {
            Hide(); //TODO: Add Client Satisfaction
        }


        private void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            if (currentRequest is null)
            {
                currentRequest = new ServiceRequest(txtProblemTitle.Text, cbxProblemType.Text, rtbProblem.Text, DateTime.Now,0); //creates a new one //TODO: Add adress ID
                currentClient.AddServiceRequest(currentRequest);
            }
            else
            {
                currentRequest.Title = txtProblemTitle.Text;
                currentRequest.Description = rtbProblem.Text;
                currentRequest.Type = cbxProblemType.Text;
            }
            currentRequest.Save(); //specifically only save the request (I shouldn't have change antying in the client)
            MessageBox.Show("Ticket Updated!", "Success!");
            EnableTransfer();
        }
    }
}
