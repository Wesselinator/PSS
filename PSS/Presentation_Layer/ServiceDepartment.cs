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
    public partial class ServiceDepartment : Form
    {
        private readonly Client currentClient = null;
        private Technician currentTech = null;
        private string requestType = null;

        public ServiceDepartment()
        {
            InitializeComponent();
        }

        public ServiceDepartment(Client client) : this()
        {
            this.currentClient = client;
            PopulateServiceRequests();
            PopulateSAL();          
        }

        #region Methods

        private void PopulateSAL()
        {
            // TODO: Fill Client SAL
            //need some kind of method like this currentClient.ActiveContract()
            if (currentClient is IndividualClient iCl)
            {
                //IndividualClientContract iClientContract = ;
            }
            else if (currentClient is BusinessClient bCl)
            {
                //BusinessClientContract bClientContract;
            }

            ServiceLevelAgreement clientSAL = new ServiceLevelAgreement();
            rtbSALdetails.Text = clientSAL.ToString();
        }
       
        private void PopulateServiceRequests()
        {
            //Get current Client's service requests
            BaseList<ServiceRequest> clientSerivceRequests = currentClient.GetServiceRequests();
            //TODO Filter only Requests that don't have a task yet, maybe currentClient.GetActiveServiceRequest instead of above

            //TODO: Fill lstvServiceRequests with above


        }

        private void FilterTechnicians()
        {
            // TODO: populate lstvAvailableTechs with relevant Technician specialities 
            //BaseList<Technician> availableTechs = Technician.GetFilteredTechnicians(requestType);
        }

        #endregion

        private void ServiceDepartment_Load(object sender, EventArgs e)
        {
            
        }

        private void lstvServiceRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTechnicians();           
        }        

        private void lstvAvailableTechs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Change currentTech
            // TODO: Change rtbTechDetails to selected technician
        }

        private void btnReAssignTech_Click(object sender, EventArgs e)
        {
            // TODO: Change currentTech

            //Available Techs can change
            FilterTechnicians();
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {

            // TODO: Create Task
            Business_Logic.Task aTask = new Business_Logic.Task();

            // TODO: Create Technician task
            TechnicianTask techTask = new TechnicianTask();

            //save

            //Available Techs can change
            FilterTechnicians();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("No changes will be saved! Are you sure you want to go back?", "Discard and Go Back", MessageBoxButtons.YesNo))
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
