namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class Staff
{
    public bool? Availability { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Cv { get; set; }

    public string? Email { get; set; }

    public string Id { get; set; }

    public string? Name { get; set; }

    public List<string>? Skills { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
