using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PSS.Business_Logic
{
    public class MultiIDList<T> : BaseList<T> where T : MultiIntID, new()
    {
        private T DataInstance = new T();

        public void FillWithPivotColumn(int id, string column)
        {
            DataTable dt =  DataInstance.GetAllOnPivot(id, column);

            foreach (DataRow row in dt.Rows)
            {
                T newT = new T();
                newT.FillFromRow(row);
                this.Add(newT);
            }
        }
    }
}
