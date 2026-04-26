namespace leaveManagement.api.Dtos;

public record  UpdateLeaveDto
(
    string EmployeeName,
    string LeaveType,
    DateTime StartDate,
    DateTime EndDate,
    string Reason
);

