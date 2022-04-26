using Twooter.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Endpoints
app.MapGet("/", () => "Hello World!");

app.MapGet("/user/{id}", ([FromServices] UserDbContext db, string id) => {
    return db.User.Where(x => x.Id == id).FirstOrDefault();
});

app.MapGet("/users", ([FromServices] UserDbContext db) => {
    return db.User.ToList();
});

app.MapPut("/user/{id}", ([FromServices] UserDbContext db, User user) => {
    db.User.Update(user);
    db.SaveChanges();
    return db.User.Where(x => x.Id == user.Id).FirstOrDefault();
});

app.MapPost("/user", ([FromServices] UserDbContext db, User user) => {
    db.User.Update(user);
    db.SaveChanges();
    return db.User.ToList();
});

//Needed right now for Integrationtest
app.MapGet("/test", (Func<string>)(() => {
    return "OK";
}));
app.Run();

public partial class Program { }
