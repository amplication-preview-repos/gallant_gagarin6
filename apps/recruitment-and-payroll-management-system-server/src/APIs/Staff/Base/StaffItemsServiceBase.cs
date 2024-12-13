using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class StaffItemsServiceBase : IStaffItemsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public StaffItemsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Staff
    /// </summary>
    public async Task<Staff> CreateStaff(StaffCreateInput createDto)
    {
        var staff = new StaffDbModel
        {
            Availability = createDto.Availability,
            CreatedAt = createDto.CreatedAt,
            Cv = createDto.Cv,
            Email = createDto.Email,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            staff.Id = createDto.Id;
        }
        if (createDto.Skills != null)
        {
            staff.Skills = await _context
                .Skills.Where(skill => createDto.Skills.Select(t => t.Id).Contains(skill.Id))
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            staff.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.StaffItems.Add(staff);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<StaffDbModel>(staff.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Staff
    /// </summary>
    public async Task DeleteStaff(StaffWhereUniqueInput uniqueId)
    {
        var staff = await _context.StaffItems.FindAsync(uniqueId.Id);
        if (staff == null)
        {
            throw new NotFoundException();
        }

        _context.StaffItems.Remove(staff);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many StaffItems
    /// </summary>
    public async Task<List<Staff>> StaffItems(StaffFindManyArgs findManyArgs)
    {
        var staffItems = await _context
            .StaffItems.Include(x => x.User)
            .Include(x => x.Skills)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return staffItems.ConvertAll(staff => staff.ToDto());
    }

    /// <summary>
    /// Meta data about Staff records
    /// </summary>
    public async Task<MetadataDto> StaffItemsMeta(StaffFindManyArgs findManyArgs)
    {
        var count = await _context.StaffItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Staff
    /// </summary>
    public async Task<Staff> Staff(StaffWhereUniqueInput uniqueId)
    {
        var staffItems = await this.StaffItems(
            new StaffFindManyArgs { Where = new StaffWhereInput { Id = uniqueId.Id } }
        );
        var staff = staffItems.FirstOrDefault();
        if (staff == null)
        {
            throw new NotFoundException();
        }

        return staff;
    }

    /// <summary>
    /// Update one Staff
    /// </summary>
    public async Task UpdateStaff(StaffWhereUniqueInput uniqueId, StaffUpdateInput updateDto)
    {
        var staff = updateDto.ToModel(uniqueId);

        if (updateDto.Skills != null)
        {
            staff.Skills = await _context
                .Skills.Where(skill => updateDto.Skills.Select(t => t).Contains(skill.Id))
                .ToListAsync();
        }

        if (updateDto.User != null)
        {
            staff.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(staff).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.StaffItems.Any(e => e.Id == staff.Id))
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
    /// Connect multiple skills records to Staff
    /// </summary>
    public async Task ConnectSkills(
        StaffWhereUniqueInput uniqueId,
        SkillWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffItems.Include(x => x.Skills)
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
    /// Disconnect multiple skills records from Staff
    /// </summary>
    public async Task DisconnectSkills(
        StaffWhereUniqueInput uniqueId,
        SkillWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .StaffItems.Include(x => x.Skills)
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
    /// Find multiple skills records for Staff
    /// </summary>
    public async Task<List<Skill>> FindSkills(
        StaffWhereUniqueInput uniqueId,
        SkillFindManyArgs staffFindManyArgs
    )
    {
        var skills = await _context
            .Skills.Where(m => m.StaffItemsId == uniqueId.Id)
            .ApplyWhere(staffFindManyArgs.Where)
            .ApplySkip(staffFindManyArgs.Skip)
            .ApplyTake(staffFindManyArgs.Take)
            .ApplyOrderBy(staffFindManyArgs.SortBy)
            .ToListAsync();

        return skills.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple skills records for Staff
    /// </summary>
    public async Task UpdateSkills(
        StaffWhereUniqueInput uniqueId,
        SkillWhereUniqueInput[] childrenIds
    )
    {
        var staff = await _context
            .StaffItems.Include(t => t.Skills)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (staff == null)
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

        staff.Skills = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a user record for Staff
    /// </summary>
    public async Task<User> GetUser(StaffWhereUniqueInput uniqueId)
    {
        var staff = await _context
            .StaffItems.Where(staff => staff.Id == uniqueId.Id)
            .Include(staff => staff.User)
            .FirstOrDefaultAsync();
        if (staff == null)
        {
            throw new NotFoundException();
        }
        return staff.User.ToDto();
    }
}
