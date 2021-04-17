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
        private static ClientMaintenance ClientMaintenance = CallSimulation.ClientMaintenance; //bemby!

        public CallCentre()
        {
            InitializeComponent();
            Hide(); // I hope this can work in the constructor
        }


        private ServiceRequest currentRequest = null;
        private Client currentClient = null;
        public void Populate(Client client)
        {
            ServiceRequest sr = new ServiceRequest("Unknown", "Unkown Type", "Unknown Problem", client);

            Populate(client, sr);
        }
        public void Populate(Client client, ServiceRequest existingServiceRequest)
        {

            if (!existingServiceRequest.Verify(client))
            {
                return;
                //throw
            }
            
            
            currentRequest = existingServiceRequest;
            //if (existingTicket.Verify(client))
            //{
            //    return;
            //    //throw
            //}


            currentTicket = existingTicket;
            currentClient = client;

            PopulateClientInfo();
            PopulateTicket();
        }

        #region PopulateSpesific

        private void PopulateTicket()
        {
            if (currentRequest is null)
            {
                return;
                //trow
            }

            rtbProblem.Text = currentRequest.Description;
        }

        private void PopulateClientInfo()
        {
            if (currentClient is null)
            {
                return;
                //throw
            }

            PopulateContracts();

            lblBirthDay.Text = currentClient.Person.BirthDayString;
            lblCellphone.Text = currentClient.Person.CellphoneNumber;
            lblTelephone.Text = currentClient.Person.TellephoneNumber;
            lblEmail.Text = currentClient.Person.Email;

            lblAdress.Text = currentClient.Address.AdressString();
            lblPostal.Text = currentClient.Address.PostalCode;


            if (currentClient is IndividualClient)
            {
                PopulateIndividualInfo((IndividualClient)currentClient);
            }
            else if (currentClient is BusinessClient)
            {
                PopulateBusinessInfo((BusinessClient)currentClient);
            }
            //else throw
        }

        private void PopulateContracts()
        {
            if (currentClient is null)
            {
                return;
                //throw
            }

            rtbProblem.Clear();
            //foreach (var contract in currentClient.Contracts)
            //{
            //    rtbProblem.AppendText(contract.ToFormatedString());
            //}
        }

        private void PopulateIndividualInfo(IndividualClient individualClient)
        {
            lblNameTag.Text = "Name: ";
            lblBusinessName.Text = "N/A";
            lblName.Text = individualClient.Person.FullName;
        }

        private void PopulateBusinessInfo(BusinessClient businessClient)
        {
            lblNameTag.Text = "Contact Person: ";
            lblBusinessName.Text = businessClient.BusinessName;
            lblName.Text = businessClient.ContactPerson.FullName;
        }

        #endregion


        private void btnClientMaintence_Click(object sender, EventArgs e)
        {
            ClientMaintenance.ReceiveClient(currentClient); //I think this is the method?
            ClientMaintenance.Show();
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
