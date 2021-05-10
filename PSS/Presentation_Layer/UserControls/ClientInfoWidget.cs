using System.Windows.Forms;
using PSS.Business_Logic;

namespace PSS.Presentation_Layer
{
    public partial class ClientInfoWidgit : UserControl
    {
        private const string HouseBuilding = "🏠";
        private const string OfficeBuilding = "🏢";

        private Client client = null;
        public Client Client { 
            get => client;

            set {
                client = value;
                if (client is null) Empty(); else Populate();
            }
        }
        public ClientInfoWidgit()
        {
            InitializeComponent();
        }

        #region Populate

        public void Empty()
        {
            lblTitle.Text = "Jane Doe Inc.";
            lblSubtitle.Text = "Jane Doe";
            lblEmail.Text = "john.doe@janedoeinc.co.za";

            lblBusinessIdentifier.Text = "BID";

            lblBirthDate.Text = "MM-dd";

            lblTell.Text = "333 333 4444";
            lblCell.Text = "+22 333 4444";

            lblBuildingIcon.Text = "";

            lblAdress.Text = "14 Street Lane, Suburbia";
            lblAdress2.Text = "City Ville, Best Country";
            lblPostal.Text = "0110";
        }

        private void Populate() 
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
            
            lblAdress.Text = Client.Address.Street;
            lblAdress2.Text = $"{Client.Address.City}, {Client.Address.Province}";
            lblPostal.Text = Client.Address.PostalCode;

            lblBusinessIdentifier.Text = Client.BusinessIdentifier;
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
