using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            Applications = model.Applications?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            FirstName = model.FirstName,
            Id = model.Id,
            Jobs = model.Jobs?.Select(x => x.Id).ToList(),
            LastName = model.LastName,
            Name = model.Name,
            Password = model.Password,
            Role = model.Role,
            Roles = model.Roles,
            Skills = model.Skills?.Select(x => x.Id).ToList(),
            StaffAgencies = model.StaffAgencies?.Select(x => x.Id).ToList(),
            StaffAgency = model.StaffAgencyId,
            StaffData = model.StaffDataId,
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
            Wallets = model.WalletsId,
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Name = updateDto.Name,
            Role = updateDto.Role
        };

        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.StaffAgency != null)
        {
            user.StaffAgencyId = updateDto.StaffAgency;
        }
        if (updateDto.StaffData != null)
        {
            user.StaffDataId = updateDto.StaffData;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }
        if (updateDto.Wallets != null)
        {
            user.WalletsId = updateDto.Wallets;
        }

        return user;
    }
}
