using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;
using RecruitmentAndPayrollManagementSystem.APIs.Extensions;
using RecruitmentAndPayrollManagementSystem.Infrastructure;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public abstract class RatingsServiceBase : IRatingsService
{
    protected readonly RecruitmentAndPayrollManagementSystemDbContext _context;

    public RatingsServiceBase(RecruitmentAndPayrollManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Rating
    /// </summary>
    public async Task<Rating> CreateRating(RatingCreateInput createDto)
    {
        var rating = new RatingDbModel
        {
            Comment = createDto.Comment,
            CreatedAt = createDto.CreatedAt,
            EntityRated = createDto.EntityRated,
            RatedBy = createDto.RatedBy,
            RatingValue = createDto.RatingValue,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            rating.Id = createDto.Id;
        }
        if (createDto.Job != null)
        {
            rating.Job = await _context
                .Jobs.Where(job => createDto.Job.Id == job.Id)
                .FirstOrDefaultAsync();
        }

        _context.Ratings.Add(rating);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RatingDbModel>(rating.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Rating
    /// </summary>
    public async Task DeleteRating(RatingWhereUniqueInput uniqueId)
    {
        var rating = await _context.Ratings.FindAsync(uniqueId.Id);
        if (rating == null)
        {
            throw new NotFoundException();
        }

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Ratings
    /// </summary>
    public async Task<List<Rating>> Ratings(RatingFindManyArgs findManyArgs)
    {
        var ratings = await _context
            .Ratings.Include(x => x.Job)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return ratings.ConvertAll(rating => rating.ToDto());
    }

    /// <summary>
    /// Meta data about Rating records
    /// </summary>
    public async Task<MetadataDto> RatingsMeta(RatingFindManyArgs findManyArgs)
    {
        var count = await _context.Ratings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Rating
    /// </summary>
    public async Task<Rating> Rating(RatingWhereUniqueInput uniqueId)
    {
        var ratings = await this.Ratings(
            new RatingFindManyArgs { Where = new RatingWhereInput { Id = uniqueId.Id } }
        );
        var rating = ratings.FirstOrDefault();
        if (rating == null)
        {
            throw new NotFoundException();
        }

        return rating;
    }

    /// <summary>
    /// Update one Rating
    /// </summary>
    public async Task UpdateRating(RatingWhereUniqueInput uniqueId, RatingUpdateInput updateDto)
    {
        var rating = updateDto.ToModel(uniqueId);

        if (updateDto.Job != null)
        {
            rating.Job = await _context
                .Jobs.Where(job => updateDto.Job == job.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(rating).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Ratings.Any(e => e.Id == rating.Id))
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
    /// Get a job record for Rating
    /// </summary>
    public async Task<Job> GetJob(RatingWhereUniqueInput uniqueId)
    {
        var rating = await _context
            .Ratings.Where(rating => rating.Id == uniqueId.Id)
            .Include(rating => rating.Job)
            .FirstOrDefaultAsync();
        if (rating == null)
        {
            throw new NotFoundException();
        }
        return rating.Job.ToDto();
    }
}
