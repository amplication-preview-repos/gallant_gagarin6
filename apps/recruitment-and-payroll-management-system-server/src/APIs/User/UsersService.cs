using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
