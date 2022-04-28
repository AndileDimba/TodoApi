using Microsoft.EntityFrameworkCore;
using ConnectToSQLServer;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InternContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("InternsDB")));
var app = builder.Build();

app.MapGet("/api/Interns", async (InternContext db) => await db.Interns.ToListAsync());

app.MapGet("/api/Interns/{id}", async (InternContext db, int id) => await db.Interns.FindAsync(id));

app.MapPost("/api/Interns", async (InternContext db, Intern intern) =>
{
    await db.Interns.AddAsync(intern);
    await db.SaveChangesAsync();
    Results.Accepted();
    return intern;
});

app.MapPut("/api/Interns/{id}", async (InternContext db, int id, Intern intern) =>
{
    if (id != intern.InternID) return Results.BadRequest();
    db.Update(intern);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/Interns/{id}", async (InternContext db, int id) =>
{
    var intern = await db.Interns.FindAsync(id);
    if (intern == null) return Results.NotFound();

    db.Interns.Remove(intern);
    await db.SaveChangesAsync();
    return Results.NoContent();
});



app.Run();