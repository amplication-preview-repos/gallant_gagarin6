using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class SkillsServiceBase : ISkillsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public SkillsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Skill
    /// </summary>
    public async Task<Skill> CreateSkill(SkillCreateInput createDto)
    {
        var skill = new SkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            skill.Id = createDto.Id;
        }
        if (createDto.Job != null)
        {
            skill.Job = await _context
                .Jobs.Where(job => createDto.Job.Id == job.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.StaffItems != null)
        {
            skill.StaffItems = await _context
                .StaffItems.Where(staff => createDto.StaffItems.Id == staff.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.User != null)
        {
            skill.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SkillDbModel>(skill.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Skill
    /// </summary>
    public async Task DeleteSkill(SkillWhereUniqueInput uniqueId)
    {
        var skill = await _context.Skills.FindAsync(uniqueId.Id);
        if (skill == null)
        {
            throw new NotFoundException();
        }

        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Skills
    /// </summary>
    public async Task<List<Skill>> Skills(SkillFindManyArgs findManyArgs)
    {
        var skills = await _context
            .Skills.Include(x => x.StaffItems)
            .Include(x => x.Job)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return skills.ConvertAll(skill => skill.ToDto());
    }

    /// <summary>
    /// Meta data about Skill records
    /// </summary>
    public async Task<MetadataDto> SkillsMeta(SkillFindManyArgs findManyArgs)
    {
        var count = await _context.Skills.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Skill
    /// </summary>
    public async Task<Skill> Skill(SkillWhereUniqueInput uniqueId)
    {
        var skills = await this.Skills(
            new SkillFindManyArgs { Where = new SkillWhereInput { Id = uniqueId.Id } }
        );
        var skill = skills.FirstOrDefault();
        if (skill == null)
        {
            throw new NotFoundException();
        }

        return skill;
    }

    /// <summary>
    /// Update one Skill
    /// </summary>
    public async Task UpdateSkill(SkillWhereUniqueInput uniqueId, SkillUpdateInput updateDto)
    {
        var skill = updateDto.ToModel(uniqueId);

        if (updateDto.Job != null)
        {
            skill.Job = await _context
                .Jobs.Where(job => updateDto.Job == job.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.StaffItems != null)
        {
            skill.StaffItems = await _context
                .StaffItems.Where(staff => updateDto.StaffItems == staff.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.User != null)
        {
            skill.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(skill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Skills.Any(e => e.Id == skill.Id))
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
    /// Get a Job record for Skill
    /// </summary>
    public async Task<Job> GetJob(SkillWhereUniqueInput uniqueId)
    {
        var skill = await _context
            .Skills.Where(skill => skill.Id == uniqueId.Id)
            .Include(skill => skill.Job)
            .FirstOrDefaultAsync();
        if (skill == null)
        {
            throw new NotFoundException();
        }
        return skill.Job.ToDto();
    }

    /// <summary>
    /// Get a StaffItems record for Skill
    /// </summary>
    public async Task<Staff> GetStaffItems(SkillWhereUniqueInput uniqueId)
    {
        var skill = await _context
            .Skills.Where(skill => skill.Id == uniqueId.Id)
            .Include(skill => skill.StaffItems)
            .FirstOrDefaultAsync();
        if (skill == null)
        {
            throw new NotFoundException();
        }
        return skill.StaffItems.ToDto();
    }

    /// <summary>
    /// Get a User record for Skill
    /// </summary>
    public async Task<User> GetUser(SkillWhereUniqueInput uniqueId)
    {
        var skill = await _context
            .Skills.Where(skill => skill.Id == uniqueId.Id)
            .Include(skill => skill.User)
            .FirstOrDefaultAsync();
        if (skill == null)
        {
            throw new NotFoundException();
        }
        return skill.User.ToDto();
    }
}
