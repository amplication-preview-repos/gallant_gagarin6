using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class StaffAgenciesServiceBase : IStaffAgenciesService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public StaffAgenciesServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one StaffAgency
    /// </summary>
    public async Task<StaffAgency> CreateStaffAgency(StaffAgencyCreateInput createDto)
    {
        var staffAgency = new StaffAgencyDbModel
        {
            AgencyDetails = createDto.AgencyDetails,
            AgencyName = createDto.AgencyName,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            staffAgency.Id = createDto.Id;
        }
        if (createDto.Applications != null)
        {
            staffAgency.Applications = await _context
                .Applications.Where(application =>
                    createDto.Applications.Select(t => t.Id).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (createDto.EmployedStaff != null)
        {
            staffAgency.EmployedStaff = await _context
                .Users.Where(user => createDto.EmployedStaff.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        if (createDto.Payrolls != null)
        {
            staffAgency.Payrolls = await _context
                .Payrolls.Where(payroll =>
                    createDto.Payrolls.Select(t => t.Id).Contains(payroll.Id)
                )
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            staffAgency.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.StaffAgencies.Add(staffAgency);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<StaffAgencyDbModel>(staffAgency.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one StaffAgency
    /// </summary>
    public async Task DeleteStaffAgency(StaffAgencyWhereUniqueInput uniqueId)
    {
        var staffAgency = await _context.StaffAgencies.FindAsync(uniqueId.Id);
        if (staffAgency == null)
        {
            throw new NotFoundException();
        }

        _context.StaffAgencies.Remove(staffAgency);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many StaffAgencies
    /// </summary>
    public async Task<List<StaffAgency>> StaffAgencies(StaffAgencyFindManyArgs findManyArgs)
    {
        var staffAgencies = await _context
            .StaffAgencies.Include(x => x.Payrolls)
            .Include(x => x.EmployedStaff)
            .Include(x => x.Applications)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return staffAgencies.ConvertAll(staffAgency => staffAgency.ToDto());
    }

    /// <summary>
    /// Meta data about StaffAgency records
    /// </summary>
    public async Task<MetadataDto> StaffAgenciesMeta(StaffAgencyFindManyArgs findManyArgs)
    {
        var count = await _context.StaffAgencies.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one StaffAgency
    /// </summary>
    public async Task<StaffAgency> StaffAgency(StaffAgencyWhereUniqueInput uniqueId)
    {
        var staffAgencies = await this.StaffAgencies(
            new StaffAgencyFindManyArgs { Where = new StaffAgencyWhereInput { Id = uniqueId.Id } }
        );
        var staffAgency = staffAgencies.FirstOrDefault();
        if (staffAgency == null)
        {
            throw new NotFoundException();
        }

        return staffAgency;
    }

    /// <summary>
    /// Update one StaffAgency
    /// </summary>
    public async Task UpdateStaffAgency(
        StaffAgencyWhereUniqueInput uniqueId,
        StaffAgencyUpdateInput updateDto
    )
    {
        var staffAgency = updateDto.ToModel(uniqueId);

        if (updateDto.Applications != null)
        {
            staffAgency.Applications = await _context
                .Applications.Where(application =>
                    updateDto.Applications.Select(t => t).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (updateDto.EmployedStaff != null)
        {
            staffAgency.EmployedStaff = await _context
                .Users.Where(user => updateDto.EmployedStaff.Select(t => t).Contains(user.Id))
                .ToListAsync();
        }

        if (updateDto.Payrolls != null)
        {
            staffAgency.Payrolls = await _context
                .Payrolls.Where(payroll => updateDto.Payrolls.Select(t => t).Contains(payroll.Id))
                .ToListAsync();
        }

        if (updateDto.User != null)
        {
            staffAgency.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(staffAgency).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.StaffAgencies.Any(e => e.Id == staffAgency.Id))
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
    /// Connect multiple applications records to StaffAgency
    /// </summary>
    public async Task ConnectApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffAgencies.Include(x => x.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Applications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Applications);

        foreach (var child in childrenToConnect)
        {
            parent.Applications.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple applications records from StaffAgency
    /// </summary>
    public async Task DisconnectApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffAgencies.Include(x => x.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Applications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Applications?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple applications records for StaffAgency
    /// </summary>
    public async Task<List<Application>> FindApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationFindManyArgs staffAgencyFindManyArgs
    )
    {
        var applications = await _context
            .Applications.Where(m => m.StaffAgencyId == uniqueId.Id)
            .ApplyWhere(staffAgencyFindManyArgs.Where)
            .ApplySkip(staffAgencyFindManyArgs.Skip)
            .ApplyTake(staffAgencyFindManyArgs.Take)
            .ApplyOrderBy(staffAgencyFindManyArgs.SortBy)
            .ToListAsync();

        return applications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple applications records for StaffAgency
    /// </summary>
    public async Task UpdateApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var staffAgency = await _context
            .StaffAgencies.Include(t => t.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (staffAgency == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Applications.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        staffAgency.Applications = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple employedStaff records to StaffAgency
    /// </summary>
    public async Task ConnectEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffAgencies.Include(x => x.EmployedStaff)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.EmployedStaff);

        foreach (var child in childrenToConnect)
        {
            parent.EmployedStaff.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple employedStaff records from StaffAgency
    /// </summary>
    public async Task DisconnectEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffAgencies.Include(x => x.EmployedStaff)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.EmployedStaff?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple employedStaff records for StaffAgency
    /// </summary>
    public async Task<List<User>> FindEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserFindManyArgs staffAgencyFindManyArgs
    )
    {
        var users = await _context
            .Users.Where(m => m.StaffAgencyId == uniqueId.Id)
            .ApplyWhere(staffAgencyFindManyArgs.Where)
            .ApplySkip(staffAgencyFindManyArgs.Skip)
            .ApplyTake(staffAgencyFindManyArgs.Take)
            .ApplyOrderBy(staffAgencyFindManyArgs.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple employedStaff records for StaffAgency
    /// </summary>
    public async Task UpdateEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var staffAgency = await _context
            .StaffAgencies.Include(t => t.EmployedStaff)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (staffAgency == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        staffAgency.EmployedStaff = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple payrolls records to StaffAgency
    /// </summary>
    public async Task ConnectPayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffAgencies.Include(x => x.Payrolls)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Payrolls.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Payrolls);

        foreach (var child in childrenToConnect)
        {
            parent.Payrolls.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple payrolls records from StaffAgency
    /// </summary>
    public async Task DisconnectPayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffAgencies.Include(x => x.Payrolls)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Payrolls.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Payrolls?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple payrolls records for StaffAgency
    /// </summary>
    public async Task<List<Payroll>> FindPayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollFindManyArgs staffAgencyFindManyArgs
    )
    {
        var payrolls = await _context
            .Payrolls.Where(m => m.AgencyId == uniqueId.Id)
            .ApplyWhere(staffAgencyFindManyArgs.Where)
            .ApplySkip(staffAgencyFindManyArgs.Skip)
            .ApplyTake(staffAgencyFindManyArgs.Take)
            .ApplyOrderBy(staffAgencyFindManyArgs.SortBy)
            .ToListAsync();

        return payrolls.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple payrolls records for StaffAgency
    /// </summary>
    public async Task UpdatePayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollWhereUniqueInput[] childrenIds
    )
    {
        var staffAgency = await _context
            .StaffAgencies.Include(t => t.Payrolls)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (staffAgency == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Payrolls.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        staffAgency.Payrolls = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a user record for StaffAgency
    /// </summary>
    public async Task<User> GetUser(StaffAgencyWhereUniqueInput uniqueId)
    {
        var staffAgency = await _context
            .StaffAgencies.Where(staffAgency => staffAgency.Id == uniqueId.Id)
            .Include(staffAgency => staffAgency.User)
            .FirstOrDefaultAsync();
        if (staffAgency == null)
        {
            throw new NotFoundException();
        }
        return staffAgency.User.ToDto();
    }
}
