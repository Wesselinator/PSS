using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Should be thrown when there is a Discrepancy with the abount of entered IDs and the existing IDColumns
    /// </summary>
    [Serializable]
    public class IDsSizeDiscrepancy : PSSException
    {
        public IDsSizeDiscrepancy() { }
        public IDsSizeDiscrepancy(int expected, int recieved) : base(FormattedMessage(expected, recieved)) { }
        public IDsSizeDiscrepancy(int expected, int recieved, Exception inner) : base(FormattedMessage(expected, recieved), inner) { }
        protected IDsSizeDiscrepancy(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string FormattedMessage(int expected, int recieved)
        {
            return $"Expected {expected} IDs, but recieved {recieved} instead.";
        }
    }
}
