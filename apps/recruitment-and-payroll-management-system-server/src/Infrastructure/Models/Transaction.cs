using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Transactions")]
public class TransactionDbModel
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public StatusEnum? Status { get; set; }

    public TransactionTypeEnum? TransactionType { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? WalletId { get; set; }

    [ForeignKey(nameof(WalletId))]
    public WalletDbModel? Wallet { get; set; } = null;
}
