using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IWalletsService
{
    /// <summary>
    /// Create one Wallet
    /// </summary>
    public Task<Wallet> CreateWallet(WalletCreateInput wallet);

    /// <summary>
    /// Delete one Wallet
    /// </summary>
    public Task DeleteWallet(WalletWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Wallets
    /// </summary>
    public Task<List<Wallet>> Wallets(WalletFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Wallet records
    /// </summary>
    public Task<MetadataDto> WalletsMeta(WalletFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Wallet
    /// </summary>
    public Task<Wallet> Wallet(WalletWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Wallet
    /// </summary>
    public Task UpdateWallet(WalletWhereUniqueInput uniqueId, WalletUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Transactions records to Wallet
    /// </summary>
    public Task ConnectTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionWhereUniqueInput[] transactionsId
    );

    /// <summary>
    /// Disconnect multiple Transactions records from Wallet
    /// </summary>
    public Task DisconnectTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionWhereUniqueInput[] transactionsId
    );

    /// <summary>
    /// Find multiple Transactions records for Wallet
    /// </summary>
    public Task<List<Transaction>> FindTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionFindManyArgs TransactionFindManyArgs
    );

    /// <summary>
    /// Update multiple Transactions records for Wallet
    /// </summary>
    public Task UpdateTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionWhereUniqueInput[] transactionsId
    );

    /// <summary>
    /// Get a user record for Wallet
    /// </summary>
    public Task<User> GetUser(WalletWhereUniqueInput uniqueId);
}
