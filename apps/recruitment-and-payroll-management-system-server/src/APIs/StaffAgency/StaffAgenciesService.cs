using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class StaffAgenciesService : StaffAgenciesServiceBase
{
    public StaffAgenciesService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
