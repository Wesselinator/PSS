using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSS.Data_Access;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    public partial class frmTechnician : Form
    {
        public frmTechnician()
        {
            InitializeComponent();
        }

        private void btnGetWorkRequest_Click(object sender, EventArgs e)
        {
            Technician technician = new Technician();
            technician = technician.getWork(int.Parse(txtTechnicianID.Text));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
