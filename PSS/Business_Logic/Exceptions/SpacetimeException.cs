using System;

namespace PSS.Business_Logic
{
    /// <summary>
    /// This Exception should only be thrown if the code block excecuting this code "Should never Happen"
    /// </summary>
    [Serializable]
    public class SpacetimeException : Exception
    {
        public SpacetimeException() { }
        public SpacetimeException(string tag) : base(MessageFormat(tag)) { }
        public SpacetimeException(string tag, Exception inner) : base(MessageFormat(tag), inner) { }
        protected SpacetimeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string MessageFormat(string tag) => "Congradulations! This exception was never ever supposed to be reachable! You somehow, through a herefor unforseen series of events and actions. reached it! This one is tagged: " + tag;
    }
}
