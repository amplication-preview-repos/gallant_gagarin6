using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple applications records to User
    /// </summary>
    public Task ConnectApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Disconnect multiple applications records from User
    /// </summary>
    public Task DisconnectApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Find multiple applications records for User
    /// </summary>
    public Task<List<Application>> FindApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationFindManyArgs ApplicationFindManyArgs
    );

    /// <summary>
    /// Update multiple applications records for User
    /// </summary>
    public Task UpdateApplications(
        UserWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Connect multiple Jobs records to User
    /// </summary>
    public Task ConnectJobs(UserWhereUniqueInput uniqueId, JobWhereUniqueInput[] jobsId);

    /// <summary>
    /// Disconnect multiple Jobs records from User
    /// </summary>
    public Task DisconnectJobs(UserWhereUniqueInput uniqueId, JobWhereUniqueInput[] jobsId);

    /// <summary>
    /// Find multiple Jobs records for User
    /// </summary>
    public Task<List<Job>> FindJobs(UserWhereUniqueInput uniqueId, JobFindManyArgs JobFindManyArgs);

    /// <summary>
    /// Update multiple Jobs records for User
    /// </summary>
    public Task UpdateJobs(UserWhereUniqueInput uniqueId, JobWhereUniqueInput[] jobsId);

    /// <summary>
    /// Connect multiple skills records to User
    /// </summary>
    public Task ConnectSkills(UserWhereUniqueInput uniqueId, SkillWhereUniqueInput[] skillsId);

    /// <summary>
    /// Disconnect multiple skills records from User
    /// </summary>
    public Task DisconnectSkills(UserWhereUniqueInput uniqueId, SkillWhereUniqueInput[] skillsId);

    /// <summary>
    /// Find multiple skills records for User
    /// </summary>
    public Task<List<Skill>> FindSkills(
        UserWhereUniqueInput uniqueId,
        SkillFindManyArgs SkillFindManyArgs
    );

    /// <summary>
    /// Update multiple skills records for User
    /// </summary>
    public Task UpdateSkills(UserWhereUniqueInput uniqueId, SkillWhereUniqueInput[] skillsId);

    /// <summary>
    /// Connect multiple staffAgencies records to User
    /// </summary>
    public Task ConnectStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyWhereUniqueInput[] staffAgenciesId
    );

    /// <summary>
    /// Disconnect multiple staffAgencies records from User
    /// </summary>
    public Task DisconnectStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyWhereUniqueInput[] staffAgenciesId
    );

    /// <summary>
    /// Find multiple staffAgencies records for User
    /// </summary>
    public Task<List<StaffAgency>> FindStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyFindManyArgs StaffAgencyFindManyArgs
    );

    /// <summary>
    /// Update multiple staffAgencies records for User
    /// </summary>
    public Task UpdateStaffAgencies(
        UserWhereUniqueInput uniqueId,
        StaffAgencyWhereUniqueInput[] staffAgenciesId
    );

    /// <summary>
    /// Get a staffAgency record for User
    /// </summary>
    public Task<StaffAgency> GetStaffAgency(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a staffData record for User
    /// </summary>
    public Task<Staff> GetStaffData(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a wallet record for User
    /// </summary>
    public Task<Wallet> GetWallets(UserWhereUniqueInput uniqueId);
}
