using Microsoft.AspNetCore.Mvc;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[ApiController()]
public class TransactionsController : TransactionsControllerBase
{
    public TransactionsController(ITransactionsService service)
        : base(service) { }
}
