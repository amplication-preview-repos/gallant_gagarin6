using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class PayrollsExtensions
{
    public static Payroll ToDto(this PayrollDbModel model)
    {
        return new Payroll
        {
            Agency = model.AgencyId,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PayDate = model.PayDate,
            SalaryAmount = model.SalaryAmount,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PayrollDbModel ToModel(
        this PayrollUpdateInput updateDto,
        PayrollWhereUniqueInput uniqueId
    )
    {
        var payroll = new PayrollDbModel
        {
            Id = uniqueId.Id,
            PayDate = updateDto.PayDate,
            SalaryAmount = updateDto.SalaryAmount,
            Status = updateDto.Status
        };

        if (updateDto.Agency != null)
        {
            payroll.AgencyId = updateDto.Agency;
        }
        if (updateDto.CreatedAt != null)
        {
            payroll.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            payroll.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return payroll;
    }
}
