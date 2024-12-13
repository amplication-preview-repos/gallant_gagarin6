using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Ratings")]
public class RatingDbModel
{
    [StringLength(1000)]
    public string? Comment { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? EntityRated { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? JobId { get; set; }

    [ForeignKey(nameof(JobId))]
    public JobDbModel? Job { get; set; } = null;

    [StringLength(1000)]
    public string? RatedBy { get; set; }

    [Range(-999999999, 999999999)]
    public int? RatingValue { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
