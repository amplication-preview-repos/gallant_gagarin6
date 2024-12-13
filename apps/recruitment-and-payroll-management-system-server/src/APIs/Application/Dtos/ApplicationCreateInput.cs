using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class ApplicationCreateInput
{
    public string? Applicant { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public Job? Job { get; set; }

    public StaffAgency? StaffAgency { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
