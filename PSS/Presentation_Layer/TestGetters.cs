using System;
using System.Windows.Forms;
using PSS.Business_Logic;
using PSS.Data_Access;

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
            //IndividualClient ass =  SingleIntID.GetDataObject<IndividualClient>(1);
            //Console.WriteLine(ass.Person.FullName);
        }
    }
}
