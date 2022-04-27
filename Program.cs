using static ConnectToSQLServer.Controllers.Controller;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Create", () =>
{
    try
    {
        new ConnectToSQLServer.Controllers.Controller().getProject("INSERT INTO Interns(FirstName,LastName) VALUES('Lindo','DIMBA')");
    }
    catch (Exception err)
    {
        Console.WriteLine("Error is " + err.Message);
    }
});

app.MapGet("/Read", string() =>
{
    string result = "";
    try
    {
        result = new ConnectToSQLServer.Controllers.Controller().getProject("SELECT * FROM Interns");
    }
    catch (Exception err)
    {
        Console.WriteLine("Error is " + err.Message);
    }
    return result;
});

app.MapGet("/Update", () =>
{
    try
    {
        new ConnectToSQLServer.Controllers.Controller().getProject("UPDATE Interns SET FirstName='GOAT', LastName='Leo' WHERE InternID=18");
    }
    catch (Exception err)
    {
        Console.WriteLine("Error is " + err.Message);
    }
});

app.MapGet("/Delete", () =>
{
    try
    {
        new ConnectToSQLServer.Controllers.Controller().getProject("DELETE FROM Interns WHERE InternID=18");
    }
    catch (Exception err)
    {
        Console.WriteLine("Error is " + err.Message);
    }
});

app.Run();