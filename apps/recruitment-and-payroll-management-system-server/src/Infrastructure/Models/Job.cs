using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Jobs")]
public class JobDbModel
{
    public string? AcceptedById { get; set; }

    [ForeignKey(nameof(AcceptedById))]
    public UserDbModel? AcceptedBy { get; set; } = null;

    public List<ApplicationDbModel>? Applications { get; set; } = new List<ApplicationDbModel>();

    public bool? Completed { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(1000)]
    public string? Duration { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public bool? IsAcceptedByAgency { get; set; }

    public bool? IsPaid { get; set; }

    [Required()]
    [Range(-999999999, 999999999)]
    public double PayRate { get; set; }

    public List<PaymentDbModel>? Payments { get; set; } = new List<PaymentDbModel>();

    [StringLength(1000)]
    public string? PostedBy { get; set; }

    public List<RatingDbModel>? Ratings { get; set; } = new List<RatingDbModel>();

    public List<SkillDbModel>? RequiredSkills { get; set; } = new List<SkillDbModel>();

    public StatusEnum? Status { get; set; }

    [Required()]
    [StringLength(1000)]
    public string Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
