using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class StaffItemsExtensions
{
    public static Staff ToDto(this StaffDbModel model)
    {
        return new Staff
        {
            Availability = model.Availability,
            CreatedAt = model.CreatedAt,
            Cv = model.Cv,
            Email = model.Email,
            Id = model.Id,
            Name = model.Name,
            Skills = model.Skills?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
            User = model.User?.ToDto(),
        };
    }

    public static StaffDbModel ToModel(
        this StaffUpdateInput updateDto,
        StaffWhereUniqueInput uniqueId
    )
    {
        var staff = new StaffDbModel
        {
            Id = uniqueId.Id,
            Availability = updateDto.Availability,
            Cv = updateDto.Cv,
            Email = updateDto.Email,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            staff.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            staff.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return staff;
    }
}
