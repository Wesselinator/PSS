using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PSS.Data_Access
{
    public class DataHandler
    {
        private SqlConnection conn = new SqlConnection(@"Data Source =. ;Initial Catalog = PremierServiceSolutionsDB ; Integrated Security = SSPI");
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private SqlDataReader reader;

        public DataHandler()
        {
            
        }

        //
        //=====================================
        //
        public SqlConnection Conn { get => conn;}
        public SqlCommand Command { get => command;}
        public SqlDataAdapter Adapter { get => adapter;}
        public SqlDataReader Reader { get => reader;}
        //
        //=====================================
        // 


        public DataTable getDataTable(string Query)
        {
            DataTable data = new DataTable();

            using (conn)
            {
                command = new SqlCommand(Query, conn);
                try
                {
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
                catch (Exception)
                {
                    MessageBox.Show("Some error message");
                }
            }

            return data;
        }

        private void executeNonQuery(string Query)//for insert, update and delete statements
        {

            using(conn)
            {
                command = new SqlCommand(Query, conn);
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

        public void Insert(string Query)
        {
            executeNonQuery(Query);
        }

        public void Update(string Query)
        {
            executeNonQuery(Query);
        }

        public void Delete(string Query)
        {
            executeNonQuery(Query);
        }
    }
}

