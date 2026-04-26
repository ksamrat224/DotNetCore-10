var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//creating the instance of the database context and seeding the data
app.MapGet("/", () => "Hello World!");

app.Run();
