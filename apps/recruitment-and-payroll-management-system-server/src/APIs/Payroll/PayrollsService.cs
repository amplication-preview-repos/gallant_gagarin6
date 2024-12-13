using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class PayrollsService : PayrollsServiceBase
{
    public PayrollsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
