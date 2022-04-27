using static ConnectToSQLServer.Connect;
namespace ConnectToSQLServer.Controllers
{
    public class Controller
    {
        public Controller(){}
        public string getProject(string sql)
        {
            string res = "";
          try{ 
            var reader = Connect.queryDatabase(sql);
            while (reader.Read())
            {
                res+= $"{reader["InternID"]} {reader["FirstName"]}  {reader["LastName"]}\n";
            }
            }
            catch (Exception err){
                Console.WriteLine("Error is " + err.Message);
            }
            return res;
        }
    }

}