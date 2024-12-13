using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ApplicationsControllerBase : ControllerBase
{
    protected readonly IApplicationsService _service;

    public ApplicationsControllerBase(IApplicationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Application
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Application>> CreateApplication(ApplicationCreateInput input)
    {
        var application = await _service.CreateApplication(input);

        return CreatedAtAction(nameof(Application), new { id = application.Id }, application);
    }

    /// <summary>
    /// Delete one Application
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteApplication(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteApplication(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Applications
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Application>>> Applications(
        [FromQuery()] ApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.Applications(filter));
    }

    /// <summary>
    /// Meta data about Application records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ApplicationsMeta(
        [FromQuery()] ApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.ApplicationsMeta(filter));
    }

    /// <summary>
    /// Get one Application
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Application>> Application(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Application(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Application
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateApplication(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId,
        [FromQuery()] ApplicationUpdateInput applicationUpdateDto
    )
    {
        try
        {
            await _service.UpdateApplication(uniqueId, applicationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a job record for Application
    /// </summary>
    [HttpGet("{Id}/job")]
    public async Task<ActionResult<List<Job>>> GetJob(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        var job = await _service.GetJob(uniqueId);
        return Ok(job);
    }

    /// <summary>
    /// Get a staffAgency record for Application
    /// </summary>
    [HttpGet("{Id}/staffAgency")]
    public async Task<ActionResult<List<StaffAgency>>> GetStaffAgency(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        var staffAgency = await _service.GetStaffAgency(uniqueId);
        return Ok(staffAgency);
    }

    /// <summary>
    /// Get a user record for Application
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
