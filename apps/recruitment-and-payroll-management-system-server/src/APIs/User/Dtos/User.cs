using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class User
{
    public List<string>? Applications { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string Id { get; set; }

    public List<string>? Jobs { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    public string Roles { get; set; }

    public List<string>? Skills { get; set; }

    public List<string>? StaffAgencies { get; set; }

    public string? StaffAgency { get; set; }

    public string? StaffData { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }

    public string? Wallets { get; set; }
}
