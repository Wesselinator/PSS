using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    //potential base class for data objects
    public abstract class BaseData
    {
        protected virtual int ID { get; set; }
        protected string TableName { get; set; }
        protected string IDColumn { get; set; }

        protected BaseData(string tableName, string idColumn)
        {
            this.TableName = tableName;
            this.IDColumn = idColumn;
        }

        protected void InsertORUpdate()
        {

        }

    }
}
