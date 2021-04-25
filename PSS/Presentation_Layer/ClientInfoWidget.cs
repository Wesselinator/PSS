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
    //TODO: Add an empty mode
    public partial class ClientInfoWidgit : UserControl
    {
        private const string HouseBuilding = "🏠";
        private const string OfficeBuilding = "🏢";

        private Client client = null;
        public Client Client { 
            get => client;

            set {
                client = value;
                if (!(client is null)) //use null colalece?
                {
                    Populate();
                };
            }
        }
        public ClientInfoWidgit()
        {
            InitializeComponent();
        }

        #region Populate

        public void Populate() 
        {
            if (Client is null)
            {
                throw new PSSObjectIsNull("Can't populate a null client");
            }

            if (Client is IndividualClient idC)
            {
                PopulateIndividual(idC);
            }
            else if (Client is BusinessClient bC)
            {
                PopulateBusiness(bC);
            }
            else
            {
                throw new SpacetimeException("Client Info Widget : Populate");
            }

            lblBirthDate.Text = Client.Person.BirthDay.ToString("MM-dd");
            lblEmail.Text = Client.Person.Email;
            lblTell.Text = Client.Person.TellephoneNumber;
            lblCell.Text = Client.Person.CellphoneNumber;
        }

        private void PopulateIndividual(IndividualClient individual)
        {
            lblTitle.Text = individual.Person.FullName;
            lblSubtitle.Text = ""; //something nicer?
            lblBuildingIcon.Text = HouseBuilding;
        }

        private void PopulateBusiness(BusinessClient business)
        {
            lblTitle.Text = business.ContactPerson.FullName;
            lblSubtitle.Text = business.Person.FullName;
            lblBuildingIcon.Text = OfficeBuilding;
        }

        #endregion
    }
}
