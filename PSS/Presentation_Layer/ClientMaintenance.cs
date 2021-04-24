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

        public ClientMaintenance()
        {
            InitializeComponent();
            RegisterMode();
        }      

        public ClientMaintenance(Client client) : this()
        {
            currentClient = client;
            UpdateMode();
        }

        #region Methods

        private void ClearFields()
        {
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

            /*Need to figure out about Contracts for client, currently a client's Contracts Service level can be changed,
            and additional contracts can be added, do we need anything else like a direct link to edit the contract or SAL?*/

            cbxCurrentContracts.Items.Clear();
            cbxCurrentContracts.Text = "None at the moment";

            //Add all Contracts?
            cbxContracts.Items.Clear();
            //cbxContracts.Items.AddRange()
            rtbContractDetails.Clear();

            //Service level items won't change?
            rtbServiceLevelDetails.Clear();
            

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

            //populate copmonents with current client info
            if (currentClient is IndividualClient)
            {
                lblBusinessName.Hide();
                txtBusinessName.Hide();
            }
            else
            {
                lblBusinessName.Show();
                txtBusinessName.Show();
                //txtBusinessName.Text = currentClient.BusinessIdentifier;//Need CBusinessClient's business name
            }
        }

        private void ReadFields()
        {
            //TODO: Here fields are read into variable to register a new client, or maybe update it?
        }

        #endregion

        []
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ReadFields();
        }

    }
}
