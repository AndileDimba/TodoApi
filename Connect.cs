// using System;
// using System.Data.SqlClient;

// namespace ConnectionToSQLServer
// {
//     class Connect
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Getting information");
//             string dataSource = "ANDILED";
//             string database = "ConstructionDB";
//             string queryString = "SELECT * FROM dbo.ProjectStatus;";
//             var connString = "Data Source=" + dataSource + ";Initial Catalog=" + database + ";Trusted_Connection=True;";
//             var conn = new SqlConnection(connString);

//             try
//             {
//                 conn.Open();
//                 Console.WriteLine("Opened Connection....");

//                 SqlCommand command = new SqlCommand(
//             queryString, conn);
//                 var reader = command.ExecuteReader();
//                 while (reader.Read())
//                 {
//                     Console.WriteLine($"{reader["StatusType"]} | {reader["StatusDescr"]}");
//                 }
//                 Console.WriteLine("Open Connection Successful!");
//                 conn.Close();
//             }
//             catch (Exception err)
//             {
//                 Console.WriteLine("Error is " + err.Message);
//             }
//             Console.Read();
//         }
//     }
// }


using System.Data.SqlClient;

namespace ConnectToSQLServer
{
    public class Connect
    {
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection("Server=ANDILED;Database=ConstructionDB;Trusted_Connection=True;");
            connection.Open();
            return connection;
        }

        public static SqlDataReader queryDatabase()
        {
            var connection = GetConnection();
            string sql = "SELECT * FROM dbo.Projects;";
            connection = GetConnection();
            var command = new SqlCommand(sql, connection);
            return command.ExecuteReader();

        }

    }
}

