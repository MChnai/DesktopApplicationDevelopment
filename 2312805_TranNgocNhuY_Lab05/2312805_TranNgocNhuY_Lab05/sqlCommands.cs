using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_Lab05
{
    internal class sqlCommands
    {
        string connection = "server = DESKTOP-SFSR5TO\\SQLEXPRESS; database = Restaurant Management; integrated security = true";
        SqlConnection sqlConnection;
        SqlCommand cmd;
        public SqlDataReader Read(string command)
        {
            sqlConnection = new SqlConnection(connection);
            cmd = sqlConnection.CreateCommand();
            cmd.CommandText = command;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public int Execute(string cmd)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = cmd;

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                command.Connection = sqlConnection;
                sqlConnection.Open();
                return command.ExecuteNonQuery();
            }
        }
        public string ExecuteScalar(string cmd)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = cmd;
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                command.Connection = sqlConnection;
                sqlConnection.Open();
                string result = command.ExecuteScalar().ToString();
                return result;
            }
        }
        public SqlDataAdapter Read_Data_Adapter(string command)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = command;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da;
        }
        public SqlConnection Conmection()
        {
            return new SqlConnection(connection);
        }
    }
}
