using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class ApplicationsServiceBase : IApplicationsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public ApplicationsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Application
    /// </summary>
    public async Task<Application> CreateApplication(ApplicationCreateInput createDto)
    {
        var application = new ApplicationDbModel
        {
            Applicant = createDto.Applicant,
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            application.Id = createDto.Id;
        }
        if (createDto.Job != null)
        {
            application.Job = await _context
                .Jobs.Where(job => createDto.Job.Id == job.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.StaffAgency != null)
        {
            application.StaffAgency = await _context
                .StaffAgencies.Where(staffAgency => createDto.StaffAgency.Id == staffAgency.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.User != null)
        {
            application.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Applications.Add(application);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ApplicationDbModel>(application.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Application
    /// </summary>
    public async Task DeleteApplication(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context.Applications.FindAsync(uniqueId.Id);
        if (application == null)
        {
            throw new NotFoundException();
        }

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Applications
    /// </summary>
    public async Task<List<Application>> Applications(ApplicationFindManyArgs findManyArgs)
    {
        var applications = await _context
            .Applications.Include(x => x.Job)
            .Include(x => x.User)
            .Include(x => x.StaffAgency)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return applications.ConvertAll(application => application.ToDto());
    }

    /// <summary>
    /// Meta data about Application records
    /// </summary>
    public async Task<MetadataDto> ApplicationsMeta(ApplicationFindManyArgs findManyArgs)
    {
        var count = await _context.Applications.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Application
    /// </summary>
    public async Task<Application> Application(ApplicationWhereUniqueInput uniqueId)
    {
        var applications = await this.Applications(
            new ApplicationFindManyArgs { Where = new ApplicationWhereInput { Id = uniqueId.Id } }
        );
        var application = applications.FirstOrDefault();
        if (application == null)
        {
            throw new NotFoundException();
        }

        return application;
    }

    /// <summary>
    /// Update one Application
    /// </summary>
    public async Task UpdateApplication(
        ApplicationWhereUniqueInput uniqueId,
        ApplicationUpdateInput updateDto
    )
    {
        var application = updateDto.ToModel(uniqueId);

        if (updateDto.Job != null)
        {
            application.Job = await _context
                .Jobs.Where(job => updateDto.Job == job.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.StaffAgency != null)
        {
            application.StaffAgency = await _context
                .StaffAgencies.Where(staffAgency => updateDto.StaffAgency == staffAgency.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.User != null)
        {
            application.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(application).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Applications.Any(e => e.Id == application.Id))
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
    /// Get a job record for Application
    /// </summary>
    public async Task<Job> GetJob(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context
            .Applications.Where(application => application.Id == uniqueId.Id)
            .Include(application => application.Job)
            .FirstOrDefaultAsync();
        if (application == null)
        {
            throw new NotFoundException();
        }
        return application.Job.ToDto();
    }

    /// <summary>
    /// Get a staffAgency record for Application
    /// </summary>
    public async Task<StaffAgency> GetStaffAgency(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context
            .Applications.Where(application => application.Id == uniqueId.Id)
            .Include(application => application.StaffAgency)
            .FirstOrDefaultAsync();
        if (application == null)
        {
            throw new NotFoundException();
        }
        return application.StaffAgency.ToDto();
    }

    /// <summary>
    /// Get a user record for Application
    /// </summary>
    public async Task<User> GetUser(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context
            .Applications.Where(application => application.Id == uniqueId.Id)
            .Include(application => application.User)
            .FirstOrDefaultAsync();
        if (application == null)
        {
            throw new NotFoundException();
        }
        return application.User.ToDto();
    }
}
