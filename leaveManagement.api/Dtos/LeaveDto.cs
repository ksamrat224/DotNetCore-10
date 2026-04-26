namespace leaveManagement.api.Dtos;

//A DTO (Data Transfer Object) is a contract between the client  and the server it represents a shared agreement  about how  data will be trransferred  and used
public record  LeaveDto (
    int Id,
    string EmployeeName,
    string LeaveType,
    DateTime StartDate,
    DateTime EndDate,
    string Reason
);
