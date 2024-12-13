using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class TransactionsExtensions
{
    public static Transaction ToDto(this TransactionDbModel model)
    {
        return new Transaction
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Status = model.Status,
            TransactionType = model.TransactionType,
            UpdatedAt = model.UpdatedAt,
            Wallet = model.WalletId,
        };
    }

    public static TransactionDbModel ToModel(
        this TransactionUpdateInput updateDto,
        TransactionWhereUniqueInput uniqueId
    )
    {
        var transaction = new TransactionDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Description = updateDto.Description,
            Status = updateDto.Status,
            TransactionType = updateDto.TransactionType
        };

        if (updateDto.CreatedAt != null)
        {
            transaction.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            transaction.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Wallet != null)
        {
            transaction.WalletId = updateDto.Wallet;
        }

        return transaction;
    }
}
