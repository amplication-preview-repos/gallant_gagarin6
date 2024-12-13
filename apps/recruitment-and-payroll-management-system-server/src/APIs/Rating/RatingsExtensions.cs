using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class RatingsExtensions
{
    public static Rating ToDto(this RatingDbModel model)
    {
        return new Rating
        {
            Comment = model.Comment,
            CreatedAt = model.CreatedAt,
            EntityRated = model.EntityRated,
            Id = model.Id,
            Job = model.JobId,
            RatedBy = model.RatedBy,
            RatingValue = model.RatingValue,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RatingDbModel ToModel(
        this RatingUpdateInput updateDto,
        RatingWhereUniqueInput uniqueId
    )
    {
        var rating = new RatingDbModel
        {
            Id = uniqueId.Id,
            Comment = updateDto.Comment,
            EntityRated = updateDto.EntityRated,
            RatedBy = updateDto.RatedBy,
            RatingValue = updateDto.RatingValue
        };

        if (updateDto.CreatedAt != null)
        {
            rating.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Job != null)
        {
            rating.JobId = updateDto.Job;
        }
        if (updateDto.UpdatedAt != null)
        {
            rating.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return rating;
    }
}
