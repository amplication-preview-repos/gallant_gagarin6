using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class StaffItemsController : StaffItemsControllerBase
{
    public StaffItemsController(IStaffItemsService service)
        : base(service) { }
}
