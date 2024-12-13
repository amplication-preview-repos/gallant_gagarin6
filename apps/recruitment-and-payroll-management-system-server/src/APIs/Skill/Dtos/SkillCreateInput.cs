namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class SkillCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public Job? Job { get; set; }

    public string Name { get; set; }

    public Staff? StaffItems { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
