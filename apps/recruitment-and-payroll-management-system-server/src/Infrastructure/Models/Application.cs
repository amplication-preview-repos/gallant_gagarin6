using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Applications")]
public class ApplicationDbModel
{
    [StringLength(1000)]
    public string? Applicant { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? JobId { get; set; }

    [ForeignKey(nameof(JobId))]
    public JobDbModel? Job { get; set; } = null;

    public string? StaffAgencyId { get; set; }

    [ForeignKey(nameof(StaffAgencyId))]
    public StaffAgencyDbModel? StaffAgency { get; set; } = null;

    public StatusEnum? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
