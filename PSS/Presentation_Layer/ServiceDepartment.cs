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
        private readonly Client focusedClient; 

        public ServiceDepartment()
        {
            InitializeComponent();
        }

        public ServiceDepartment(Client client) : this()
        {
            this.focusedClient = client;
        }

        private void ServiceDepartment_Load(object sender, EventArgs e)
        {
            //TODO: load client details into form.
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

        private void btnCreateJob_Click(object sender, EventArgs e)
        {

        }
    }
}
