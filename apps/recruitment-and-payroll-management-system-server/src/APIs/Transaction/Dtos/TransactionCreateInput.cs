using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class TransactionCreateInput
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public StatusEnum? Status { get; set; }

    public TransactionTypeEnum? TransactionType { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Wallet? Wallet { get; set; }
}
