using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class StaffAgenciesExtensions
{
    public static StaffAgency ToDto(this StaffAgencyDbModel model)
    {
        return new StaffAgency
        {
            AgencyDetails = model.AgencyDetails,
            AgencyName = model.AgencyName,
            Applications = model.Applications?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            EmployedStaff = model.EmployedStaff?.Select(x => x.Id).ToList(),
            Id = model.Id,
            Payrolls = model.Payrolls?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static StaffAgencyDbModel ToModel(
        this StaffAgencyUpdateInput updateDto,
        StaffAgencyWhereUniqueInput uniqueId
    )
    {
        var staffAgency = new StaffAgencyDbModel
        {
            Id = uniqueId.Id,
            AgencyDetails = updateDto.AgencyDetails
        };

        if (updateDto.AgencyName != null)
        {
            staffAgency.AgencyName = updateDto.AgencyName;
        }
        if (updateDto.CreatedAt != null)
        {
            staffAgency.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            staffAgency.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            staffAgency.UserId = updateDto.User;
        }

        return staffAgency;
    }
}
