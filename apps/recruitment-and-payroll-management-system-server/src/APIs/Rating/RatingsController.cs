using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class RatingsController : RatingsControllerBase
{
    public RatingsController(IRatingsService service)
        : base(service) { }
}
