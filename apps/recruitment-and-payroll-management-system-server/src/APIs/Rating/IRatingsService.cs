using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IRatingsService
{
    /// <summary>
    /// Create one Rating
    /// </summary>
    public Task<Rating> CreateRating(RatingCreateInput rating);

    /// <summary>
    /// Delete one Rating
    /// </summary>
    public Task DeleteRating(RatingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Ratings
    /// </summary>
    public Task<List<Rating>> Ratings(RatingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Rating records
    /// </summary>
    public Task<MetadataDto> RatingsMeta(RatingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Rating
    /// </summary>
    public Task<Rating> Rating(RatingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Rating
    /// </summary>
    public Task UpdateRating(RatingWhereUniqueInput uniqueId, RatingUpdateInput updateDto);

    /// <summary>
    /// Get a job record for Rating
    /// </summary>
    public Task<Job> GetJob(RatingWhereUniqueInput uniqueId);
}
