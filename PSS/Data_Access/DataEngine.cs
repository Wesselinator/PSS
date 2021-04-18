using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Business_Logic;

namespace PSS.Data_Access
{
    public static class DataEngine
    {
        public static List<Client> GetAllClients() //move to Client.cs
        {
            DataTable IC = GetAll("IndividualClient");
            DataTable BC = GetAll("BusinessClient");


            List<Client> ret = new List<Client>();


            foreach (DataRow row in IC.Rows)
            {
                IndividualClient ic = new IndividualClient();
                ic.FillFromRow(row);
                ret.Add(ic);
            }

            foreach (DataRow row in BC.Rows)
            {
                BusinessClient bc = new BusinessClient();
                bc.FillFromRow(row);
                ret.Add(bc);
            }


            return ret;
        }

        //public static DataRow GetByID(string TableName, string IDColumn, int ID)
        //{
        //    string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
        //    DataTable dt = DataHandler.getDataTable(sql);
        //    if (dt.Rows.Count == 0)
        //    {
        //        //TODO: Throw Exception
        //    }
        //    return dt.Rows[0];
        //}

        //public static bool IDExists(string TableName, string IDColumn, int ID)
        //{
        //    //TODO: Implement Exception
        //    /*
        //    try
        //    {
        //        DataRow row = GetByID(TableName, IDColumn, ID);
        //        return true;
        //    }
        //    catch (EmptyListException)
        //    {
        //        return false;
        //    }
        //    */
        //    string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
        //    DataTable dt = DataHandler.getDataTable(sql);
        //    return dt.Rows.Count != 0;
        //}

        //public static int GetNextID(string TableName, string IDColumn)
        //{
        //    string sql = string.Format("SELECT * FROM {0} GROUP BY {1} DESC", TableName, IDColumn);
        //    return DataHandler.getDataTable(sql).Rows[0].Field<int>(IDColumn) + 1;
        //}

        //public static void UpdateORInsert(IModifyable data, string TableName, string IDColumn, int ID)
        //{
        //    if (IDExists(TableName, IDColumn, ID))
        //    {
        //        DataHandler.Update(data.Update());
        //    }
        //    else
        //    {
        //        DataHandler.Insert(data.Insert());
        //    }
        //}

        public static DataTable GetAll(string TableName) //remove after GetAllClients are re/moved
        {
            string sql = string.Format("SELECT * FROM {0}", TableName);
            return DataHandler.getDataTable(sql);
        }

        public static Client GetByClientID(int id)
        {
            Client ret;
            if (id % 2 == 0)
            {
                ret = new IndividualClient(); //even
            }
            else
            {
                ret = new BusinessClient(); //odd
            }

            ret.FillWithID(id);
            return ret;
        }

        public static T GetDataObject<T>(int id) where T : BaseSingleID, new()
        {
            T ret = new T();
            ret.FillWithID(id);
            return ret;
        }

        public static T GetDataObject<T>(params int[] ids) where T : BaseMultiID, new()
        {
            T ret = new T();
            ret.FillWithIDs(ids);
            return ret;
        }

        public static string GetProgressRapport(string ticketNo)
        {
            string progressRapport = "";
            string iniSql = "SELECT sr.ServiceRequestID, " +
                                " CASE " +
                                    " WHEN t.TaskID IS NULL THEN 1 " +
                                    " WHEN tt.TechnicianTaskID IS NULL THEN 2 " +
                                    " WHEN ttf.TechnicianTaskFeedbackID IS NULL THEN 3" +
                                    " WHEN ttf.TechnicianTaskFeedbackID IS NOT NULL THEN 4 "+
                                " END 'ProgressLevel', " +
                                " CASE " +
                                    " WHEN t.TaskID IS NULL THEN 'Service Request Received' " +
                                    " WHEN tt.TechnicianTaskID IS NULL THEN 'Service Request Processed Into Task' " +
                                    " WHEN ttf.TechnicianTaskFeedbackID IS NULL THEN 'Task Has Been Assigned To A Technian Who Is Due To Arrive At ' + tt.TimeToArrive " +
                                    " WHEN ttf.TechnicianTaskFeedbackID IS NOT NULL THEN 'Task Addressed By Technician. Task Current Status:\n' + ttf.Status " +
                                " END 'Progress' " +
                            " FROM ServiceRequest sr " +
                            " LEFT JOIN Task t " +
                            " ON sr.ServiceRequestID = t.ServiceRequestID " +
                            " LEFT JOIN TechnicianTask tt " +
                            " ON t.TaskID = tt.TaskID " +
                            " LEFT JOIN TechnicianTaskFeedback ttf " +
                            " ON tt.TechnicianTaskID = ttf.TechnicianTaskID " +
                            " WHERE sr.ServiceRequestID = " + ticketNo +
                            " ORDER BY t.DateProcessed DESC, ProgressLevel DESC --lastest dateprocessed first ";

            DataTable tbl = DataHandler.getDataTable(iniSql);

            progressRapport = (string)tbl.Rows[0][2];

            return progressRapport;
        }

        //public static Technician GetWorkRequest(int technicianID)
        //{
        //    //Query is still a work in progress, currently only works for individual clients
        //    string query = " SELECT tt.TechnicianID, p.FirstName, c.CellNumber, sr.Description, a.Street, a.City, t.Notes" +
        //                   " FROM ServiceRequest sr" +
        //                   " JOIN Task ts ON sr.ServiceRequestID = ts.ServiceRequestID" +
        //                   " JOIN TechnicianTask tt ON ts.TaskID = tt.TaskID" +
        //                   " JOIN Person p ON sr.ClientEntityID = p.PersonID" +
        //                   " JOIN ContactInfo c ON p.ContactInfoID = c.ContactInfoID" +
        //                   " JOIN IndividualClient ic ON p.PersonID = ic.IndividualClientID" +
        //                   " JOIN Address a ON ic.AddressID = a.AddressID" +
        //                   " WHERE tt.TechnicianID = " + technicianID;

        //    DataTable tbl = DataHandler.getDataTable(query);

        //    Technician teccy = new Technician();

        //    teccy.ClientName = (string)tbl.Rows[0][1];
        //    teccy.ClientContactNum = (string)tbl.Rows[0][2];
        //    teccy.RequestDescription = (string)tbl.Rows[0][3];
        //    teccy.ClientStreetAddress = (string)tbl.Rows[0][4];
        //    teccy.ClientCity = (string)tbl.Rows[0][5];
        //    teccy.Notes = (string)tbl.Rows[0][6];

        //    return teccy;
        //}
    }
}
