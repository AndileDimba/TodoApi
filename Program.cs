using Microsoft.EntityFrameworkCore;
using ConnectToSQLServer;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InternContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("InternsDB")));
var app = builder.Build();

app.MapGet("/Read", (InternContext db) => db.Interns.ToListAsync());

app.MapPost("/Create", async (InternContext db, Intern intern) =>
{
    await db.Interns.AddAsync(intern);
    await db.SaveChangesAsync();
    Results.Accepted();
    return intern;
});

app.MapPut("/Update/{id}", async (InternContext db, int id, Intern intern) =>
{
    if (id != intern.InternID) {
        return Results.BadRequest("User ID you're updating is not found in the database");
    }
    db.Update(intern);
    await db.SaveChangesAsync();
    return Results.Ok("Successfully Updated the User");
});

app.MapDelete("/Delete/{id}", async (InternContext db, int id) =>
{
    var intern = await db.Interns.FindAsync(id);
    if (intern == null) {
        return Results.NotFound("User ID youre deletingis not found in the database");
    }
    db.Interns.Remove(intern);
    await db.SaveChangesAsync();
    return Results.Ok("Successfully deleted the User");
});

app.MapGet("/Calc", (InternContext db) =>
{
    int count = (from intern in db.Interns where intern.YearOfInternship < 2010 select intern).Count();
    return count;
});

app.MapGet("/WriteToFile", async (InternContext db) =>
{

    try
    {
        List<Intern> interns = await db.Interns.ToListAsync();
        using StreamWriter file = new("Interns.pdf");
        foreach (Intern person in interns)
        {
            await file.WriteLineAsync(person.FirstName + " " + person.LastName + " " + person.YearOfInternship);
        }
    }
    catch (Exception err)
    {
        Console.WriteLine("Error Message is " + err.Message);
    }
});


app.Run();