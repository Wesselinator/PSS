using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Should be thrown when code tries to interact with a PSS Data Object that is null
    /// </summary>
    [Serializable]
    public class PSSObjectIsNull : PSSException
    {
        public PSSObjectIsNull() { }
        public PSSObjectIsNull(string message) : base(message) { }
        public PSSObjectIsNull(string message, Exception inner) : base(message, inner) { }
        protected PSSObjectIsNull(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
