using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class JobsControllerBase : ControllerBase
{
    protected readonly IJobsService _service;

    public JobsControllerBase(IJobsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Job
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Job>> CreateJob(JobCreateInput input)
    {
        var job = await _service.CreateJob(input);

        return CreatedAtAction(nameof(Job), new { id = job.Id }, job);
    }

    /// <summary>
    /// Delete one Job
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteJob([FromRoute()] JobWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteJob(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Jobs
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Job>>> Jobs([FromQuery()] JobFindManyArgs filter)
    {
        return Ok(await _service.Jobs(filter));
    }

    /// <summary>
    /// Meta data about Job records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> JobsMeta([FromQuery()] JobFindManyArgs filter)
    {
        return Ok(await _service.JobsMeta(filter));
    }

    /// <summary>
    /// Get one Job
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Job>> Job([FromRoute()] JobWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Job(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Job
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateJob(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromQuery()] JobUpdateInput jobUpdateDto
    )
    {
        try
        {
            await _service.UpdateJob(uniqueId, jobUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a assignedTo record for Job
    /// </summary>
    [HttpGet("{Id}/acceptedBy")]
    public async Task<ActionResult<List<User>>> GetAcceptedBy(
        [FromRoute()] JobWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetAcceptedBy(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Connect multiple applications records to Job
    /// </summary>
    [HttpPost("{Id}/applications")]
    public async Task<ActionResult> ConnectApplications(
        [FromRoute()] JobWhereUniqueInput uniqueId,
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
    /// Disconnect multiple applications records from Job
    /// </summary>
    [HttpDelete("{Id}/applications")]
    public async Task<ActionResult> DisconnectApplications(
        [FromRoute()] JobWhereUniqueInput uniqueId,
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
    /// Find multiple applications records for Job
    /// </summary>
    [HttpGet("{Id}/applications")]
    public async Task<ActionResult<List<Application>>> FindApplications(
        [FromRoute()] JobWhereUniqueInput uniqueId,
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
    /// Update multiple applications records for Job
    /// </summary>
    [HttpPatch("{Id}/applications")]
    public async Task<ActionResult> UpdateApplications(
        [FromRoute()] JobWhereUniqueInput uniqueId,
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
    /// Connect multiple payments records to Job
    /// </summary>
    [HttpPost("{Id}/payments")]
    public async Task<ActionResult> ConnectPayments(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromQuery()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.ConnectPayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple payments records from Job
    /// </summary>
    [HttpDelete("{Id}/payments")]
    public async Task<ActionResult> DisconnectPayments(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.DisconnectPayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple payments records for Job
    /// </summary>
    [HttpGet("{Id}/payments")]
    public async Task<ActionResult<List<Payment>>> FindPayments(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromQuery()] PaymentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayments(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple payments records for Job
    /// </summary>
    [HttpPatch("{Id}/payments")]
    public async Task<ActionResult> UpdatePayments(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromBody()] PaymentWhereUniqueInput[] paymentsId
    )
    {
        try
        {
            await _service.UpdatePayments(uniqueId, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple ratings records to Job
    /// </summary>
    [HttpPost("{Id}/ratings")]
    public async Task<ActionResult> ConnectRatings(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromQuery()] RatingWhereUniqueInput[] ratingsId
    )
    {
        try
        {
            await _service.ConnectRatings(uniqueId, ratingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple ratings records from Job
    /// </summary>
    [HttpDelete("{Id}/ratings")]
    public async Task<ActionResult> DisconnectRatings(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromBody()] RatingWhereUniqueInput[] ratingsId
    )
    {
        try
        {
            await _service.DisconnectRatings(uniqueId, ratingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple ratings records for Job
    /// </summary>
    [HttpGet("{Id}/ratings")]
    public async Task<ActionResult<List<Rating>>> FindRatings(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromQuery()] RatingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindRatings(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple ratings records for Job
    /// </summary>
    [HttpPatch("{Id}/ratings")]
    public async Task<ActionResult> UpdateRatings(
        [FromRoute()] JobWhereUniqueInput uniqueId,
        [FromBody()] RatingWhereUniqueInput[] ratingsId
    )
    {
        try
        {
            await _service.UpdateRatings(uniqueId, ratingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
