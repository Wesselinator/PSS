using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;


namespace PSS.Business_Logic
{
    public class BaseList<T> : List<T> where T : BaseTable, new()
    {
        public void SaveAll()
        {
            this.ForEach(bcp => bcp.Save());
        }

        public void FillAll()
        {
            T instance = new T(); //I hate this :[
            DataTable dt = instance.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                T newT = new T();
                newT.FillFromRow(row);
                this.Add(newT);
            }
        }

        public void FillAll(int ID)
        {
            //TODO: This!
        }
    }
}
