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
    public partial class ServiceInfoWidget : UserControl
    {
        private Service service = null;
        public Service Service
        {
            get => service;

            set
            {
                service = value;
                if (service is null) Empty(); else Populate();
            }
        }

        public ServiceInfoWidget()
        {
            InitializeComponent();
        }

        #region Populate

        public void Empty()
        {
            lblServiceName.Text = "Service Request Title";
            lblServiceType.Text = "Service Type";
            rtbDescription.Clear();
        }

        private void Populate()
        {
            if (Service is null)
            {
                throw new PSSObjectIsNull("Can't populate a null service");
            }

            lblServiceName.Text = Service.ServiceName;
            lblServiceType.Text = Service.Type;
            rtbDescription.Text = Service.ServiceDescription;

        }
        
        #endregion
    }
}
