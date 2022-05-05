using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("AppDb");

builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserDbContext>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Endpoints
app.MapGet("/", () => "UserService. Hello World!");

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
