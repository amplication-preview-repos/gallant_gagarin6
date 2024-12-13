namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class StaffCreateInput
{
    public bool? Availability { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Cv { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<Skill>? Skills { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
