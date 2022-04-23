using Twooter.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/user", (Func<User>)(() => {

    return new User
    {
        id = 0,
        name = "Pieter"
    };
}));

app.MapGet("/test", (Func<string>)(() => {
    return "OK";
    //new Status
    //{
    //    code = 200,
    //    message = "Ok"
    //};
}));
app.Run();

public partial class Program { }
