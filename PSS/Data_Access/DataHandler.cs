using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PSS.Data_Access
{
    public static class DataHandler
    {
        private static readonly string connStr = @"Server=.;Initial Catalog=PremierServiceSolutionsDB;Database=PremierServiceSolutionsDB;Integrated Security=SSPI";

        public static DataTable getDataTable(string Query)
        {
            DataTable data = new DataTable(); ;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, conn); 
                    adapter.Fill(data);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.StackTrace);
                    MessageBox.Show(string.Format("Error: {0}\n\rSQL: {1}", e.Message, Query),"SQL ERROR");
                }
            }

            return data;
        }

        private static void executeNonQuery(string Query)//for insert, update and delete statements
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(Query, conn);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.StackTrace);
                    MessageBox.Show(string.Format("Error: {0}\n\rSQL: {1}", e.Message, Query), "SQL ERROR");
                }
            }
        }

        public static void Insert(string Query)
        {
            executeNonQuery(Query);
        }

        public static void Update(string Query)
        {
            executeNonQuery(Query);
        }

        public static void Delete(string Query)
        {
            executeNonQuery(Query);
        }
    }
}

