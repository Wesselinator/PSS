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
            lsbxContracts.DataSource = AllContracts;
            cbxContractService.DataSource = AllService;
        }

        #region Data

        private readonly BaseList<Contract> AllContracts = BaseList<Contract>.GrabAll();
        private readonly BaseList<Service> AllService = BaseList<Service>.GrabAll();

        #endregion

        #region Stuff Changes

        private void rbSpecifiedQuantity_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            nudSpesificQuanity.Enabled = rb.Checked;
        }

        private void cbxAllContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbxContractInfo.Enabled = true;
        }

        private void lsbxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            rtbContractDetails.Text = lb.SelectedItem.ToString(); //TODO: create nice Contract toFormattedString
        }

        #endregion

        #region Butons

        private void btnConfirmContract_Click(object sender, EventArgs e)
        {
            if (cbxAllContracts.SelectedIndex == -1)
            {
                Contract contract = new Contract(txtContractName.Text, cbxContractSL.Text, dtpContractStart.Value, dtpContractEnd.Value, (int)Math.Round(numDuration.Value), nudMonthlyFee.Value); //create new Contract
                contract.
                contract.Save();
                AllContracts.Add(contract); //reduce database acesses.

                return;
            }


        }

        private void btnStopContract_Click(object sender, EventArgs e)
        {
            Contract contract = (Contract)cbxAllContracts.SelectedItem;
            contract.EndDate = DateTime.Now;
            contract.Save();

            MessageBox.Show("Success!", "Contract stoped!");
        }

        private void btnNewContract_Click(object sender, EventArgs e)
        {
            cbxAllContracts.SelectedIndex = -1;
            cbxAllContracts.Enabled = false;
        }

        #endregion


    }
}
