using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class CallFunctionality
    {
        public void RecordCall(string StartTime, string EndTime, string discription)
        {
            string query = $"Insert INTO Call VALUES '({StartTime})', '({EndTime})', '({discription})'";
            Data_Access.DataHandler handler = new DataHandler();
            handler.Update(query);
        }
    }
}
