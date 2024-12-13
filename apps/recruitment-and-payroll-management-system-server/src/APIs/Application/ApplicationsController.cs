using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class ApplicationsController : ApplicationsControllerBase
{
    public ApplicationsController(IApplicationsService service)
        : base(service) { }
}
