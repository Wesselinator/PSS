using System;
using System.Data;
using PSS.Business_Logic;

namespace PSS.Data_Access
{
    [Obsolete("Data Engine has been deprecated. Code left here for posterity", true)]
    public static class DataEngine
    {
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

        public static Technician GetWorkRequest(int technicianID)
        {
            //Query is still a work in progress, currently only works for individual clients
            string query = " SELECT tt.TechnicianID, p.FirstName, c.CellNumber, sr.Description, a.Street, a.City, t.Notes" +
                           " FROM ServiceRequest sr" +
                           " JOIN Task ts ON sr.ServiceRequestID = ts.ServiceRequestID" +
                           " JOIN TechnicianTask tt ON ts.TaskID = tt.TaskID" +
                           " JOIN Person p ON sr.ClientEntityID = p.PersonID" +
                           " JOIN ContactInfo c ON p.ContactInfoID = c.ContactInfoID" +
                           " JOIN IndividualClient ic ON p.PersonID = ic.IndividualClientID" +
                           " JOIN Address a ON ic.AddressID = a.AddressID" +
                           " WHERE tt.TechnicianID = " + technicianID;

            DataTable tbl = DataHandler.GetDataTable(query);

            Technician teccy = new Technician();

            //Non existant methods prevent program from building
            //teccy.ClientName = (string)tbl.Rows[0][1];
            //teccy.ClientContactNum = (string)tbl.Rows[0][2];
            //teccy.RequestDescription = (string)tbl.Rows[0][3];
            //teccy.ClientStreetAddress = (string)tbl.Rows[0][4];
            //teccy.ClientCity = (string)tbl.Rows[0][5];
            //teccy.Notes = (string)tbl.Rows[0][6];

            return teccy;
        }
    }
}
