using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
