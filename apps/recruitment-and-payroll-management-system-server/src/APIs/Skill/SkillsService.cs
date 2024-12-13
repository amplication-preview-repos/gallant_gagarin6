using RecruitmentAndPayrollManagementSystem.Infrastructure;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public class SkillsService : SkillsServiceBase
{
    public SkillsService(RecruitmentAndPayrollManagementSystemDbContext context)
        : base(context) { }
}
