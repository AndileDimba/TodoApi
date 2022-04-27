// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World! @ BBD");

// app.MapGet("/home", () => "Thang is the best teacher of C#");

// app.Run();

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Data.SqlClient;

// namespace ConnectionToSQLServer
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Getting information");
//             string dataSource = "ANDILED";
//             string database = "ConstructionDB";
//             string queryString = "SELECT * FROM dbo.ProjectStatus;";
//             var connString = "Data Source=" + dataSource + ";Initial Catalog=" + database + ";User ID=user;Password=pass";
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


using static ConnectToSQLServer.Controllers.Controller;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => new ConnectToSQLServer.Controllers.Controller().getProject());

app.MapGet("/home", () => "Thang is the best teacher of C#");

app.Run();