using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class PayrollsServiceBase : IPayrollsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public PayrollsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Payroll
    /// </summary>
    public async Task<Payroll> CreatePayroll(PayrollCreateInput createDto)
    {
        var payroll = new PayrollDbModel
        {
            CreatedAt = createDto.CreatedAt,
            PayDate = createDto.PayDate,
            SalaryAmount = createDto.SalaryAmount,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            payroll.Id = createDto.Id;
        }
        if (createDto.Agency != null)
        {
            payroll.Agency = await _context
                .StaffAgencies.Where(staffAgency => createDto.Agency.Id == staffAgency.Id)
                .FirstOrDefaultAsync();
        }

        _context.Payrolls.Add(payroll);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PayrollDbModel>(payroll.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Payroll
    /// </summary>
    public async Task DeletePayroll(PayrollWhereUniqueInput uniqueId)
    {
        var payroll = await _context.Payrolls.FindAsync(uniqueId.Id);
        if (payroll == null)
        {
            throw new NotFoundException();
        }

        _context.Payrolls.Remove(payroll);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Payrolls
    /// </summary>
    public async Task<List<Payroll>> Payrolls(PayrollFindManyArgs findManyArgs)
    {
        var payrolls = await _context
            .Payrolls.Include(x => x.Agency)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return payrolls.ConvertAll(payroll => payroll.ToDto());
    }

    /// <summary>
    /// Meta data about Payroll records
    /// </summary>
    public async Task<MetadataDto> PayrollsMeta(PayrollFindManyArgs findManyArgs)
    {
        var count = await _context.Payrolls.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Payroll
    /// </summary>
    public async Task<Payroll> Payroll(PayrollWhereUniqueInput uniqueId)
    {
        var payrolls = await this.Payrolls(
            new PayrollFindManyArgs { Where = new PayrollWhereInput { Id = uniqueId.Id } }
        );
        var payroll = payrolls.FirstOrDefault();
        if (payroll == null)
        {
            throw new NotFoundException();
        }

        return payroll;
    }

    /// <summary>
    /// Update one Payroll
    /// </summary>
    public async Task UpdatePayroll(PayrollWhereUniqueInput uniqueId, PayrollUpdateInput updateDto)
    {
        var payroll = updateDto.ToModel(uniqueId);

        if (updateDto.Agency != null)
        {
            payroll.Agency = await _context
                .StaffAgencies.Where(staffAgency => updateDto.Agency == staffAgency.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(payroll).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Payrolls.Any(e => e.Id == payroll.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
