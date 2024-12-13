using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class TransactionsServiceBase : ITransactionsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public TransactionsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Transaction
    /// </summary>
    public async Task<Transaction> CreateTransaction(TransactionCreateInput createDto)
    {
        var transaction = new TransactionDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Status = createDto.Status,
            TransactionType = createDto.TransactionType,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            transaction.Id = createDto.Id;
        }
        if (createDto.Wallet != null)
        {
            transaction.Wallet = await _context
                .Wallets.Where(wallet => createDto.Wallet.Id == wallet.Id)
                .FirstOrDefaultAsync();
        }

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TransactionDbModel>(transaction.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Transaction
    /// </summary>
    public async Task DeleteTransaction(TransactionWhereUniqueInput uniqueId)
    {
        var transaction = await _context.Transactions.FindAsync(uniqueId.Id);
        if (transaction == null)
        {
            throw new NotFoundException();
        }

        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Transactions
    /// </summary>
    public async Task<List<Transaction>> Transactions(TransactionFindManyArgs findManyArgs)
    {
        var transactions = await _context
            .Transactions.Include(x => x.Wallet)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return transactions.ConvertAll(transaction => transaction.ToDto());
    }

    /// <summary>
    /// Meta data about Transaction records
    /// </summary>
    public async Task<MetadataDto> TransactionsMeta(TransactionFindManyArgs findManyArgs)
    {
        var count = await _context.Transactions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Transaction
    /// </summary>
    public async Task<Transaction> Transaction(TransactionWhereUniqueInput uniqueId)
    {
        var transactions = await this.Transactions(
            new TransactionFindManyArgs { Where = new TransactionWhereInput { Id = uniqueId.Id } }
        );
        var transaction = transactions.FirstOrDefault();
        if (transaction == null)
        {
            throw new NotFoundException();
        }

        return transaction;
    }

    /// <summary>
    /// Update one Transaction
    /// </summary>
    public async Task UpdateTransaction(
        TransactionWhereUniqueInput uniqueId,
        TransactionUpdateInput updateDto
    )
    {
        var transaction = updateDto.ToModel(uniqueId);

        if (updateDto.Wallet != null)
        {
            transaction.Wallet = await _context
                .Wallets.Where(wallet => updateDto.Wallet == wallet.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(transaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Transactions.Any(e => e.Id == transaction.Id))
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
    /// Get a wallet record for Transaction
    /// </summary>
    public async Task<Wallet> GetWallet(TransactionWhereUniqueInput uniqueId)
    {
        var transaction = await _context
            .Transactions.Where(transaction => transaction.Id == uniqueId.Id)
            .Include(transaction => transaction.Wallet)
            .FirstOrDefaultAsync();
        if (transaction == null)
        {
            throw new NotFoundException();
        }
        return transaction.Wallet.ToDto();
    }
}
