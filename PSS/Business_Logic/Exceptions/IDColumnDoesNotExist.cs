using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Should be thrown when the entered ID Column does't exist in the ID Columns of the Table
    /// </summary>
    [Serializable]
    public class IDColumnDoesNotExist : PSSException
    {
        public IDColumnDoesNotExist() { }
        public IDColumnDoesNotExist(string enteredIDColumn) : base(FormattedMessage(enteredIDColumn)) { }
        public IDColumnDoesNotExist(string enteredIDColumn, Exception inner) : base(FormattedMessage(enteredIDColumn), inner) { }
        protected IDColumnDoesNotExist(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string FormattedMessage(string enteredIDColumn)
        {
            return $"Entered ID Column:{enteredIDColumn} does not exist in this table!";
        }
    }
}
