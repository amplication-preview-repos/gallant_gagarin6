using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class RatingsService : RatingsServiceBase
{
    public RatingsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
