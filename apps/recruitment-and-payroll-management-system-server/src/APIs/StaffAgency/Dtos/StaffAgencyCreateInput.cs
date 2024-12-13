namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class StaffAgencyCreateInput
{
    public string? AgencyDetails { get; set; }

    public string AgencyName { get; set; }

    public List<Application>? Applications { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<User>? EmployedStaff { get; set; }

    public string? Id { get; set; }

    public List<Payroll>? Payrolls { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
