using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
