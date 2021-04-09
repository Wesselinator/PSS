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
        Client client;

        public ClientMaintenance()
        {
            InitializeComponent();
        }

        public void ReceiveClient(Client clientToUpdate)
        {
            //update form to register components/name
            lblTask.Text = "Update Client";

            client = new IndividualClient();
            client = clientToUpdate;
            if (clientToUpdate is IndividualClient)
            {
                lblBusinessName.Hide();
                txtBusinessName.Hide();
            } else
            {
                client = new BusinessClient();
                client = clientToUpdate;
                lblBusinessName.Show();
                txtBusinessName.Show();
                //txtBusinessName.Text = client.BusinessName;
            }
           
            
        }
    }
}
