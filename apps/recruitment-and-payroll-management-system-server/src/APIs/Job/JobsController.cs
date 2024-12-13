using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class JobsController : JobsControllerBase
{
    public JobsController(IJobsService service)
        : base(service) { }
}
