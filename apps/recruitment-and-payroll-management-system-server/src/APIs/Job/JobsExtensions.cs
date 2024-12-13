using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class JobsExtensions
{
    public static Job ToDto(this JobDbModel model)
    {
        return new Job
        {
            AcceptedBy = model.AcceptedById,
            Applications = model.Applications?.Select(x => x.Id).ToList(),
            Completed = model.Completed,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Duration = model.Duration,
            Id = model.Id,
            IsAcceptedByAgency = model.IsAcceptedByAgency,
            IsPaid = model.IsPaid,
            PayRate = model.PayRate,
            Payments = model.Payments?.Select(x => x.Id).ToList(),
            PostedBy = model.PostedBy,
            Ratings = model.Ratings?.Select(x => x.Id).ToList(),
            RequiredSkills = model.RequiredSkills?.Select(x => x.Id).ToList(),
            Status = model.Status,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static JobDbModel ToModel(this JobUpdateInput updateDto, JobWhereUniqueInput uniqueId)
    {
        var job = new JobDbModel
        {
            Id = uniqueId.Id,
            Completed = updateDto.Completed,
            Description = updateDto.Description,
            Duration = updateDto.Duration,
            IsAcceptedByAgency = updateDto.IsAcceptedByAgency,
            IsPaid = updateDto.IsPaid,
            PostedBy = updateDto.PostedBy,
            Status = updateDto.Status
        };

        if (updateDto.AcceptedBy != null)
        {
            job.AcceptedById = updateDto.AcceptedBy;
        }
        if (updateDto.CreatedAt != null)
        {
            job.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PayRate != null)
        {
            job.PayRate = updateDto.PayRate.Value;
        }
        if (updateDto.Title != null)
        {
            job.Title = updateDto.Title;
        }
        if (updateDto.UpdatedAt != null)
        {
            job.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return job;
    }
}
