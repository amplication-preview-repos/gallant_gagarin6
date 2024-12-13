namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class StaffAgency
{
    public string? AgencyDetails { get; set; }

    public string AgencyName { get; set; }

    public List<string>? Applications { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<string>? EmployedStaff { get; set; }

    public string Id { get; set; }

    public List<string>? Payrolls { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
