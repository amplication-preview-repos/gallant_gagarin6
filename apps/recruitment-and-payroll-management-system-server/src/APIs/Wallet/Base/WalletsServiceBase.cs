using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class WalletsServiceBase : IWalletsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public WalletsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Wallet
    /// </summary>
    public async Task<Wallet> CreateWallet(WalletCreateInput createDto)
    {
        var wallet = new WalletDbModel
        {
            Balance = createDto.Balance,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            wallet.Id = createDto.Id;
        }
        if (createDto.Transactions != null)
        {
            wallet.Transactions = await _context
                .Transactions.Where(transaction =>
                    createDto.Transactions.Select(t => t.Id).Contains(transaction.Id)
                )
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            wallet.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Wallets.Add(wallet);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WalletDbModel>(wallet.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Wallet
    /// </summary>
    public async Task DeleteWallet(WalletWhereUniqueInput uniqueId)
    {
        var wallet = await _context.Wallets.FindAsync(uniqueId.Id);
        if (wallet == null)
        {
            throw new NotFoundException();
        }

        _context.Wallets.Remove(wallet);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Wallets
    /// </summary>
    public async Task<List<Wallet>> Wallets(WalletFindManyArgs findManyArgs)
    {
        var wallets = await _context
            .Wallets.Include(x => x.User)
            .Include(x => x.Transactions)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return wallets.ConvertAll(wallet => wallet.ToDto());
    }

    /// <summary>
    /// Meta data about Wallet records
    /// </summary>
    public async Task<MetadataDto> WalletsMeta(WalletFindManyArgs findManyArgs)
    {
        var count = await _context.Wallets.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Wallet
    /// </summary>
    public async Task<Wallet> Wallet(WalletWhereUniqueInput uniqueId)
    {
        var wallets = await this.Wallets(
            new WalletFindManyArgs { Where = new WalletWhereInput { Id = uniqueId.Id } }
        );
        var wallet = wallets.FirstOrDefault();
        if (wallet == null)
        {
            throw new NotFoundException();
        }

        return wallet;
    }

    /// <summary>
    /// Update one Wallet
    /// </summary>
    public async Task UpdateWallet(WalletWhereUniqueInput uniqueId, WalletUpdateInput updateDto)
    {
        var wallet = updateDto.ToModel(uniqueId);

        if (updateDto.Transactions != null)
        {
            wallet.Transactions = await _context
                .Transactions.Where(transaction =>
                    updateDto.Transactions.Select(t => t).Contains(transaction.Id)
                )
                .ToListAsync();
        }

        if (updateDto.User != null)
        {
            wallet.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(wallet).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Wallets.Any(e => e.Id == wallet.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Transactions records to Wallet
    /// </summary>
    public async Task ConnectTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Wallets.Include(x => x.Transactions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Transactions.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Transactions);

        foreach (var child in childrenToConnect)
        {
            parent.Transactions.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Transactions records from Wallet
    /// </summary>
    public async Task DisconnectTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Wallets.Include(x => x.Transactions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Transactions.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Transactions?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Transactions records for Wallet
    /// </summary>
    public async Task<List<Transaction>> FindTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionFindManyArgs walletFindManyArgs
    )
    {
        var transactions = await _context
            .Transactions.Where(m => m.WalletId == uniqueId.Id)
            .ApplyWhere(walletFindManyArgs.Where)
            .ApplySkip(walletFindManyArgs.Skip)
            .ApplyTake(walletFindManyArgs.Take)
            .ApplyOrderBy(walletFindManyArgs.SortBy)
            .ToListAsync();

        return transactions.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Transactions records for Wallet
    /// </summary>
    public async Task UpdateTransactions(
        WalletWhereUniqueInput uniqueId,
        TransactionWhereUniqueInput[] childrenIds
    )
    {
        var wallet = await _context
            .Wallets.Include(t => t.Transactions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (wallet == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Transactions.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        wallet.Transactions = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a user record for Wallet
    /// </summary>
    public async Task<User> GetUser(WalletWhereUniqueInput uniqueId)
    {
        var wallet = await _context
            .Wallets.Where(wallet => wallet.Id == uniqueId.Id)
            .Include(wallet => wallet.User)
            .FirstOrDefaultAsync();
        if (wallet == null)
        {
            throw new NotFoundException();
        }
        return wallet.User.ToDto();
    }
}
