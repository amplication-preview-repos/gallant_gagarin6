using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class PaymentsExtensions
{
    public static Payment ToDto(this PaymentDbModel model)
    {
        return new Payment
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Job = model.JobId,
            Payer = model.Payer,
            Receiver = model.Receiver,
            Status = model.Status,
            TransactionDate = model.TransactionDate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PaymentDbModel ToModel(
        this PaymentUpdateInput updateDto,
        PaymentWhereUniqueInput uniqueId
    )
    {
        var payment = new PaymentDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Payer = updateDto.Payer,
            Receiver = updateDto.Receiver,
            Status = updateDto.Status,
            TransactionDate = updateDto.TransactionDate
        };

        if (updateDto.CreatedAt != null)
        {
            payment.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Job != null)
        {
            payment.JobId = updateDto.Job;
        }
        if (updateDto.UpdatedAt != null)
        {
            payment.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return payment;
    }
}
