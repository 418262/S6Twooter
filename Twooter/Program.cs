using Twooter.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/user", (Func<User>)(() => {

    return new User
    {
        Id = "0",
        Name = "Pieter"
    };
}));

app.MapGet("/users", (Func<List<User>>)(() => {
    return new UserCollection().GetUsers();
}));

app.MapGet("/user/{id}", async (http) => {

    if(!http.Request.RouteValues.TryGetValue("id", out var id))
    {
        http.Response.StatusCode = 400;
        return;
    }
    else
    {
        await http.Response.WriteAsJsonAsync(new UserCollection()
            .GetUsers()
            .FirstOrDefault(x => x.Id == (string)id));
    }
});

//Integrationtest
app.MapGet("/test", (Func<string>)(() => {
    return "OK";
}));
app.Run();

public partial class Program { }
