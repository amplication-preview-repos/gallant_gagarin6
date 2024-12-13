using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class PaymentsController : PaymentsControllerBase
{
    public PaymentsController(IPaymentsService service)
        : base(service) { }
}
