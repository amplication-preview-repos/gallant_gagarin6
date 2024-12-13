using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    public List<ApplicationDbModel>? Applications { get; set; } = new List<ApplicationDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<JobDbModel>? Jobs { get; set; } = new List<JobDbModel>();

    [StringLength(256)]
    public string? LastName { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Required()]
    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    [Required()]
    public string Roles { get; set; }

    public List<SkillDbModel>? Skills { get; set; } = new List<SkillDbModel>();

    public List<StaffAgencyDbModel>? StaffAgencies { get; set; } = new List<StaffAgencyDbModel>();

    public string? StaffAgencyId { get; set; }

    [ForeignKey(nameof(StaffAgencyId))]
    public StaffAgencyDbModel? StaffAgency { get; set; } = null;

    public string? StaffDataId { get; set; }

    [ForeignKey(nameof(StaffDataId))]
    public StaffDbModel? StaffData { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }

    public string? WalletsId { get; set; }

    [ForeignKey(nameof(WalletsId))]
    public WalletDbModel? Wallets { get; set; } = null;
}
