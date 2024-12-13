using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class JobsService : JobsServiceBase
{
    public JobsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
