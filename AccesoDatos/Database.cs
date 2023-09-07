using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Database
    {
        private SqlConnection connection;
        private SqlCommand command;
        public SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public Database()
        {
            connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            command = new SqlCommand();

        }

        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void readData()
        {
            command.Connection = connection;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public void CloseConnection()
        {
            if (reader != null) reader.Close();
            connection.Close();
        }

    }
}