using System;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Should be thrown when a table's ID is part of a different Table and it's imposible to dittermine the correct next ID
    /// </summary>
    [Serializable]
    public class TableIsAComposition : PSSException
    {
        public TableIsAComposition() { }
        public TableIsAComposition(string table) : base(MessageFormat(table)) { }
        public TableIsAComposition(string table, Exception inner) : base(MessageFormat(table), inner) { }
        protected TableIsAComposition(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string MessageFormat(string table) => $"Table {table} is a compistion and its ID cannot be determined";
    }
}
