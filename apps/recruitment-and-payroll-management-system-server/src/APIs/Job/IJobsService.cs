using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IJobsService
{
    /// <summary>
    /// Create one Job
    /// </summary>
    public Task<Job> CreateJob(JobCreateInput job);

    /// <summary>
    /// Delete one Job
    /// </summary>
    public Task DeleteJob(JobWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Jobs
    /// </summary>
    public Task<List<Job>> Jobs(JobFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Job records
    /// </summary>
    public Task<MetadataDto> JobsMeta(JobFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Job
    /// </summary>
    public Task<Job> Job(JobWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Job
    /// </summary>
    public Task UpdateJob(JobWhereUniqueInput uniqueId, JobUpdateInput updateDto);

    /// <summary>
    /// Get a assignedTo record for Job
    /// </summary>
    public Task<User> GetAcceptedBy(JobWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple applications records to Job
    /// </summary>
    public Task ConnectApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Disconnect multiple applications records from Job
    /// </summary>
    public Task DisconnectApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Find multiple applications records for Job
    /// </summary>
    public Task<List<Application>> FindApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationFindManyArgs ApplicationFindManyArgs
    );

    /// <summary>
    /// Update multiple applications records for Job
    /// </summary>
    public Task UpdateApplications(
        JobWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Connect multiple payments records to Job
    /// </summary>
    public Task ConnectPayments(JobWhereUniqueInput uniqueId, PaymentWhereUniqueInput[] paymentsId);

    /// <summary>
    /// Disconnect multiple payments records from Job
    /// </summary>
    public Task DisconnectPayments(
        JobWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Find multiple payments records for Job
    /// </summary>
    public Task<List<Payment>> FindPayments(
        JobWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple payments records for Job
    /// </summary>
    public Task UpdatePayments(JobWhereUniqueInput uniqueId, PaymentWhereUniqueInput[] paymentsId);

    /// <summary>
    /// Connect multiple ratings records to Job
    /// </summary>
    public Task ConnectRatings(JobWhereUniqueInput uniqueId, RatingWhereUniqueInput[] ratingsId);

    /// <summary>
    /// Disconnect multiple ratings records from Job
    /// </summary>
    public Task DisconnectRatings(JobWhereUniqueInput uniqueId, RatingWhereUniqueInput[] ratingsId);

    /// <summary>
    /// Find multiple ratings records for Job
    /// </summary>
    public Task<List<Rating>> FindRatings(
        JobWhereUniqueInput uniqueId,
        RatingFindManyArgs RatingFindManyArgs
    );

    /// <summary>
    /// Update multiple ratings records for Job
    /// </summary>
    public Task UpdateRatings(JobWhereUniqueInput uniqueId, RatingWhereUniqueInput[] ratingsId);
}
