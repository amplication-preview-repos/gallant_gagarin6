using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public UsersServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    public async Task<User> CreateUser(UserCreateInput createDto)
    {
        var user = new UserDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Name = createDto.Name,
            Password = createDto.Password,
            Role = createDto.Role,
            Roles = createDto.Roles,
            UpdatedAt = createDto.UpdatedAt,
            Username = createDto.Username
        };

        if (createDto.Id != null)
        {
            user.Id = createDto.Id;
        }
        if (createDto.Applications != null)
        {
            user.Applications = await _context
                .Applications.Where(application =>
                    createDto.Applications.Select(t => t.Id).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (createDto.Jobs != null)
        {
            user.Jobs = await _context
                .Jobs.Where(job => createDto.Jobs.Select(t => t.Id).Contains(job.Id))
                .ToListAsync();
        }

        if (createDto.Skills != null)
        {
            user.Skills = await _context
                .Skills.Where(skill => createDto.Skills.Select(t => t.Id).Contains(skill.Id))
                .ToListAsync();
        }

        if (createDto.StaffAgencies != null)
        {
            user.StaffAgencies = await _context
                .StaffAgencies.Where(staffAgency =>
                    createDto.StaffAgencies.Select(t => t.Id).Contains(staffAgency.Id)
                )
                .ToListAsync();
        }

        if (createDto.StaffAgency != null)
        {
            user.StaffAgency = await _context
                .StaffAgencies.Where(staffAgency => createDto.StaffAgency.Id == staffAgency.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.StaffData != null)
        {
            user.StaffData = await _context
                .StaffItems.Where(staff => createDto.StaffData.Id == staff.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Wallets != null)
        {
            user.Wallets = await _context
                .Wallets.Where(wallet => createDto.Wallets.Id == wallet.Id)
                .FirstOrDefaultAsync();
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserDbModel>(user.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    public async Task DeleteUser(UserWhereUniqueInput uniqueId)
    {
        var user = await _context.Users.FindAsync(uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    public async Task<List<User>> Users(UserFindManyArgs findManyArgs)
    {
        var users = await _context
            .Users.Include(x => x.StaffData)
            .Include(x => x.Jobs)
            .Include(x => x.Wallets)
            .Include(x => x.Applications)
            .Include(x => x.StaffAgencies)
            .Include(x => x.Skills)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return users.ConvertAll(user => user.ToDto());
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public async Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs)
    {
        var count = await _context.Users.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one User
    /// </summary>
    public async Task<User> User(UserWhereUniqueInput uniqueId)
    {
        var users = await this.Users(
            new UserFindManyArgs { Where = new UserWhereInput { Id = uniqueId.Id } }
        );
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    /// <summary>
    /// Update one User
    /// </summary>
    public async Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto)
    {
        var user = updateDto.ToModel(uniqueId);

        if (updateDto.Applications != null)
        {
            user.Applications = await _context
                .Applications.Where(application =>
                    updateDto.Applications.Select(t => t).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Jobs != null)
        {
            user.Jobs = await _context
                .Jobs.Where(job => updateDto.Jobs.Select(t => t).Contains(job.Id))
                .ToListAsync();
        }

        if (updateDto.Skills != null)
        {
            user.Skills = await _context
                .Skills.Where(skill => updateDto.Skills.Select(t => t).Contains(skill.Id))
                .ToListAsync();
        }

        if (updateDto.StaffAgencies != null)
        {
            user.StaffAgencies = await _context
                .StaffAgencies.Where(staffAgency =>
                    updateDto.StaffAgencies.Select(t => t).Contains(staffAgency.Id)
                )
                .ToListAsync();
        }

        if (updateDto.StaffAgency != null)
        {
            user.StaffAgency = await _context
                .StaffAgencies.Where(staffAgency => updateDto.StaffAgency == staffAgency.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.StaffData != null)
        {
            user.StaffData = await _context
                .StaffItems.Where(staff => updateDto.StaffData == staff.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Wallets != null)
        {
            user.Wallets = await _context
                .Wallets.Where(wallet => updateDto.Wallets == wallet.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == user.Id))
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
    /// Connect multiple applications records to User
    /// </summary>
    public async Task ConnectApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Applications)
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
    /// Disconnect multiple applications records from User
    /// </summary>
    public async Task DisconnectApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Applications)
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
    /// Find multiple applications records for User
    /// </summary>
    public async Task<List<Application>> FindApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationFindManyArgs userFindManyArgs
    )
    {
        var applications = await _context
            .Applications.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return applications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple applications records for User
    /// </summary>
    public async Task UpdateApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
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

        user.Applications = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Jobs records to User
    /// </summary>
    public async Task ConnectJobs(UserWhereUniqueInput uniqueId, JobWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
            .Users.Include(x => x.Jobs)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Jobs.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Jobs);

        foreach (var child in childrenToConnect)
        {
            parent.Jobs.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Jobs records from User
    /// </summary>
    public async Task DisconnectJobs(
        UserWhereUniqueInput uniqueId,
        JobWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Jobs)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Jobs.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Jobs?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Jobs records for User
    /// </summary>
    public async Task<List<Job>> FindJobs(
        UserWhereUniqueInput uniqueId,
        JobFindManyArgs userFindManyArgs
    )
    {
        var jobs = await _context
            .Jobs.Where(m => m.AcceptedById == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return jobs.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Jobs records for User
    /// </summary>
    public async Task UpdateJobs(UserWhereUniqueInput uniqueId, JobWhereUniqueInput[] childrenIds)
    {
        var user = await _context
            .Users.Include(t => t.Jobs)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Jobs.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Jobs = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple skills records to User
    /// </summary>
    public async Task ConnectSkills(
        UserWhereUniqueInput uniqueId,
        SkillWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Skills)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Skills.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Skills);

        foreach (var child in childrenToConnect)
        {
            parent.Skills.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple skills records from User
    /// </summary>
    public async Task DisconnectSkills(
        UserWhereUniqueInput uniqueId,
        SkillWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Skills)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Skills.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Skills?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple skills records for User
    /// </summary>
    public async Task<List<Skill>> FindSkills(
        UserWhereUniqueInput uniqueId,
        SkillFindManyArgs userFindManyArgs
    )
    {
        var skills = await _context
            .Skills.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return skills.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple skills records for User
    /// </summary>
    public async Task UpdateSkills(
        UserWhereUniqueInput uniqueId,
        SkillWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.Skills)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Skills.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.Skills = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple staffAgencies records to User
    /// </summary>
    public async Task ConnectStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.StaffAgencies)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .StaffAgencies.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.StaffAgencies);

        foreach (var child in childrenToConnect)
        {
            parent.StaffAgencies.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple staffAgencies records from User
    /// </summary>
    public async Task DisconnectStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.StaffAgencies)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .StaffAgencies.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.StaffAgencies?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple staffAgencies records for User
    /// </summary>
    public async Task<List<StaffAgency>> FindStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyFindManyArgs userFindManyArgs
    )
    {
        var staffAgencies = await _context
            .StaffAgencies.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return staffAgencies.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple staffAgencies records for User
    /// </summary>
    public async Task UpdateStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.StaffAgencies)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .StaffAgencies.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.StaffAgencies = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a staffAgency record for User
    /// </summary>
    public async Task<StaffAgency> GetStaffAgency(UserWhereUniqueInput uniqueId)
    {
        var user = await _context
            .Users.Where(user => user.Id == uniqueId.Id)
            .Include(user => user.StaffAgency)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new NotFoundException();
        }
        return user.StaffAgency.ToDto();
    }

    /// <summary>
    /// Get a staffData record for User
    /// </summary>
    public async Task<Staff> GetStaffData(UserWhereUniqueInput uniqueId)
    {
        var user = await _context
            .Users.Where(user => user.Id == uniqueId.Id)
            .Include(user => user.StaffData)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new NotFoundException();
        }
        return user.StaffData.ToDto();
    }

    /// <summary>
    /// Get a wallet record for User
    /// </summary>
    public async Task<Wallet> GetWallets(UserWhereUniqueInput uniqueId)
    {
        var user = await _context
            .Users.Where(user => user.Id == uniqueId.Id)
            .Include(user => user.Wallets)
            .FirstOrDefaultAsync();
        if (user == null)
        {
            throw new NotFoundException();
        }
        return user.Wallets.ToDto();
    }
}
