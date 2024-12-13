using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class UserCreateInput
{
    public List<Application>? Applications { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public List<Job>? Jobs { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    public string Roles { get; set; }

    public List<Skill>? Skills { get; set; }

    public List<StaffAgency>? StaffAgencies { get; set; }

    public StaffAgency? StaffAgency { get; set; }

    public Staff? StaffData { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }

    public Wallet? Wallets { get; set; }
}
