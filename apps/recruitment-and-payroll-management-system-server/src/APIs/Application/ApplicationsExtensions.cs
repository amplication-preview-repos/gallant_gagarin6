using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class ApplicationsExtensions
{
    public static Application ToDto(this ApplicationDbModel model)
    {
        return new Application
        {
            Applicant = model.Applicant,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Job = model.JobId,
            StaffAgency = model.StaffAgencyId,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static ApplicationDbModel ToModel(
        this ApplicationUpdateInput updateDto,
        ApplicationWhereUniqueInput uniqueId
    )
    {
        var application = new ApplicationDbModel
        {
            Id = uniqueId.Id,
            Applicant = updateDto.Applicant,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            application.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Job != null)
        {
            application.JobId = updateDto.Job;
        }
        if (updateDto.StaffAgency != null)
        {
            application.StaffAgencyId = updateDto.StaffAgency;
        }
        if (updateDto.UpdatedAt != null)
        {
            application.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            application.UserId = updateDto.User;
        }

        return application;
    }
}
