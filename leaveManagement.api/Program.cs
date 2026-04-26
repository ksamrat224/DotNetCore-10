var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//creating the instance of the database context and seeding the data

//GET /leaves
app.MapGet("/leaves", () => "Hello World!");

app.Run();
