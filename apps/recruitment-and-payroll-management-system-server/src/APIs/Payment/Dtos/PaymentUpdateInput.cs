using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class PaymentUpdateInput
{
    public double? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Job { get; set; }

    public string? Payer { get; set; }

    public string? Receiver { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime? TransactionDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}