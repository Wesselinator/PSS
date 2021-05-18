using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Should be thrown when code recieves values from the DataBase that are unexpected
    /// </summary>
    [Serializable]
    public class BadDataBaseData : PSSException
    {
        public BadDataBaseData() { }
        public BadDataBaseData(string message) : base(message) { }
        public BadDataBaseData(string message, Exception inner) : base(message, inner) { }
        protected BadDataBaseData(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
