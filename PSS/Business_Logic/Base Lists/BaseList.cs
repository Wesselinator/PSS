using System.Collections.Generic;
using System.Data;
using PSS.Data_Access;


namespace PSS.Business_Logic
{
    public class BaseList<T> : List<T> where T : BaseTable, new()
    {

        private readonly T DataInstance = new T();

        public void SaveAll()
        {
            this.ForEach(bcp => bcp.Save());
        }

        public void FillAll()
        {
            DataTable dt = DataInstance.GetAll();
            FillWith(dt);
            //return this;
        }

        public void FillWith(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                T newT = new T();
                newT.FillFromRow(row);
                this.Add(newT);
            }
        }

        public static BaseList<T> GrabAll() //Quality of life
        {
            BaseList<T> ret = new BaseList<T>();
            ret.FillAll();
            return ret;
        }

        public static BaseList<T> GrabFill(DataTable dataTable) //Quality of life
        { 
            BaseList<T> ret = new BaseList<T>();
            ret.FillWith(dataTable);
            return ret;
        }

        public static BaseList<T> GrabFill(string sql) //even more Quality of life!
        {
            return GrabFill(DataHandler.GetDataTable(sql));
        }
    }
}
