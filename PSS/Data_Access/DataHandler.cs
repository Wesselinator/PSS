using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace PSS.Data_Access
{
    public static class DataHandler
    {
        private static readonly string connStr = @"Server=127.0.0.1; Port=7331; Uid=PSSuser; Pwd=τнιsραssωοяδιsωεακ; Database=PremierServiceSolutionsDB";

        public static DataTable GetDataTable(string Query)
        {
            TerminateSQL(ref Query);

            DataTable data = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(Query, conn);
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

        private static void ExecuteNonQuery(string Query)//for insert, update and delete statements
        {
            TerminateSQL(ref Query);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand command = new MySqlCommand(Query, conn);
                try
                {
                    conn.Open();
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
            ExecuteNonQuery(Query);
        }

        public static void Update(string Query)
        {
            ExecuteNonQuery(Query);
        }

        public static void Delete(string Query)
        {
            ExecuteNonQuery(Query);
        }



        private static void TerminateSQL(ref string Query)
        {
            char finalChar = Query[Query.Length - 1];

            switch (finalChar)
            {
                case ';': 
                    return;

                default :
                    Query += ";";
                    break;
            }
        }
    }
}

