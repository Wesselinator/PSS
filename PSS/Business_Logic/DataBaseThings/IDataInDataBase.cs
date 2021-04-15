using System.Collections.Generic;
using System.Data;

namespace PSS.Business_Logic.DataBaseThings
{
    public interface IDataInDataBase
    {
        /// <summary>
        /// Should fill all fields with data row from a DataBase Table
        /// </summary>
        /// <param name="DataRow"></param>
        void FillWith(DataRow DataRow);

        /// <summary>
        /// Should Return a list of the Fields with their DataBase name and their value
        /// </summary>
        /// <returns></returns>
        SQLParameterList Extract();
    }
}
