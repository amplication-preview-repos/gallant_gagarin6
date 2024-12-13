using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class ApplicationsService : ApplicationsServiceBase
{
    public ApplicationsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
