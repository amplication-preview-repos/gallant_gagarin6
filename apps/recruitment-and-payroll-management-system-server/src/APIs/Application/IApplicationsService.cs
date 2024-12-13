using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IApplicationsService
{
    /// <summary>
    /// Create one Application
    /// </summary>
    public Task<Application> CreateApplication(ApplicationCreateInput application);

    /// <summary>
    /// Delete one Application
    /// </summary>
    public Task DeleteApplication(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Applications
    /// </summary>
    public Task<List<Application>> Applications(ApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Application records
    /// </summary>
    public Task<MetadataDto> ApplicationsMeta(ApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Application
    /// </summary>
    public Task<Application> Application(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Application
    /// </summary>
    public Task UpdateApplication(
        ApplicationWhereUniqueInput uniqueId,
        ApplicationUpdateInput updateDto
    );

    /// <summary>
    /// Get a job record for Application
    /// </summary>
    public Task<Job> GetJob(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a staffAgency record for Application
    /// </summary>
    public Task<StaffAgency> GetStaffAgency(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a user record for Application
    /// </summary>
    public Task<User> GetUser(ApplicationWhereUniqueInput uniqueId);
}
