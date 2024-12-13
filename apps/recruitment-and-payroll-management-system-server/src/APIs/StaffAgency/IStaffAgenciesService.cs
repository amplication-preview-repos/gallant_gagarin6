using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IStaffAgenciesService
{
    /// <summary>
    /// Create one StaffAgency
    /// </summary>
    public Task<StaffAgency> CreateStaffAgency(StaffAgencyCreateInput staffagency);

    /// <summary>
    /// Delete one StaffAgency
    /// </summary>
    public Task DeleteStaffAgency(StaffAgencyWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many StaffAgencies
    /// </summary>
    public Task<List<StaffAgency>> StaffAgencies(StaffAgencyFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about StaffAgency records
    /// </summary>
    public Task<MetadataDto> StaffAgenciesMeta(StaffAgencyFindManyArgs findManyArgs);

    /// <summary>
    /// Get one StaffAgency
    /// </summary>
    public Task<StaffAgency> StaffAgency(StaffAgencyWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one StaffAgency
    /// </summary>
    public Task UpdateStaffAgency(
        StaffAgencyWhereUniqueInput uniqueId,
        StaffAgencyUpdateInput updateDto
    );

    /// <summary>
    /// Connect multiple applications records to StaffAgency
    /// </summary>
    public Task ConnectApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Disconnect multiple applications records from StaffAgency
    /// </summary>
    public Task DisconnectApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Find multiple applications records for StaffAgency
    /// </summary>
    public Task<List<Application>> FindApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationFindManyArgs ApplicationFindManyArgs
    );

    /// <summary>
    /// Update multiple applications records for StaffAgency
    /// </summary>
    public Task UpdateApplications(
        StaffAgencyWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Connect multiple employedStaff records to StaffAgency
    /// </summary>
    public Task ConnectEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] usersId
    );

    /// <summary>
    /// Disconnect multiple employedStaff records from StaffAgency
    /// </summary>
    public Task DisconnectEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] usersId
    );

    /// <summary>
    /// Find multiple employedStaff records for StaffAgency
    /// </summary>
    public Task<List<User>> FindEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserFindManyArgs UserFindManyArgs
    );

    /// <summary>
    /// Update multiple employedStaff records for StaffAgency
    /// </summary>
    public Task UpdateEmployedStaff(
        StaffAgencyWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] usersId
    );

    /// <summary>
    /// Connect multiple payrolls records to StaffAgency
    /// </summary>
    public Task ConnectPayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollWhereUniqueInput[] payrollsId
    );

    /// <summary>
    /// Disconnect multiple payrolls records from StaffAgency
    /// </summary>
    public Task DisconnectPayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollWhereUniqueInput[] payrollsId
    );

    /// <summary>
    /// Find multiple payrolls records for StaffAgency
    /// </summary>
    public Task<List<Payroll>> FindPayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollFindManyArgs PayrollFindManyArgs
    );

    /// <summary>
    /// Update multiple payrolls records for StaffAgency
    /// </summary>
    public Task UpdatePayrolls(
        StaffAgencyWhereUniqueInput uniqueId,
        PayrollWhereUniqueInput[] payrollsId
    );

    /// <summary>
    /// Get a user record for StaffAgency
    /// </summary>
    public Task<User> GetUser(StaffAgencyWhereUniqueInput uniqueId);
}
