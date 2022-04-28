using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InternContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("InternsDB")));
var app = builder.Build();

app.MapGet("/Read", async (InternContext db) => await db.Interns.ToListAsync());

app.MapPost("/Create", async (InternContext db, Intern intern) =>
{
    await db.Interns.AddAsync(intern);
    await db.SaveChangesAsync();
    Results.Accepted();
    return intern;
});

app.MapPut("/Update/{id}", async (InternContext db, int id, Intern intern) =>
{
    if (id != intern.InternID) return Results.BadRequest();
    db.Update(intern);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/Delete/{id}", async (InternContext db, int id) =>
{
    var intern = await db.Interns.FindAsync(id);
    if (intern == null) return Results.NotFound();

    db.Interns.Remove(intern);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapGet("/Calc", (InternContext db) =>
{
 int count = (from intern in db.Interns where intern.YearOfInternship < 2010 select intern).Count();
 return count;
});

app.MapGet("/WriteToFile", async (InternContext db) =>
{
 List<Intern> interns = await db.Interns.ToListAsync();
 using StreamWriter file = new("Interns.txt");

 try{
     foreach(Intern person in interns){
         await file.WriteLineAsync(person.FirstName + " " + person.LastName);
     }
 }
     catch( Exception err){
         Console.WriteLine("Error Message is " + err.Message);
     }
 });


app.Run();

public class InternContext : DbContext
    {
        public InternContext(DbContextOptions<InternContext> options) : base(options)
        {

        }
        // public DbSet<Intern> Interns { get; set; }
        public DbSet<Intern> Interns => Set<Intern>();
    }

    public class Intern
    {
        public int InternID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearOfInternship { get; set; }

    }