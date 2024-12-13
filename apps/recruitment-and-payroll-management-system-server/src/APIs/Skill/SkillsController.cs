using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class SkillsController : SkillsControllerBase
{
    public SkillsController(ISkillsService service)
        : base(service) { }
}
