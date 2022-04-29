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

app.MapGet("/user/{id}", ([FromServices] IDataRepository db, string id) => {
    return db.GetUserById(id);
});

app.MapGet("/users", ([FromServices] IDataRepository db) => {
    return db.GetUsers();
});

app.MapPut("/user/{id}", ([FromServices] IDataRepository db, User user) => {
    return db.PutUser(user);
});

app.MapPost("/user", ([FromServices] IDataRepository db, User user) => {
    return db.AddUser(user);
});

//Needed right now for Integrationtest
app.MapGet("/test", (Func<string>)(() => {
    return "OK";
}));
app.Run();

public partial class Program { }
