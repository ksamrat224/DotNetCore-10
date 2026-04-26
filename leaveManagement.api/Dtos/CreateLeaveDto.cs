namespace leaveManagement.api.Dtos;

public record  CreateLeaveDto
(
    string EmployeeName,
    string LeaveType,
    DateTime StartDate,
    DateTime EndDate,
    string Reason
);