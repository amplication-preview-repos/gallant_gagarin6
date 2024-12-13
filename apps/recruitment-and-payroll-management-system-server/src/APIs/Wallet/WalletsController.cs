using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class WalletsController : WalletsControllerBase
{
    public WalletsController(IWalletsService service)
        : base(service) { }
}
