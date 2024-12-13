using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Payrolls")]
public class PayrollDbModel
{
    public string? AgencyId { get; set; }

    [ForeignKey(nameof(AgencyId))]
    public StaffAgencyDbModel? Agency { get; set; } = null;

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? PayDate { get; set; }

    [Range(-999999999, 999999999)]
    public double? SalaryAmount { get; set; }

    public StatusEnum? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
