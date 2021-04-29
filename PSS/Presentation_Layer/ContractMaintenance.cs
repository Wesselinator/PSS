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
    public partial class ContractMaintenance : Form
    {
        public ContractMaintenance()
        {
            InitializeComponent();
            LoadViews();
        }

        private void LoadViews()
        {
            lsbxContracts.DisplayMember = "DisplayMember";
            lsbxContracts.DataSource = AllContracts;

            cbxContractService.DisplayMember = "DisplayMember";
            cbxContractService.DataSource = AllServices;

            cbxServiceChange.DisplayMember = "DisplayMember";
            cbxServiceChange.DataSource = AllServices;
        }

        private void LoadCurrentService()
        {
            lsbxCurrentService.DisplayMember = "DisplayMember";
            lsbxCurrentService.Items.Clear();
            lsbxCurrentService.Items.AddRange(currentContract.GetServices().ToArray());  //DataBind?
        }

        #region Data

        private readonly BaseList<Contract> AllContracts = BaseList<Contract>.GrabAll();
        private readonly BaseList<Service> AllServices = BaseList<Service>.GrabAll();

        #endregion

        #region Contracts

        #region Stuff Changes

        private void rbSpecifiedQuantity_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            nudSpecificQuanity.Enabled = rb.Checked;
        }
        private void rbUnlimited_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                nudSpecificQuanity.Value = 0; //TODO: what is infinite???
            }
        }


        private void cbxAllContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbxContractInfo.Enabled = true;
            LoadCurrentService();
        }

        #endregion

        #region Butons

        private Contract currentContract = null;
        private void btnConfirmContract_Click(object sender, EventArgs e)
        {
            currentContract.SetNextID();
            currentContract.ContractName = txtContractName.Text;
            currentContract.StartDate = dtpContractStart.Value;
            currentContract.EndDate = dtpContractEnd.Value;
            currentContract.ContractDurationInMonths = (int)Math.Round(numDuration.Value);
            currentContract.MonthlyFee = nudMonthlyFee.Value;

            currentContract.Save();
            AllContracts.Add(currentContract); //reduce database acesses.
        }

        private void btnNewContract_Click(object sender, EventArgs e)
        {
            cbxAllContracts.SelectedIndex = -1;
            cbxAllContracts.Enabled = false;
            currentContract = new Contract();
        }

        private void btnAddServiceToContract_Click(object sender, EventArgs e)
        {
            Service service = (Service)cbxContractService.SelectedItem;
            int quantity = (int)Math.Round(nudSpecificQuanity.Value);

            currentContract.AddService(service, rtbAgreement.Text, quantity);
        }

        private void btnStopContract_Click(object sender, EventArgs e)
        {
            Contract contract = (Contract)cbxAllContracts.SelectedItem;
            contract.EndDate = DateTime.Now;
            contract.Save();

            MessageBox.Show("Success!", "Contract stoped!");
        }

        #endregion

        #endregion

        private void btnRemoveContract_Click(object sender, EventArgs e)
        {
            //TODO: Reconsider what happens here
        }

        #region Services

        #region Things Change
        private Service currentService = null;
        private void rbModifyService_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmService.Enabled = true;
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                btnConfirmService.Text = "Modify Service";
                currentService = (Service)cbxServiceChange.SelectedItem;
            }
        }
        private void rbCreateService_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmService.Enabled = true;
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                cbxServiceChange.SelectedIndex = -1;
                btnConfirmService.Text = "Create Service";

                currentService = null; //unset currentService, hopefully not unsetting the list
                currentService = new Service();
            }
        }

        #endregion

        #region Buttons

        private void btnConfirmService_Click(object sender, EventArgs e)
        {
            if (rbCreateService.Checked)
            {
                currentService.SetNextID();
            }

            currentService.ServiceName = txtServiceName.Text;
            currentService.Type = cbxServiceType.Text;
            currentService.ServiceDescription = txtServiceDescription.Text;     //TODO: change to rich text box

            currentService.Save();
            AllServices.Add(currentService); //reduce database acesses
        }

        #endregion

        #endregion

        #region Performance

        private Contract currentPerformance = null;
        private void lsbxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            rtbContractDetails.Text = lb.SelectedItem.ToString(); //TODO: create nice Contract toFormattedString
            currentPerformance = (Contract)lsbxContracts.SelectedItem;
            CalculateClientPerformance();
        }

        private void CalculateClientPerformance()
        {
            //TODO: Calculate in class or here? How do calculate? How make numbers go here?
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
