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
        public static List<Client> GetAllClients()
        {
            DataTable IC = GetAll("IndividualClient");
            DataTable BC = GetAll("BusinessClient");


            List<Client> ret = new List<Client>();


            foreach (DataRow row in IC.Rows)
            {
                ret.Add(new IndividualClient(row));
            }

            foreach (DataRow row in BC.Rows)
            {
                ret.Add(new BusinessClient(row));
            }


            return ret;
        }

        public static DataRow GetByID(string TableName, string IDColumn, int ID)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
            DataHandler dh = new DataHandler();
            DataTable dt = dh.getDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                //TODO: Throw Exception
            }
            return dt.Rows[0];
        }

        public static bool IDExists(string TableName, string IDColumn, int ID)
        {
            //TODO: Implement Exception
            /*
            try
            {
                DataRow row = GetByID(TableName, IDColumn, ID);
                return true;
            }
            catch (EmptyListException)
            {
                return false;
            }
            */
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
            DataHandler dh = new DataHandler();
            DataTable dt = dh.getDataTable(sql);
            return dt.Rows.Count != 0;
        }

        public static int GetNextID(string TableName, string IDColumn)
        {
            string sql = string.Format("SELECT * FROM {0} GROUP BY {1} DESC", TableName, IDColumn);
            DataHandler dh = new DataHandler();
            return dh.getDataTable(sql).Rows[0].Field<int>(IDColumn) + 1;
        }

        public static void UpdateORInsert(IModifyable data, string TableName, string IDColumn, int ID)
        {
            DataHandler dh = new DataHandler();
            if (IDExists(TableName, IDColumn, ID))
            {
                dh.Update(data.Update());
            }
            else
            {
                dh.Insert(data.Insert());
            }
        }

        public static DataTable GetAll(string TableName)
        {
            DataHandler dh = new DataHandler();
            string sql = string.Format("SELECT * FROM {0}", TableName);
            return dh.getDataTable(sql);
        }

        public static string GetProgressRapport(string ticketNo)
        {
            string progressRapport = "";
            string iniSql = "SELECT sr.ServiceRequestID, " +
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
                            " ON tt.TechnicianTaskID = ttf.TechnicianTaskID ";

            DataHandler dh = new DataHandler();

            DataTable tbl = dh.getDataTable(iniSql);

            //read string from table

            return progressRapport;
        }

        public static Technician GetWorkRequest(int technicianID)
        {
            Technician teccy = new Technician();

            return teccy;
        }
    }
}
