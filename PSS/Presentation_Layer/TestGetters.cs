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
    public partial class TestGetters : Form
    {
        public TestGetters()
        {
            InitializeComponent();
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            Service serviceObj = new Service();
            BindingSource serviceSource = new BindingSource();
            List<Service> services = serviceObj.GetServices();
            serviceSource.DataSource = services;
            dataGridView1.DataSource = serviceSource;
            MessageBox.Show(serviceObj.GetServices()[0].ToString());
        }
    }
}
