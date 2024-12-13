using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class StaffAgenciesControllerBase : ControllerBase
{
    protected readonly IStaffAgenciesService _service;

    public StaffAgenciesControllerBase(IStaffAgenciesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one StaffAgency
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<StaffAgency>> CreateStaffAgency(StaffAgencyCreateInput input)
    {
        var staffAgency = await _service.CreateStaffAgency(input);

        return CreatedAtAction(nameof(StaffAgency), new { id = staffAgency.Id }, staffAgency);
    }

    /// <summary>
    /// Delete one StaffAgency
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteStaffAgency(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteStaffAgency(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many StaffAgencies
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<StaffAgency>>> StaffAgencies(
        [FromQuery()] StaffAgencyFindManyArgs filter
    )
    {
        return Ok(await _service.StaffAgencies(filter));
    }

    /// <summary>
    /// Meta data about StaffAgency records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> StaffAgenciesMeta(
        [FromQuery()] StaffAgencyFindManyArgs filter
    )
    {
        return Ok(await _service.StaffAgenciesMeta(filter));
    }

    /// <summary>
    /// Get one StaffAgency
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<StaffAgency>> StaffAgency(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.StaffAgency(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one StaffAgency
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateStaffAgency(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] StaffAgencyUpdateInput staffAgencyUpdateDto
    )
    {
        try
        {
            await _service.UpdateStaffAgency(uniqueId, staffAgencyUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple applications records to StaffAgency
    /// </summary>
    [HttpPost("{Id}/applications")]
    public async Task<ActionResult> ConnectApplications(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] ApplicationWhereUniqueInput[] applicationsId
    )
    {
        try
        {
            await _service.ConnectApplications(uniqueId, applicationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple applications records from StaffAgency
    /// </summary>
    [HttpDelete("{Id}/applications")]
    public async Task<ActionResult> DisconnectApplications(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromBody()] ApplicationWhereUniqueInput[] applicationsId
    )
    {
        try
        {
            await _service.DisconnectApplications(uniqueId, applicationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple applications records for StaffAgency
    /// </summary>
    [HttpGet("{Id}/applications")]
    public async Task<ActionResult<List<Application>>> FindApplications(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] ApplicationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindApplications(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple applications records for StaffAgency
    /// </summary>
    [HttpPatch("{Id}/applications")]
    public async Task<ActionResult> UpdateApplications(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromBody()] ApplicationWhereUniqueInput[] applicationsId
    )
    {
        try
        {
            await _service.UpdateApplications(uniqueId, applicationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple employedStaff records to StaffAgency
    /// </summary>
    [HttpPost("{Id}/employedStaff")]
    public async Task<ActionResult> ConnectEmployedStaff(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.ConnectEmployedStaff(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple employedStaff records from StaffAgency
    /// </summary>
    [HttpDelete("{Id}/employedStaff")]
    public async Task<ActionResult> DisconnectEmployedStaff(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.DisconnectEmployedStaff(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple employedStaff records for StaffAgency
    /// </summary>
    [HttpGet("{Id}/employedStaff")]
    public async Task<ActionResult<List<User>>> FindEmployedStaff(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] UserFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEmployedStaff(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple employedStaff records for StaffAgency
    /// </summary>
    [HttpPatch("{Id}/employedStaff")]
    public async Task<ActionResult> UpdateEmployedStaff(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.UpdateEmployedStaff(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple payrolls records to StaffAgency
    /// </summary>
    [HttpPost("{Id}/payrolls")]
    public async Task<ActionResult> ConnectPayrolls(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] PayrollWhereUniqueInput[] payrollsId
    )
    {
        try
        {
            await _service.ConnectPayrolls(uniqueId, payrollsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple payrolls records from StaffAgency
    /// </summary>
    [HttpDelete("{Id}/payrolls")]
    public async Task<ActionResult> DisconnectPayrolls(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromBody()] PayrollWhereUniqueInput[] payrollsId
    )
    {
        try
        {
            await _service.DisconnectPayrolls(uniqueId, payrollsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple payrolls records for StaffAgency
    /// </summary>
    [HttpGet("{Id}/payrolls")]
    public async Task<ActionResult<List<Payroll>>> FindPayrolls(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromQuery()] PayrollFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayrolls(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple payrolls records for StaffAgency
    /// </summary>
    [HttpPatch("{Id}/payrolls")]
    public async Task<ActionResult> UpdatePayrolls(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId,
        [FromBody()] PayrollWhereUniqueInput[] payrollsId
    )
    {
        try
        {
            await _service.UpdatePayrolls(uniqueId, payrollsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user record for StaffAgency
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] StaffAgencyWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
