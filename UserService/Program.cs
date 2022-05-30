using UserService.Model;
using UserService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");

builder.Services.AddTransient<DataSeeder>();

builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

//Seed Data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

app.MapGet("/", () =>
{
    return "Hello World, UserService.";
});

app.MapGet("/users/{id}", ([FromServices] IDataRepository db, string id) => {
    return db.GetUserById(id);
});

app.MapGet("/users", ([FromServices] IDataRepository db) => {
    return db.GetUsers();
});

app.MapPut("/users/{id}", ([FromServices] IDataRepository db, User user) => {
    return db.PutUser(user);
});

app.MapPost("/users", ([FromServices] IDataRepository db, User user) => {
    return db.AddUser(user);
});

//Needed right now for Integrationtest
app.MapGet("/users/test", (Func<string>)(() => {
    return "Test";
}));

app.Run();