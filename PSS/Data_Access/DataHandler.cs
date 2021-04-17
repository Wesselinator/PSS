using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PSS.Data_Access
{
    public static class DataHandler
    {
        private static SqlConnection conn = new SqlConnection(@"Server=.;Initial Catalog = PremierServiceSolutionsDB;Integrated Security = SSPI");

        public static DataTable getDataTable(string Query)
        {
            DataTable data = new DataTable(); //return

            using (conn)
            {            
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, conn);
                    adapter.Fill(data);
                }
                catch (Exception)
                {
                    MessageBox.Show("Some error message");
                }
            }

            return data;
        }

        private static void executeNonQuery(string Query)//for insert, update and delete statements
        {

            using(conn)
            {
                SqlCommand command = new SqlCommand(Query, conn);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Some error message");
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

