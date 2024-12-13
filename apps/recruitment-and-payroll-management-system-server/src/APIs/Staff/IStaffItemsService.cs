using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IStaffItemsService
{
    /// <summary>
    /// Create one Staff
    /// </summary>
    public Task<Staff> CreateStaff(StaffCreateInput staff);

    /// <summary>
    /// Delete one Staff
    /// </summary>
    public Task DeleteStaff(StaffWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many StaffItems
    /// </summary>
    public Task<List<Staff>> StaffItems(StaffFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Staff records
    /// </summary>
    public Task<MetadataDto> StaffItemsMeta(StaffFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Staff
    /// </summary>
    public Task<Staff> Staff(StaffWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Staff
    /// </summary>
    public Task UpdateStaff(StaffWhereUniqueInput uniqueId, StaffUpdateInput updateDto);

    /// <summary>
    /// Connect multiple skills records to Staff
    /// </summary>
    public Task ConnectSkills(StaffWhereUniqueInput uniqueId, SkillWhereUniqueInput[] skillsId);

    /// <summary>
    /// Disconnect multiple skills records from Staff
    /// </summary>
    public Task DisconnectSkills(StaffWhereUniqueInput uniqueId, SkillWhereUniqueInput[] skillsId);

    /// <summary>
    /// Find multiple skills records for Staff
    /// </summary>
    public Task<List<Skill>> FindSkills(
        StaffWhereUniqueInput uniqueId,
        SkillFindManyArgs SkillFindManyArgs
    );

    /// <summary>
    /// Update multiple skills records for Staff
    /// </summary>
    public Task UpdateSkills(StaffWhereUniqueInput uniqueId, SkillWhereUniqueInput[] skillsId);

    /// <summary>
    /// Get a user record for Staff
    /// </summary>
    public Task<User> GetUser(StaffWhereUniqueInput uniqueId);
}
