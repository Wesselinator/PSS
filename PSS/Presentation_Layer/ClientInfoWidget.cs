﻿using System;
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
    public partial class ClientInfoWidgit : UserControl
    {
        private const string HouseBuilding = "🏠";
        private const string OfficeBuilding = "🏢";

        private Client client = null;
        public Client Client { 
            get => client;

            set {
                client = value;
                Populate();
            }
        }
        public ClientInfoWidgit()
        {
            InitializeComponent();
        }

        public ClientInfoWidgit(Client client) : this()
        { 
            Client = client;
        }

        #region Populate

        public void Populate()
        {
            if (Client is null)
            {
                throw new Exception(); //TODO: nice exception
            }

            if (client is IndividualClient)
            {
                PopulateIndividual((IndividualClient)Client);
            }
            else if (client is BusinessClient)
            {
                PopulateBusiness((BusinessClient)Client);
            }
            else
            {
                throw new Exception(); //htf did you get here?
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