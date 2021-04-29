using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    public partial class ClientMaintenance : Form
    {
        private Client currentClient = null;
        private Contract selectedClientContract => (Contract)cbxCurrentContracts.SelectedItem;
        private Contract selectedContract => (Contract)cbxContracts.SelectedItem;

        public bool registerMode { get; set; } //bool for logic if form is in registration mode or update mode

        public ClientMaintenance()
        {
            InitializeComponent();
            ciwMain.Hide();
            RegisterMode();
        }      

        public ClientMaintenance(Client client) 
        {
            InitializeComponent();
            currentClient = client;
            ciwMain.Client = client;
            UpdateMode();
        }

        /// <summary>
        /// Reset and reload form controls
        /// </summary>
        private void ResetControls()
        {
            rbtnIndvidual.Enabled = true;
            rbtnBusiness.Enabled = true;
            rbtnIndvidual.Checked = false;
            rbtnBusiness.Checked = false;
            txtBusinessName.Clear();
            txtName.Clear();
            txtSurname.Clear();
            dtpDOB.Value = DateTime.Now;
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
            cbxCurrentContracts.Text = "";
            //BaseList<Contract> contracts = new BaseList<Contract>();
            //contracts.FillAll();
            //cbxContracts.Items.AddRange(contracts.ToArray());
            rtbContractDetails.Clear();
            rtbContractDetails.Text = "Contract details:\n";


            //Service level items won't change?
            cbxServiceLevel.Text = "Choose a service level";

            rtbServiceLevelDetails.Clear();
            rtbServiceLevelDetails.Text = "Service level details:\n";
        }

        /// <summary>
        /// Switch Controls into register mode for a new client.
        /// </summary>
        private void RegisterMode()
        {
            lblTask.Text = "Register Client";
            btnConfirm.Text = "Finalize Registration";
            ResetControls();
            registerMode = true; //sets form to registration mode
        }

        /// <summary>
        /// Switch controls into update mode for a preexisting client.
        /// </summary>
        private void UpdateMode()
        {
            lblTask.Text = "Update Client";
            btnConfirm.Text = "Update Client";
            ResetControls();

            //populate components with current client info
            rbtnIndvidual.Enabled = false;
            rbtnBusiness.Enabled = false;
            if (currentClient is IndividualClient)
            {
                lblBusinessName.Hide();
                txtBusinessName.Hide();
                rbtnIndvidual.Checked = true;
            }
            else if (currentClient is BusinessClient bCl)
            {
                lblBusinessName.Show();
                txtBusinessName.Show();
                txtBusinessName.Text = bCl.BusinessName;
                rbtnBusiness.Checked = true;
            }

            Populate();

            registerMode = false; //sets form to update mode
        }

        #region Populate
        /// <summary>
        /// Populate currentClient into form
        /// </summary>
        private void Populate()
        {
            if (currentClient is null)
            {
                throw new PSSObjectIsNull("Client not initialized");
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


            BaseList<Contract> contracts = new BaseList<Contract>(); //move to local?
            contracts = currentClient.GetContracts();
            cbxCurrentContracts.DisplayMember = "ContractName";
            cbxCurrentContracts.Items.AddRange(contracts.ToArray());
        }

        #endregion


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (registerMode)
            {
                RegisterMode();
            }
            else
            {
                UpdateMode();
            }
        }

        #region Confirm
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (registerMode == false)
            {
                ConfirmModify();
            }
            else
            {
                ConfirmRegister();
            }            

            Close();
        }

        private void ConfirmRegister()
        {
            Person newPerson = new Person(txtName.Text, txtSurname.Text, dtpDOB.Value, txtCellphone.Text, txtTelephone.Text, txtEmail.Text); //Creates a new person
            Address newAddress = new Address(txtStreet.Text, txtCity.Text, txtPostalCode.Text, cbxProvince.Text); //Creates new address
            //TODO: get client type
            if (rbtnIndvidual.Checked)
            {
                IndividualClient individualClient = new IndividualClient("", cbxStatus.Text, rtbNotes.Text, newAddress, newPerson);
                currentClient = individualClient;
            }
            else
            {
                BusinessClient businessClient = new BusinessClient(txtBusinessName.Text, "", cbxStatus.Text, rtbNotes.Text, newAddress, newPerson);
                currentClient = businessClient;
            }

            currentClient.Save();
        }

        private void ConfirmModify()
        {
            currentClient.Person.FirstName = txtName.Text;
            currentClient.Person.LastName = txtSurname.Text;
            currentClient.Person.BirthDay = dtpDOB.Value;
            currentClient.Person.CellphoneNumber = txtCellphone.Text;
            currentClient.Person.TellephoneNumber = txtTelephone.Text;
            currentClient.Person.Email = txtEmail.Text;

            currentClient.Address.Street = txtStreet.Text;
            currentClient.Address.City = txtCity.Text;
            currentClient.Address.PostalCode = txtPostalCode.Text;
            currentClient.Address.Province = cbxProvince.SelectedItem.ToString();

            currentClient.Status = cbxStatus.SelectedItem.ToString(); //TODO: Add no-choice functionality
            currentClient.Notes = rtbNotes.Text;//Text vs rtf?

            if (rbtnIndvidual.Checked)
            {
                IndividualClient aClient = (IndividualClient)currentClient;
                aClient.Save();
            }
            else
            {
                BusinessClient bClient = (BusinessClient)currentClient;
                bClient.BusinessName = txtBusinessName.Text;
                bClient.Save();
            }
        }
        #endregion

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
            //TODO: What does effective date mean again?
            currentClient.AddContract(selectedContract, DateTime.Now);
        }

        private void btnModifyContract_Click(object sender, EventArgs e)
        {
            //selectedClientContract = selectedContract; //TODO: Figure out this set
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure? Changes will NOT be saved!", "Discard and Go Back", MessageBoxButtons.YesNo))
            {
                case DialogResult.None:
                case DialogResult.No:
                    goto default; //fall-through goto default incase we want to add additional functionality.

                case DialogResult.Yes:
                    this.Close();
                    break;

                default:
                    return;
            }
        }

        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            // TODO go to contract maintenance
            ContractMaintenance cm = new ContractMaintenance();
            Hide();
            cm.ShowDialog();
            Show();
        }

        private void rbtnIndvidual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIndvidual.Checked)
            {
                lblBusinessName.Hide();
                txtBusinessName.Hide();
            }
        }

        private void rbtnBusiness_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBusiness.Checked)
            {
                lblBusinessName.Show();
                txtBusinessName.Show();
            }
        }
    }
}
