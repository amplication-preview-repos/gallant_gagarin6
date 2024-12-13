using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Skills")]
public class SkillDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? JobId { get; set; }

    [ForeignKey(nameof(JobId))]
    public JobDbModel? Job { get; set; } = null;

    [Required()]
    [StringLength(1000)]
    public string Name { get; set; }

    public string? StaffItemsId { get; set; }

    [ForeignKey(nameof(StaffItemsId))]
    public StaffDbModel? StaffItems { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
