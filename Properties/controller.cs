using static ConnectToSQLServer.Connect;
namespace ConnectToSQLServer.Controllers
{
    public class Controller
    {
        public Controller(){}
        public string getProject()
        {
            string res = "";
            var reader = Connect.queryDatabase();
            while (reader.Read())
            {
                res+= $"{reader["ProjectID"]}  {reader["ProjectLocation"]}\n";
            }
            return res;
        }
    }

}