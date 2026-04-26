using leaveManagement.api.Dtos;
const string GetLeaveEndpointName = "GetLeaveById";

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
}).WithName(GetLeaveEndpointName);

//POST /leaves
app.MapPost("/leaves", (CreateLeaveDto newLeave) =>
{
    //In a real application, we would save the new leave to the database here
    //For this example, we'll just add it to the in-memory list
    LeaveDto leave = new LeaveDto(
        Id: leaves.Count + 1, // Generate a new ID based on the count of existing leaves
        EmployeeName: newLeave.EmployeeName,
        LeaveType: newLeave.LeaveType,
        StartDate: newLeave.StartDate,
        EndDate: newLeave.EndDate,
        Reason: newLeave.Reason
    );
    leaves.Add(leave);
    return Results.CreatedAtRoute(GetLeaveEndpointName, new { id = leave.Id }, leave);
});
//PUT /leaves/{id}
app.MapPut("/leaves/{id}", (int id, UpdateLeaveDto updatedLeave) =>
{
    var index = leaves.FindIndex(l => l.Id == id);
    
    if (index == -1)
    {
        return Results.Problem(
            statusCode: 404,
            title: "Leave Not Found",
            detail: $"Leave with ID {id} was not found."
        );
    }

    leaves[index] = new LeaveDto(
        Id: id,
        EmployeeName: updatedLeave.EmployeeName,
        LeaveType: updatedLeave.LeaveType,
        StartDate: updatedLeave.StartDate,
        EndDate: updatedLeave.EndDate,
        Reason: updatedLeave.Reason
    );

   return Results.Ok(new { message = $"Leave with ID {id} has been updated successfully.", data = leaves[index] });
});

app.Run();
