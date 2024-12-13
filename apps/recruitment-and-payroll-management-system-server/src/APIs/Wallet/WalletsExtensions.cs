using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class WalletsExtensions
{
    public static Wallet ToDto(this WalletDbModel model)
    {
        return new Wallet
        {
            Balance = model.Balance,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Transactions = model.Transactions?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
            User = model.User?.ToDto(),
        };
    }

    public static WalletDbModel ToModel(
        this WalletUpdateInput updateDto,
        WalletWhereUniqueInput uniqueId
    )
    {
        var wallet = new WalletDbModel { Id = uniqueId.Id, Balance = updateDto.Balance };

        if (updateDto.CreatedAt != null)
        {
            wallet.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            wallet.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return wallet;
    }
}
