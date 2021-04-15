using System;
using PSS.Data_Access;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace PSS.Business_Logic.DataBaseThings
{
    //This should have been an Interface but .NET Framework is on C# 7.3
    //C# 7.3 does not have the ability for static fields/methods in Interfaces
    //Need to either wait for .NET Framework to get C# 8.0 or switch to .NET 5.x / .NET Core 3.x

    //This is imposible at the momment
    /*
    public interface TableInDataBase
    {
        private static string IDColumn;
        private static string TableName;
    }

    */


    //I now have do this roundabout instancing

    /// <summary>
    /// A helper class to do things with the Data Classes and their corasponding Tables in the DataBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TableInDataBase<T> where T : IDataInDataBase, new()
    {
        private readonly string TableName;
        private readonly string IDColumn;

        public TableInDataBase(string tableName, string idColumn)
        {
            TableName = tableName;
            IDColumn = idColumn;
        }

        /// <summary>
        /// Grabs the next id from the Table in the DataBase
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            string sql = SQLString.Select.DecendingID(TableName,IDColumn);
            var dh = new DataHandler(sql);
            DataTable dt = dh.getDataTable();

            if (dt.Rows.Count == 0)
            {
                return 1;
            }

            return dt.Rows[0].Field<int>(IDColumn);
        }

        /// <summary>
        /// Returns the Data Object from the DataBase with the ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T GetByID(int ID)
        {
            string sql = SQLString.Select.ID(TableName, IDColumn, ID);
            var dh = new DataHandler(sql);
            var dt = dh.getDataTable();

            if (dt.Rows.Count == 0)
            {
                return new T();
            }

            T data = new T();
            data.FillWith(dt.Rows[0]);
            return data;
        }


        /// <summary>
        /// Returns a List of Data objects from the DataBase
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            List<T> list = new List<T>();

            string sql = SQLString.Select.All(TableName);
            var dh = new DataHandler(sql);
            var dt = dh.getDataTable();

            foreach (DataRow dr in dt.Rows)
            {
                T data = new T();
                data.FillWith(dr);
                list.Add(data);
            }

            return list;
        }

        /// <summary>
        /// Updates the Data from the data class to the DataBase
        /// IMPORTANT: Only updates the surface level Data Object. (Problems with ordering)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ID"></param>
        public void Set(T data, int ID) //might make more sense to put this somewhere else
        {
            string sql = SQLString.Update.ID(TableName, IDColumn, ID, data.Extract());
            var dh = new DataHandler(sql);
            dh.Update();
        }
    }
}
