using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class ClientFolowup : BaseSingleID
    {
        private Person p;
        public int ClientFolowupID { get => ID; private set => ID = value; }
        public int BusinessClientID { get; private set; }
        public FollowUp FollowUpReport { get; private set; } //pribatte?
        public DateTime FollowUpDate { get; set; }


    }
}
