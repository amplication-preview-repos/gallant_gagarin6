using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Extensions;

public static class SkillsExtensions
{
    public static Skill ToDto(this SkillDbModel model)
    {
        return new Skill
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Job = model.JobId,
            Name = model.Name,
            StaffItems = model.StaffItemsId,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static SkillDbModel ToModel(
        this SkillUpdateInput updateDto,
        SkillWhereUniqueInput uniqueId
    )
    {
        var skill = new SkillDbModel { Id = uniqueId.Id, Description = updateDto.Description };

        if (updateDto.CreatedAt != null)
        {
            skill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Job != null)
        {
            skill.JobId = updateDto.Job;
        }
        if (updateDto.Name != null)
        {
            skill.Name = updateDto.Name;
        }
        if (updateDto.StaffItems != null)
        {
            skill.StaffItemsId = updateDto.StaffItems;
        }
        if (updateDto.UpdatedAt != null)
        {
            skill.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            skill.UserId = updateDto.User;
        }

        return skill;
    }
}
