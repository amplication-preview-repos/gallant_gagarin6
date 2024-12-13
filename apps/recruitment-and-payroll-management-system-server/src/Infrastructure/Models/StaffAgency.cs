using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("StaffAgencies")]
public class StaffAgencyDbModel
{
    public string? AgencyDetails { get; set; }

    [Required()]
    [StringLength(1000)]
    public string AgencyName { get; set; }

    public List<ApplicationDbModel>? Applications { get; set; } = new List<ApplicationDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    public List<UserDbModel>? EmployedStaff { get; set; } = new List<UserDbModel>();

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<PayrollDbModel>? Payrolls { get; set; } = new List<PayrollDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
