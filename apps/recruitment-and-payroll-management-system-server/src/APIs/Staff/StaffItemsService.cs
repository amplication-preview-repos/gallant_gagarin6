using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class StaffItemsService : StaffItemsServiceBase
{
    public StaffItemsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
