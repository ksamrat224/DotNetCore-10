using leaveManagement.api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//creating the instance of the database context and seeding the data

List<LeaveDto> leaves = new List<LeaveDto>
{
    new LeaveDto(1, "John Doe", "Vacation", new DateTime(2024, 7, 1), new DateTime(2024, 7, 10), "Family vacation"),
    new LeaveDto(2, "Jane Smith", "Sick Leave", new DateTime(2024, 8, 15), new DateTime(2024, 8, 20), "Flu"),
    new LeaveDto(3, "Bob Johnson", "Maternity Leave", new DateTime(2024, 9, 1), new DateTime(2024, 12, 1), "Maternity leave")
};
//GET /leaves
app.MapGet("/leaves", () => leaves);
//GET /leaves/{id}
app.MapGet("/leaves/{id}", (int id) =>
{
    var leave = leaves.FirstOrDefault(l => l.Id == id);
    if (leave is null)
    {
        return Results.Problem(
            statusCode: 404,
            title: "Leave Not Found",
            detail: $"Leave with ID {id} was not found."
        );
    }
    return Results.Ok(leave);
});

app.Run();
