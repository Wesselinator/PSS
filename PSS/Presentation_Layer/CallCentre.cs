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

            //List<string> lines = new List<string>();
            //foreach (Contract contract in client.GetContracts())
            //{
            //    lines.Add(contract.ToString());
            //}
            Contract contract = client.GetCurrentContract();

            iwCallContract.Contract = contract;
            Service[] services = contract?.GetServices().ToArray();

            lsbxServices.DisplayMember = "DisplayMember";
            if (!(services is null))
            {
                lsbxServices.Items.AddRange(services);
            }

            lsbxPreviousCalls.DisplayMember = "DisplayMember";
            lsbxPreviousCalls.Items.AddRange(Call.GetPreviousCallsFrom(client).ToArray());
        }

        //TODO: This is in the requirements but we never access it
        public CallCentre(Client client, ServiceRequest existingRequest) : this(client)
        {
            currentRequest = existingRequest; //assumes existing requesst refers to an object in client
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
            MessageBox.Show("Call forwarded to clientsatisfaction department");
            try
            {
                showLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the webpage.");
            }
        }

        private void showLink()
        {
            System.Diagnostics.Process.Start("http://localhost:1337/");
        }


        private void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            if (currentRequest is null)
            {
                currentRequest = new ServiceRequest(txtProblemTitle.Text, cbxProblemType.Text, rtbProblem.Text, DateTime.Now); //creates a new one
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

            //Clear inputs
            txtProblemTitle.Clear();
            rtbProblem.Clear();
            cbxProblemType.Text = "Type...";
            cbxProblemType.SelectedIndex = 0;
        }

        private void lsbxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbServiceDetails.Text = ((Service)lsbxServices.SelectedItem)?.ServiceDescription; //TODO: nicer service string
        }

        private void lsbxPreviousCalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbCallDescription.Text = ((Call)lsbxPreviousCalls.SelectedItem)?.Description;
        }
    }
}
