using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class StaffAgenciesController : StaffAgenciesControllerBase
{
    public StaffAgenciesController(IStaffAgenciesService service)
        : base(service) { }
}
