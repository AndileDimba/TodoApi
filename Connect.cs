using System.Data.SqlClient;
namespace ConnectToSQLServer
{
    public class Connect
    {
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection("Data Source=ANDILED;Initial Catalog=InternsDB;Trusted_Connection=True;");
            connection.Open();
            return connection;
        }
        public static SqlDataReader queryDatabase(string sql)
        {
            var connection = GetConnection();
            connection = GetConnection();
            var command = new SqlCommand(sql, connection);
            return command.ExecuteReader();

        }

    }
}

