using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class Job
{
    public string? AcceptedBy { get; set; }

    public List<string>? Applications { get; set; }

    public bool? Completed { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Duration { get; set; }

    public string Id { get; set; }

    public bool? IsAcceptedByAgency { get; set; }

    public bool? IsPaid { get; set; }

    public double PayRate { get; set; }

    public List<string>? Payments { get; set; }

    public string? PostedBy { get; set; }

    public List<string>? Ratings { get; set; }

    public List<string>? RequiredSkills { get; set; }

    public StatusEnum? Status { get; set; }

    public string Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
