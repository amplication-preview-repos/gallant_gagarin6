using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Staff")]
public class StaffDbModel
{
    public bool? Availability { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Cv { get; set; }

    public string? Email { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public List<SkillDbModel>? Skills { get; set; } = new List<SkillDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public UserDbModel? User { get; set; } = null;
}
