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

            cbxNonClientPerson.DisplayMember = "FullName";
            cbxNonClientPerson.Items.Clear();
            cbxNonClientPerson.Items.AddRange(NonClients.ToArray()); //NOTE: cbxNonClientPerson is only used to change the exsitng or new clients. It should not be used as the main client sellect

            lsbxBusinessPeople.DisplayMember = "DisplayMember";

            cbxCurentContract.DisplayMember = "DisplayMember";
            cbxCurentContract.DataSource = AllContracts;
            cbxCurentContract.SelectedItem = currentClient?.GetCurrentContract();

            lsbxPreviousContracts.SelectedIndex = -1;
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
            registerMode = true; //sets form to registration mode

            lblTask.Text = "Register Client";
            btnClient.Text = "Finalize Registration";

            cbxChooseClient.Enabled = false;
            cbxChooseClient.SelectedIndex = -1;

            rbtnIndvidual.Enabled = true;
            rbtnBusiness.Enabled = true;

            rbtnBusiness.Checked = true; //controll pivot onChenged event
            //we do this to set up something, anything, on the !
        }

        /// <summary>
        /// Switch controls into update mode for a preexisting client.
        /// </summary>
        private void UpdateMode()
        {
            registerMode = false; //sets form to update mode

            lblTask.Text = "Update Client";
            btnClient.Text = "Update Client";
            cbxChooseClient.Enabled = true;

            cbxChooseClient.SelectedItem = currentClient;

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
        private bool registered = false;
        private void ConfirmRegister()
        {
            registered = true;
            PopulateClientFromControls(currentClient); //created new client in radio controls with type
            currentClient.SetNextID();
            Console.WriteLine(currentClient.ClientID);
            currentClient.Save();
            Hide();
        }

        public Client GetNewlyRegistered()
        {
            if (registered)
            {
                return currentClient;
            }
            else return null;
        }

        private void ConfirmModify()
        {
            PopulateClientFromControls(currentClient);
            Close();
        }
        #endregion

        #region Client
        private Client currentClient = null;
        private List<Client> Clients = Client.GetAllClients();

        private void cbxChooseClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (registerMode)
            {
                return;
            }

            currentClient = (Client)cbxChooseClient.SelectedItem;

            rbtnIndvidual.Enabled = false;
            rbtnBusiness.Enabled = false;

            if (currentClient is IndividualClient) //cbx should be changed when radio butons are changed
            {
                rbtnIndvidual.Checked = true;

                cbxNonClientPerson.Enabled = false;
            }
            else if (currentClient is BusinessClient bCl)
            {
                txtBusinessName.Text = bCl.BusinessName;
                rbtnBusiness.Checked = true;

                cbxNonClientPerson.Enabled = true;
                //NonClients.Add(bCl);
                //too scared to add that line, also might not need it.
            }

            cbxNonClientPerson.Text = currentClient.Person.DisplayMember;
            //NOTE: if you choose a new one you won't be able to sellect the old one

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
            }

            lblBusinessName.Visible = businessChecked;
            txtBusinessName.Visible = businessChecked;

            grbBPeople.Enabled = businessChecked;
            btnAddToBP.Enabled = businessChecked;
        }


        #endregion

        private void cbxNonClientPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbxExistingPeople.SelectedItem = cbxNonClientPerson.SelectedItem;
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (registerMode)
            {
                ConfirmRegister();
                MessageBox.Show("Client Registration complete.", "Success!", MessageBoxButtons.OK);
            }
            else
            {
                ConfirmModify();
                MessageBox.Show("Client successfully updated.", "Success!", MessageBoxButtons.OK);
            }
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
            cbxNonClientPerson.SelectedItem = People.Find(p => p.PersonID == currentClient.Person.PersonID);

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

            cbxNonClientPerson.Items.Clear();
            cbxNonClientPerson.Items.AddRange(NonClients.ToArray());
        }

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

            cbxNonClientPerson.Text = ((Person)lsbxExistingPeople.SelectedItem).DisplayMember;
        }

        #endregion

        #region Contracts
        private BaseList<Contract> AllContracts = BaseList<Contract>.GrabAll();
        private Contract selectedContract => (Contract)cbxCurentContract.SelectedItem;

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            currentClient.AddContract(selectedContract, DateTime.Now);
        }

        private void cbxCurentContract_SelectedIndexChanged_1(object sender, EventArgs e) //Maybe on text changed?
        {
            iwMainContract.Contract = (Contract)cbxCurentContract.SelectedItem;
        }

        #endregion

        private void btnCM_Click(object sender, EventArgs e)
        {
            //Only needed if we want to pass a client to Contract Maintenance
            //if (currentClient is null)
            //{
            //    MessageBox.Show("No Client Selected!", "Failure!", MessageBoxButtons.OK);
            //    return;
            //}

            ContractMaintenance CM = new ContractMaintenance();
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
