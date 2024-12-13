using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class PayrollsController : PayrollsControllerBase
{
    public PayrollsController(IPayrollsService service)
        : base(service) { }
}
