﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PSS.Data_Access
{
    public static class DataHandler
    { 
        private static readonly string connStr = @"Server=.;Initial Catalog=PremierServiceSolutionsDB;Integrated Security=SSPI";

        public static DataTable getDataTable(string Query)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, conn);
                    adapter.Fill(data);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    MessageBox.Show("Some error message");
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

