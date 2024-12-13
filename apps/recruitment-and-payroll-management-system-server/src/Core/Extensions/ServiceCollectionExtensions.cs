using RecruitmentAndPayrollManagementSystem.APIs;

namespace RecruitmentAndPayrollManagementSystem;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationsService, ApplicationsService>();
        services.AddScoped<IJobsService, JobsService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
        services.AddScoped<IPayrollsService, PayrollsService>();
        services.AddScoped<IRatingsService, RatingsService>();
        services.AddScoped<ISkillsService, SkillsService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IStaffAgenciesService, StaffAgenciesService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IWalletsService, WalletsService>();
    }
}
