using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Base Exception class for PSS project
    /// </summary>
    [Serializable]
    public class PSSException : Exception
    {
        public PSSException() { }
        public PSSException(string message) : base(message) { }
        public PSSException(string message, Exception inner) : base(message, inner) { }
        protected PSSException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
