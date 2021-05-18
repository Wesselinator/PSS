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
    public partial class ContractInfoWidget : UserControl
    {
        private Contract contract = null;

        public Contract Contract
        {
            get => contract;

            set
            {
                contract = value;
                if (contract is null) Empty(); else Populate();
            }
        }

        public ContractInfoWidget()
        {
            InitializeComponent();
        }

        #region populate

        public void Empty()
        {
            lblContractName.Text = "Basic Contract";
            lblBusinessIdentifier.Text = "2021AD001234";
            lblServiceLevel.Text = "Peasant";
            lblDurationInMonth.Text = "24";
            lblMonthlyFee.Text = "R 1 000.00";
            lblContractStartDate.Text = "2021/04/01";
            lblEndDate.Text = "2022/04/01";
        }

        public void Populate()
        {
            if (Contract is null)
            {
                throw new PSSObjectIsNull("Can't populate a null contract");
            }
            else
            {
                lblContractName.Text = contract.ContractName;
                lblBusinessIdentifier.Text = contract.BusinessIdentifier;
                lblServiceLevel.Text = contract.ServiceLevel;
                lblDurationInMonth.Text = contract.ContractDurationInMonths.ToString();
                lblMonthlyFee.Text = contract.MonthlyFee.ToString();
                lblContractStartDate.Text = contract.StartDate.ToString();
                lblEndDate.Text = contract.EndDate.ToString();
            }
        }

        #endregion
    }
}
