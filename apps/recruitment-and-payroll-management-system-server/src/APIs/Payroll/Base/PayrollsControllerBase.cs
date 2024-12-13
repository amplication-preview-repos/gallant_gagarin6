using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PayrollsControllerBase : ControllerBase
{
    protected readonly IPayrollsService _service;

    public PayrollsControllerBase(IPayrollsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Payroll
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Payroll>> CreatePayroll(PayrollCreateInput input)
    {
        var payroll = await _service.CreatePayroll(input);

        return CreatedAtAction(nameof(Payroll), new { id = payroll.Id }, payroll);
    }

    /// <summary>
    /// Delete one Payroll
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePayroll([FromRoute()] PayrollWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePayroll(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Payrolls
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Payroll>>> Payrolls(
        [FromQuery()] PayrollFindManyArgs filter
    )
    {
        return Ok(await _service.Payrolls(filter));
    }

    /// <summary>
    /// Meta data about Payroll records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PayrollsMeta(
        [FromQuery()] PayrollFindManyArgs filter
    )
    {
        return Ok(await _service.PayrollsMeta(filter));
    }

    /// <summary>
    /// Get one Payroll
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Payroll>> Payroll([FromRoute()] PayrollWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Payroll(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Payroll
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePayroll(
        [FromRoute()] PayrollWhereUniqueInput uniqueId,
        [FromQuery()] PayrollUpdateInput payrollUpdateDto
    )
    {
        try
        {
            await _service.UpdatePayroll(uniqueId, payrollUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
