namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class WalletUpdateInput
{
    public double? Balance { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public List<string>? Transactions { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }
}
