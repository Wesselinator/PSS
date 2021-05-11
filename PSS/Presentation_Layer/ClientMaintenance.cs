using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    public partial class ClientMaintenance : Form
    {
        public bool registerMode { get; set; } //bool for logic if form is in registration mode or update mode

        public ClientMaintenance()
        {
            InitializeComponent();
            InitializeLists();
            RegisterMode();
        }      

        public ClientMaintenance(Client client) 
        {
            InitializeComponent();
            InitializeLists();
            currentClient = client;
            UpdateMode();
        }

        private void InitializeLists()
        {
            lsbxExistingPeople.DisplayMember = "DisplayMember";
            lsbxBusinessPeople.Items.Clear();
            lsbxExistingPeople.Items.AddRange(People.ToArray());

            cbxClientPerson.DisplayMember = "DisplayMember";
            cbxClientPerson.Items.Clear();
            cbxClientPerson.Items.AddRange(NonClients.ToArray());

            lsbxBusinessPeople.DisplayMember = "DisplayMember";

            cbxCurentContract.DisplayMember = "DisplayMember";
            cbxCurentContract.DataSource = AllContracts;
            cbxCurentContract.SelectedItem = currentClient?.GetCurrentContract();

            lsbxPreviousContracts.DisplayMember = "DisplayMember";
            lsbxPreviousContracts.DataSource = currentClient?.GetContracts();

            cbxChooseClient.DisplayMember = "DisplayMember";
            cbxChooseClient.DataSource = Clients;
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
            nudPostalCode.Value = 0;

            cbxProvince.SelectedIndex = -1;
            cbxProvince.Text = "Choose...";
            cbxStatus.SelectedIndex = -1;
            cbxStatus.Text = "Choose...";


            //Add all Contracts
            cbxCurentContract.Items.Clear();
            cbxCurentContract.Text = "None at the moment";

            grbPerson.Text = "Client Details";

            lsbxBusinessPeople.SelectedIndex = -1;
        }

        /// <summary>
        /// Switch Controls into register mode for a new client.
        /// </summary>
        private void RegisterMode()
        {
            lblTask.Text = "Register Client";
            btnClient.Text = "Finalize Registration";

            cbxChooseClient.Enabled = false;
            rbtnIndvidual.Enabled = true;
            rbtnBusiness.Enabled = true;
            rbtnBusiness.Checked = true; //controll pivot onChenged event

            registerMode = true; //sets form to registration mode
        }

        /// <summary>
        /// Switch controls into update mode for a preexisting client.
        /// </summary>
        private void UpdateMode()
        {
            lblTask.Text = "Update Client";
            btnClient.Text = "Update Client";
            cbxChooseClient.Enabled = true;

            cbxChooseClient.SelectedItem = currentClient;

            registerMode = false; //sets form to update mode

            Populate();
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

            PopulateControlsFromClient(currentClient);

            cbxCurentContract.SelectedItem = currentClient?.GetCurrentContract();

            lsbxPreviousContracts.DataSource = currentClient?.GetContracts();

            //BaseList<Contract> contracts = new BaseList<Contract>(); //move to local?
            //contracts = currentClient.GetContracts();
            //cbxCurentContract.DisplayMember = "ContractName";
            //cbxCurentContract.Items.AddRange(contracts.ToArray());
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
        private string GetStatus => cbxStatus.SelectedIndex == -1 ? "Status Unknown" : cbxStatus.Text;
        private void ConfirmRegister()
        {
            PopulateClientFromControls(currentClient); //created new client in radio controls with type

            currentClient.Save();
        }

        private void ConfirmModify()
        {
            PopulateClientFromControls(currentClient);

            currentClient.Save();
        }
        #endregion

        //private void cbxServiceLevel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // TODO:  Do we need to expand on these details?, maybe we can use enums here
        //    switch (cbxServiceLevel.SelectedIndex)
        //    {
        //        case 0: rtbServiceLevelDetails.Text = "Service level details:\n"
        //                                            + "Response time: 48+ hours\n  "
        //                                            + "Repair times: Between 08:00 and 18:00 on Weekdays."
        //                                            + "              No repair ons weekends";
        //            break;
        //        case 1:
        //            rtbServiceLevelDetails.Text = "Service level details:\n"
        //                                        + "Response time: 24+ hours\n  "
        //                                        + "Repair times: Between 06:00 and 20:00 on Weekdays."
        //                                        +"              No repair ons weekends";

        //            break;
        //        case 2:
        //            rtbServiceLevelDetails.Text = "Service level details:\n"
        //                                        + "Response time: 12+ hours\n  "
        //                                        + "Repair times: Any time during weekdays"
        //                                        + "              Between 08:00 and 18:00 on weekends";
        //            break;
        //        case 3:
        //            rtbServiceLevelDetails.Text = "Service level details:\n"
        //                                        + "Response time: 24/7 instant responses\n  "
        //                                        + "Repair times: If technicians are available they can assist at any time that suits the client ";
        //            break;
        //        default:
        //            rtbServiceLevelDetails.Text = "Service level details:\n";
        //            break;
        //    }

        //}

        #region Client
        private Client currentClient = null;
        private List<Client> Clients = Client.GetAllClients();

        private void cbxChooseClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentClient = (Client)cbxChooseClient.SelectedItem;

            rbtnIndvidual.Enabled = false;
            rbtnBusiness.Enabled = false;

            if (currentClient is IndividualClient)
            {
                rbtnIndvidual.Checked = true;
            }
            else if (currentClient is BusinessClient bCl)
            {
                txtBusinessName.Text = bCl.BusinessName;
                rbtnBusiness.Checked = true;
            }

            Populate();
        }

        #region IndividualClient

        private void rbtnIndvidual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIndvidual.Checked)
            {
                lblPerson.Text = "Person";

                if (registerMode)
                {
                    currentClient = new IndividualClient();
                }
                else
                {
                    cbxClientPerson.Enabled = false;
                    cbxClientPerson.Text = currentClient.DisplayMember;
                }
            }
        }

        #endregion

        #region BusinessClient

        private void rbtnBusiness_CheckedChanged(object sender, EventArgs e)
        {
            bool businessChecked = rbtnBusiness.Checked;
            if (businessChecked)
            {
                lblPerson.Text = "Contact Person";

                if (registerMode)
                {
                    currentClient = new BusinessClient();
                }
                else
                {
                    cbxClientPerson.Enabled = true;
                }
            }

            lblBusinessName.Enabled = businessChecked;
            txtBusinessName.Enabled = businessChecked;

            grbBPeople.Enabled = businessChecked;
            btnAddToBP.Enabled = businessChecked;
        }


        #endregion

        private void cbxClientPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbxExistingPeople.SelectedItem = cbxClientPerson.SelectedItem;
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (registerMode)
            {
                ConfirmRegister(); //aaaaaa
            }
            else
            {
                ConfirmModify();
            }

            Close();
        }

        private void PopulateClientFromControls(Client client)
        {
            PopulatePersonFromControls(client.Person);
            PopulateAdressFromControls(client.Address);

            client.Notes = rtbNotes.Text;
            client.Status = cbxStatus.Text;
            client.Type = cbxType.Text;

            if (client is BusinessClient bc)
            {
                bc.BusinessName = txtBusinessName.Text;
            }
        }

        private void PopulateControlsFromClient(Client client)
        {
            PopulateControlsFromPerson(client.Person);
            PopulateControlsFromAdress(client.Address);

            rtbNotes.Text = client.Notes;
            cbxStatus.Text = client.Status;
            cbxType.Text = client.Type;

            if (client is BusinessClient bc)
            {
                txtBusinessName.Text = bc.BusinessName;

                lsbxBusinessPeople.Items.Clear();
                lsbxBusinessPeople.Items.AddRange(bc.GetBusinessPersons().ToArray());
            }
        }

        private void PopulateAdressFromControls(Address address)
        {
            address.City = txtCity.Text;
            address.PostalCode = nudPostalCode.Text.PadLeft(4, '0');
            address.Province = cbxProvince.Text;
            address.Street = txtStreet.Text;
        }

        private void PopulateControlsFromAdress(Address address)
        {
            txtCity.Text = address.City;
            nudPostalCode.Text = address.PostalCode;
            txtStreet.Text = address.Street;
            cbxProvince.Text = address.Province;
        }

        #endregion

        #region People

        private BaseList<Person> People = BaseList<Person>.GrabAll();
        private BaseList<Person> NonClients = Person.GetNonClients();
        private bool listSelected(Person p) => p.PersonID == ((Person)lsbxExistingPeople.SelectedItem).PersonID;
        private Person selectedPersonInExisting => People.Find(listSelected);
        private Person selectedPersonInNonClient => NonClients.Find(listSelected);
        private bool AddMode = true;

        private void btnPerson_Click(object sender, EventArgs e)
        {
            if (AddMode)
            {
                Person person = new Person(txtName.Text, txtSurname.Text, dtpDOB.Value, txtCellphone.Text, txtTelephone.Text, txtEmail.Text);
                person.Save();
                People.Add(person);
                NonClients.Add(person);

                MessageBox.Show("New Person Sucessfully Saved!", "Success!", MessageBoxButtons.OK);
            }
            else
            {
                PopulatePersonFromControls(selectedPersonInExisting);
                PopulatePersonFromControls(selectedPersonInNonClient); //This is a lazy way of ceeping the 2 list synced. I'm not allowed to use Binding lists
                selectedPersonInExisting.Save();

                MessageBox.Show("Person Sucessfully Modified!", "Success!", MessageBoxButtons.OK);
            }

            btnPerson.Enabled = false;

            lsbxExistingPeople.Items.Clear();
            lsbxExistingPeople.Items.AddRange(People.ToArray());

            cbxClientPerson.Items.Clear();
            cbxClientPerson.Items.AddRange(NonClients.ToArray());
        }

        //TODO: add a nice enabled/disabled on the Person txt
        private void btnModifyPerson_Click(object sender, EventArgs e)
        {
            if (lsbxExistingPeople.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a person", "Failure!", MessageBoxButtons.OK);
                return;
            }

            ClearPerson();
            btnPerson.Text = "Modify Person";
            AddMode = false;
            btnPerson.Enabled = true;

            PopulateControlsFromPerson(selectedPersonInExisting);
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            ClearPerson();
            btnPerson.Text = "Add Person";
            AddMode = true;
            btnPerson.Enabled = true;
        }
        //---------

        private void ClearPerson()
        {
            txtName.Clear();
            txtSurname.Clear();
            dtpDOB.Value = DateTime.Now;
            txtCellphone.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
        }

        private void PopulatePersonFromControls(Person person)
        {
            person.FirstName = txtName.Text;
            person.LastName = txtSurname.Text;
            person.BirthDay = dtpDOB.Value;
            person.CellphoneNumber = txtCellphone.Text;
            person.TellephoneNumber = txtTelephone.Text;
            person.Email = txtEmail.Text;
        }

        private void PopulateControlsFromPerson(Person person)
        {
            txtName.Text = person.FirstName;
            txtSurname.Text = person.LastName;
            dtpDOB.Value = person.BirthDay;
            txtTelephone.Text = person.TellephoneNumber;
            txtCellphone.Text = person.CellphoneNumber;
            txtEmail.Text = person.Email;
        }

        private void btnAddToBP_Click(object sender, EventArgs e)
        {
            if (rbtnBusiness.Checked)
            {
                if (currentClient is BusinessClient bc)
                {
                    if (bc.GetBusinessPersons().Contains(selectedPersonInExisting))
                    {
                        MessageBox.Show("This business already contains this Person!", "Failure!", MessageBoxButtons.OK);
                        return;
                    }

                    bc.AddBusinessPersons(selectedPersonInExisting, txtRole.Text);

                    lsbxBusinessPeople.Items.Clear();
                    lsbxBusinessPeople.Items.AddRange(bc.GetBusinessPersons().ToArray());
                }
            }
        }

        private void lsbxExistingPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddToBP.Text = "Add " + selectedPersonInExisting.FirstName + " To Business People";

            PopulateControlsFromPerson(selectedPersonInExisting);
        }

        #endregion

        #region Contracts
        private BaseList<Contract> AllContracts = BaseList<Contract>.GrabAll();
        private Contract selectedContract => (Contract)cbxCurentContract.SelectedItem;

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            currentClient.AddContract(selectedContract, DateTime.Now);
        }

        private void btnModifyContract_Click(object sender, EventArgs e)
        {
            //selectedClientContract = selectedContract; //TODO: Figure out this set
        }

        #endregion

        private void btnCM_Click(object sender, EventArgs e)
        {
            if (currentClient is null)
            {
                MessageBox.Show("No Client Selected!", "Failure!", MessageBoxButtons.OK);
                return;
            }

            ClientMaintenance CM = new ClientMaintenance(currentClient);
            this.Hide();
            CM.ShowDialog();
            this.Show();
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
    }
}
