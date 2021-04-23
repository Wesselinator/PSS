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
        Client client;//added this check if correct

        public ServiceDepartment()
        {
            InitializeComponent();
        }

        public ServiceDepartment(Client client)//added this check if correct
        {
            this.client = client;
        }

        private void ServiceDepartment_Load(object sender, EventArgs e)
        {

        }
    }
}
