using System.Collections.Generic;
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

        public static DataTable GetAll(string TableName) //remove after GetAllClients are re/moved
        {
            string sql = string.Format("SELECT * FROM {0}", TableName);
            return DataHandler.GetDataTable(sql);
        }

        #region DataObjects

        public static T GetDataObject<T>(params int[] ids) where T : MultiIntID, new()
        {
            T ret = new T();
            ret.FillWithIDs(ids);
            return ret;
        }

        public static T GetDataObject<T>(int id) where T : SingleIntID, new()
        {
            T ret = new T();
            ret.FillWithID(id);
            return ret;
        }

        public static TObject GetDataObject<TObject, TID>(TID id) 
            where TObject : BaseSingleID<TID>, new()
            where TID : struct
        {
            TObject ret = new TObject();
            ret.FillWithID(id);
            return ret;
        }

        #endregion

        
        

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

            DataTable tbl = DataHandler.GetDataTable(iniSql);

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
