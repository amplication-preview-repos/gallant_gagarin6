using RecruitmentAndPayrollManagementSystem.Core.Enums;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

public class PayrollCreateInput
{
    public StaffAgency? Agency { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? PayDate { get; set; }

    public double? SalaryAmount { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
