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
    public partial class ClientMaintenance : Form
    {
        private Client currentClient = null;
        private Contract selectedContract = null;
        //private MultiIDList<ClientContract> currentContracts;// TODO: does not work so using 2 seperate lists for now...
        private MultiIDList<IndividualClientContract> iContracts;
        private MultiIDList<BusinessClientContract> bContracts;

        public ClientMaintenance()
        {
            InitializeComponent();
            RegisterMode();
        }      

        public ClientMaintenance(Client client) 
        {
            InitializeComponent();
            currentClient = client;
            ciwMain.Client = client;
            UpdateMode();
        }

        #region Methods

        private void ClearFields()
        {
            rbtnIndvidual.Enabled = true;
            rbtnBusiness.Enabled = true;
            rbtnIndvidual.Checked = false;
            rbtnBusiness.Checked = false;
            txtBusinessName.Clear();
            txtName.Clear();
            txtSurname.Clear();
            dtpDOB.Value = new DateTime();//check if needed
            txtCellphone.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtPostalCode.Clear();
            cbxProvince.SelectedIndex = -1;
            cbxProvince.Text = "Choose...";
            cbxStatus.SelectedIndex = -1;
            cbxStatus.Text = "Choose...";

            //Add all Contracts
            cbxCurrentContracts.Items.Clear();
            cbxCurrentContracts.Text = "None at the moment";
            cbxContracts.Items.Clear();
            BaseList<Contract> contracts = new BaseList<Contract>();
            contracts.FillAll();
            cbxContracts.Items.AddRange(contracts.ToArray());
            rtbContractDetails.Clear();
            rtbContractDetails.Text = "Contract details:\n";

            //Service level items won't change?
            cbxServiceLevel.Text = "Choose a service level";
            rtbServiceLevelDetails.Clear();
            rtbServiceLevelDetails.Text = "Service level details:\n";
            

        }

        private void RegisterMode()
        {
            //update components to register functionality
            lblTask.Text = "Register Client";
            btnConfirm.Text = "Register Client";            
            ClearFields();
            
        }

        private void UpdateMode()
        {
            //update components to register functionality
            lblTask.Text = "Update Client";
            btnConfirm.Text = "Update Client";
            ClearFields();

            //populate components with current client info
            rbtnIndvidual.Enabled = false;
            rbtnBusiness.Enabled = false;
            if (currentClient is IndividualClient iCl)
            {
                lblBusinessName.Hide();
                txtBusinessName.Hide();
                rbtnIndvidual.Checked = true;

                //populate client current contracts
                iContracts = iCl.Contracts;
                cbxCurrentContracts.Items.Add(iContracts.ToArray());
            }
            else if (currentClient is BusinessClient bCl)
            {
                lblBusinessName.Show();
                txtBusinessName.Show();
                txtBusinessName.Text = bCl.BusinessName;
                rbtnBusiness.Checked = true;

                //populate client current contracts
                bContracts = bCl.Contracts;
                cbxCurrentContracts.Items.Add(bContracts.ToArray());
            }

            txtName.Text = currentClient.Person.FirstName;
            txtSurname.Text = currentClient.Person.LastName;
            dtpDOB.Value = currentClient.Person.BirthDay;
            txtCellphone.Text = currentClient.Person.CellphoneNumber;
            txtTelephone.Text = currentClient.Person.TellephoneNumber;
            txtEmail.Text = currentClient.Person.Email;

            txtStreet.Text = currentClient.Address.Street;
            txtCity.Text = currentClient.Address.City;
            txtPostalCode.Text = currentClient.Address.PostalCode;
            cbxProvince.SelectedItem = currentClient.Address.Province;

            cbxStatus.SelectedItem = currentClient.Status;
            rtbNotes.Text = currentClient.Notes;
            
        }

        private void ReadFields()
        {
            // TODO: 2. do we need validation and verification?

            currentClient.Person.FirstName = txtName.Text;
            currentClient.Person.LastName = txtSurname.Text;
            currentClient.Person.BirthDay = dtpDOB.Value;//check formatting
            currentClient.Person.CellphoneNumber = txtCellphone.Text;
            currentClient.Person.TellephoneNumber = txtTelephone.Text;
            currentClient.Person.Email = txtEmail.Text;

            currentClient.Address.Street = txtStreet.Text;
            currentClient.Address.City = txtCity.Text;
            currentClient.Address.PostalCode = txtPostalCode.Text;
            currentClient.Address.Province = cbxProvince.SelectedItem.ToString();

            currentClient.Status = cbxStatus.SelectedItem.ToString();
            currentClient.Notes = rtbNotes.Text;//Text vs rtf?
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lblTask.Text == "Register Client")
            {
                RegisterMode();
            }
            else
            {
                UpdateMode();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ReadFields();
            if (rbtnIndvidual.Checked)
            {
                IndividualClient aClient = (IndividualClient)currentClient;
                // TODO: Add Contract and Service shit
                /*iContracts.SaveAll();
                aClient.Contracts = iContracts;*/
                aClient.Save();
            }
            else 
            {
                BusinessClient bClient = (BusinessClient)currentClient;
                bClient.BusinessName = txtBusinessName.Text;
                // TODO: Add Contract and Service shit
                /*bContracts.SaveAll();
                bClient.Contracts = bContracts;*/
                bClient.Save();
            }
        }

        private void cbxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbContractDetails.Text = "Contract Details:\n" + cbxContracts.SelectedItem.ToString();
        }

        private void cbxServiceLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO:  Do we need to expand on these details?, maybe we can use enums here
            switch (cbxServiceLevel.SelectedIndex)
            {
                case 0: rtbServiceLevelDetails.Text = "Service level details:\n"
                                                    + "Response time: 48+ hours\n  "
                                                    + "Repair times: Between 08:00 and 18:00 on Weekdays."
                                                    + "              No repair ons weekends";
                    break;
                case 1:
                    rtbServiceLevelDetails.Text = "Service level details:\n"
                                                + "Response time: 24+ hours\n  "
                                                + "Repair times: Between 06:00 and 20:00 on Weekdays."
                                                +"              No repair ons weekends";

                    break;
                case 2:
                    rtbServiceLevelDetails.Text = "Service level details:\n"
                                                + "Response time: 12+ hours\n  "
                                                + "Repair times: Any time during weekdays"
                                                + "              Between 08:00 and 18:00 on weekends";
                    break;
                case 3:
                    rtbServiceLevelDetails.Text = "Service level details:\n"
                                                + "Response time: 24/7 instant responses\n  "
                                                + "Repair times: If technicians are available they can assist at any time that suits the client ";
                    break;
                default:
                    rtbServiceLevelDetails.Text = "Service level details:\n";
                    break;
            }

        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            // TODO: Add Contract to ClientContract (Indvidual or business), global class list?

            //selectedContract = cbxContracts.SelectedItem;//Convert selected contract to contract object

            // TODO: Calculate contract effecitive date, probably after latest contracts end date
            //DateTime effectiveDate = ;

            if (rbtnIndvidual.Checked)
            {
                //add Contract to ClientContract List              
                /*IndividualClientContract iClientContract = new IndividualClientContract(currentClient.ClientID, contract, effectiveDate);
                
                //add ClientContract to ClientContract global list
                iContracts.Add(iClientContract);*/

            }
            else
            {

                //add Contract to ClientContract List
                /*BusinessClientContract bClientContract = new BusinessClientContract(currentClient.ClientID, contract, effectiveDate);
                
                //add ClientContract to ClientContract global list
                bContracts.Add(bClientContract);*/

            }

        }

        private void btnModifyContract_Click(object sender, EventArgs e)
        {
            // TODO: Change selected contract's service level
            //selectedContract = cbxContracts.SelectedItem;//Convert selected contract to contract object
            selectedContract.ServiceLevel = cbxServiceLevel.SelectedItem.ToString();
            selectedContract.Save();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // TODO: Prompt if user wants to save or disregard changes
            //if a client is being registered we need to check if all fields are completed otherwise the client cannot be saved.
        }
    }
}
