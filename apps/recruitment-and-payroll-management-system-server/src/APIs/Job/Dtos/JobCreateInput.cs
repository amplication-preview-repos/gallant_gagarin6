using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class JobCreateInput
{
    public User? AcceptedBy { get; set; }

    public List<Application>? Applications { get; set; }

    public bool? Completed { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Duration { get; set; }

    public string? Id { get; set; }

    public bool? IsAcceptedByAgency { get; set; }

    public bool? IsPaid { get; set; }

    public double PayRate { get; set; }

    public List<Payment>? Payments { get; set; }

    public string? PostedBy { get; set; }

    public List<Rating>? Ratings { get; set; }

    public List<Skill>? RequiredSkills { get; set; }

    public StatusEnum? Status { get; set; }

    public string Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
