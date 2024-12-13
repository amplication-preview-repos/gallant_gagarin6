using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class Application
{
    public string? Applicant { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? Job { get; set; }

    public string? StaffAgency { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
