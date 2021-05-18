using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Should be returend when code determines that an entered ID does not exist in the Database
    /// </summary>
    [Serializable]
    public class IDDoesNotExist : PSSException
    {
        public IDDoesNotExist() { }
        public IDDoesNotExist(string table, object id) : base(FormatedMessage(table, id)) { } //not required; just a nicer IDE representation
        public IDDoesNotExist(string table, params object[] ids) : base(FormatedMessage(table, ids)) { }
        public IDDoesNotExist(Exception inner, string table, params object[] ids) : base(FormatedMessage(table, ids), inner) { } //slight taboo switching the established inner Exception style
        protected IDDoesNotExist(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string FormatedMessage(string table, params object[] ids)
        {
            if (ids.Length == 1)
            {
                return FormatedMessage(table, ids[0]);
            }

            string[] idsTostring = ids.Select(o => o.ToString()).ToArray();
            string sids = string.Join(" ,", idsTostring);

            return $"Multi-ID:[{sids}] does not exist in {table}";
        }

        private static string FormatedMessage(string table, object id) => $"ID:{id} does not exist in {table}";
    }
}
