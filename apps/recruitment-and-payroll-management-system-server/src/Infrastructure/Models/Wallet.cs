using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

[Table("Wallets")]
public class WalletDbModel
{
    [Range(-999999999, 999999999)]
    public double? Balance { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public List<TransactionDbModel>? Transactions { get; set; } = new List<TransactionDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public UserDbModel? User { get; set; } = null;
}
