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


        private Ticket currentTicket = null;
        private Client currentClient = null;
        public void Populate(Client client)
        {
            Ticket stub = new Ticket();
            stub.TicketID = 1; //figure out how this will happen
            stub.ClientID = client.ClientID;
            stub.Status = "Unresolved";
            stub.Department = "Call Center"; //should be changed in the next department

            Populate(client, stub);
        }
        public void Populate(Client client, Ticket existingTicket)
        {

            if (existingTicket.Verify(client))
            {
                return;
                //throw
            }
            
            
            currentTicket = existingTicket;
            currentClient = client;

            PopulateClientInfo();
            PopulateTicket();
        }

        #region PopulateSpesific

        private void PopulateTicket()
        {
            if (currentTicket is null)
            {
                return;
                //trow
            }

            rtbProblem.Text = currentTicket.ProblemDescription;
        }

        private void PopulateClientInfo()
        {
            if (currentClient is null)
            {
                return;
                //throw
            }

            PopulateContracts();

            lblRegDate.Text = currentClient.RegistrationDate.ToString("yyyy/MM/dd");
            lblCellphone.Text = currentClient.Person.CellphoneNumber;
            lblTelephone.Text = currentClient.Person.TellephoneNumber;
            lblEmail.Text = currentClient.Person.Email;

            lblAdress.Text = currentClient.Person.FullAddress;
            lblPostal.Text = currentClient.Person.PostalCode;


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
            foreach (var contract in currentClient.Contracts)
            {
                rtbProblem.AppendText(contract.ToFormatedString());
            }
        }

        private void PopulateIndividualInfo(IndividualClient individualClient)
        {
            lblNameTag.Text = "Name: ";
            lblBusinessName.Text = "N/A";
            lblName.Text = individualClient.ClientName;
        }

        private void PopulateBusinessInfo(BusinessClient businessClient)
        {
            lblNameTag.Text = "Contact Person: ";
            lblBusinessName.Text = businessClient.BusinessName;
            lblName.Text = businessClient.ContactPersonFullName;
        }

        #endregion


        private void btnClientMaintence_Click(object sender, EventArgs e)
        {
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
            if (currentTicket is null)
            {
                MessageBox.Show("Ticket Not Updated! No Active Ticket", "Failure!");
            }
            else
            {
                MessageBox.Show("Ticket Updated!", "Success!");
                currentTicket.ProblemDescription = rtbProblem.Text;
            }
        }
    }
}
