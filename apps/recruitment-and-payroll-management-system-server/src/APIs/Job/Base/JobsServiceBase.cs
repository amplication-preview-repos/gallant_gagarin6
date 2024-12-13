using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class JobsServiceBase : IJobsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public JobsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Job
    /// </summary>
    public async Task<Job> CreateJob(JobCreateInput createDto)
    {
        var job = new JobDbModel
        {
            Completed = createDto.Completed,
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Duration = createDto.Duration,
            IsAcceptedByAgency = createDto.IsAcceptedByAgency,
            IsPaid = createDto.IsPaid,
            PayRate = createDto.PayRate,
            PostedBy = createDto.PostedBy,
            Status = createDto.Status,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            job.Id = createDto.Id;
        }
        if (createDto.AcceptedBy != null)
        {
            job.AcceptedBy = await _context
                .Users.Where(user => createDto.AcceptedBy.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Applications != null)
        {
            job.Applications = await _context
                .Applications.Where(application =>
                    createDto.Applications.Select(t => t.Id).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (createDto.Payments != null)
        {
            job.Payments = await _context
                .Payments.Where(payment =>
                    createDto.Payments.Select(t => t.Id).Contains(payment.Id)
                )
                .ToListAsync();
        }

        if (createDto.Ratings != null)
        {
            job.Ratings = await _context
                .Ratings.Where(rating => createDto.Ratings.Select(t => t.Id).Contains(rating.Id))
                .ToListAsync();
        }

        if (createDto.RequiredSkills != null)
        {
            job.RequiredSkills = await _context
                .Skills.Where(skill =>
                    createDto.RequiredSkills.Select(t => t.Id).Contains(skill.Id)
                )
                .ToListAsync();
        }

        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<JobDbModel>(job.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Job
    /// </summary>
    public async Task DeleteJob(JobWhereUniqueInput uniqueId)
    {
        var job = await _context.Jobs.FindAsync(uniqueId.Id);
        if (job == null)
        {
            throw new NotFoundException();
        }

        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Jobs
    /// </summary>
    public async Task<List<Job>> Jobs(JobFindManyArgs findManyArgs)
    {
        var jobs = await _context
            .Jobs.Include(x => x.Payments)
            .Include(x => x.AcceptedBy)
            .Include(x => x.Applications)
            .Include(x => x.Ratings)
            .Include(x => x.RequiredSkills)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return jobs.ConvertAll(job => job.ToDto());
    }

    /// <summary>
    /// Meta data about Job records
    /// </summary>
    public async Task<MetadataDto> JobsMeta(JobFindManyArgs findManyArgs)
    {
        var count = await _context.Jobs.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Job
    /// </summary>
    public async Task<Job> Job(JobWhereUniqueInput uniqueId)
    {
        var jobs = await this.Jobs(
            new JobFindManyArgs { Where = new JobWhereInput { Id = uniqueId.Id } }
        );
        var job = jobs.FirstOrDefault();
        if (job == null)
        {
            throw new NotFoundException();
        }

        return job;
    }

    /// <summary>
    /// Update one Job
    /// </summary>
    public async Task UpdateJob(JobWhereUniqueInput uniqueId, JobUpdateInput updateDto)
    {
        var job = updateDto.ToModel(uniqueId);

        if (updateDto.AcceptedBy != null)
        {
            job.AcceptedBy = await _context
                .Users.Where(user => updateDto.AcceptedBy == user.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Applications != null)
        {
            job.Applications = await _context
                .Applications.Where(application =>
                    updateDto.Applications.Select(t => t).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Payments != null)
        {
            job.Payments = await _context
                .Payments.Where(payment => updateDto.Payments.Select(t => t).Contains(payment.Id))
                .ToListAsync();
        }

        if (updateDto.Ratings != null)
        {
            job.Ratings = await _context
                .Ratings.Where(rating => updateDto.Ratings.Select(t => t).Contains(rating.Id))
                .ToListAsync();
        }

        if (updateDto.RequiredSkills != null)
        {
            job.RequiredSkills = await _context
                .Skills.Where(skill => updateDto.RequiredSkills.Select(t => t).Contains(skill.Id))
                .ToListAsync();
        }

        _context.Entry(job).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Jobs.Any(e => e.Id == job.Id))
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
    /// Get a assignedTo record for Job
    /// </summary>
    public async Task<User> GetAcceptedBy(JobWhereUniqueInput uniqueId)
    {
        var job = await _context
            .Jobs.Where(job => job.Id == uniqueId.Id)
            .Include(job => job.AcceptedBy)
            .FirstOrDefaultAsync();
        if (job == null)
        {
            throw new NotFoundException();
        }
        return job.AcceptedBy.ToDto();
    }

    /// <summary>
    /// Connect multiple applications records to Job
    /// </summary>
    public async Task ConnectApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Jobs.Include(x => x.Applications)
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
    /// Disconnect multiple applications records from Job
    /// </summary>
    public async Task DisconnectApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Jobs.Include(x => x.Applications)
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
    /// Find multiple applications records for Job
    /// </summary>
    public async Task<List<Application>> FindApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationFindManyArgs jobFindManyArgs
    )
    {
        var applications = await _context
            .Applications.Where(m => m.JobId == uniqueId.Id)
            .ApplyWhere(jobFindManyArgs.Where)
            .ApplySkip(jobFindManyArgs.Skip)
            .ApplyTake(jobFindManyArgs.Take)
            .ApplyOrderBy(jobFindManyArgs.SortBy)
            .ToListAsync();

        return applications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple applications records for Job
    /// </summary>
    public async Task UpdateApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var job = await _context
            .Jobs.Include(t => t.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (job == null)
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

        job.Applications = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple payments records to Job
    /// </summary>
    public async Task ConnectPayments(
        JobWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Jobs.Include(x => x.Payments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Payments.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Payments);

        foreach (var child in childrenToConnect)
        {
            parent.Payments.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple payments records from Job
    /// </summary>
    public async Task DisconnectPayments(
        JobWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Jobs.Include(x => x.Payments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Payments.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Payments?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple payments records for Job
    /// </summary>
    public async Task<List<Payment>> FindPayments(
        JobWhereUniqueInput uniqueId,
        PaymentFindManyArgs jobFindManyArgs
    )
    {
        var payments = await _context
            .Payments.Where(m => m.JobId == uniqueId.Id)
            .ApplyWhere(jobFindManyArgs.Where)
            .ApplySkip(jobFindManyArgs.Skip)
            .ApplyTake(jobFindManyArgs.Take)
            .ApplyOrderBy(jobFindManyArgs.SortBy)
            .ToListAsync();

        return payments.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple payments records for Job
    /// </summary>
    public async Task UpdatePayments(
        JobWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] childrenIds
    )
    {
        var job = await _context
            .Jobs.Include(t => t.Payments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (job == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Payments.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        job.Payments = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple ratings records to Job
    /// </summary>
    public async Task ConnectRatings(
        JobWhereUniqueInput uniqueId,
        RatingWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Jobs.Include(x => x.Ratings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Ratings.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Ratings);

        foreach (var child in childrenToConnect)
        {
            parent.Ratings.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ratings records from Job
    /// </summary>
    public async Task DisconnectRatings(
        JobWhereUniqueInput uniqueId,
        RatingWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Jobs.Include(x => x.Ratings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Ratings.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Ratings?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ratings records for Job
    /// </summary>
    public async Task<List<Rating>> FindRatings(
        JobWhereUniqueInput uniqueId,
        RatingFindManyArgs jobFindManyArgs
    )
    {
        var ratings = await _context
            .Ratings.Where(m => m.JobId == uniqueId.Id)
            .ApplyWhere(jobFindManyArgs.Where)
            .ApplySkip(jobFindManyArgs.Skip)
            .ApplyTake(jobFindManyArgs.Take)
            .ApplyOrderBy(jobFindManyArgs.SortBy)
            .ToListAsync();

        return ratings.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ratings records for Job
    /// </summary>
    public async Task UpdateRatings(
        JobWhereUniqueInput uniqueId,
        RatingWhereUniqueInput[] childrenIds
    )
    {
        var job = await _context
            .Jobs.Include(t => t.Ratings)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (job == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Ratings.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        job.Ratings = children;
        await _context.SaveChangesAsync();
    }
}
