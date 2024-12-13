using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class WalletsService : WalletsServiceBase
{
    public WalletsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
