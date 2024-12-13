using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RatingsControllerBase : ControllerBase
{
    protected readonly IRatingsService _service;

    public RatingsControllerBase(IRatingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Rating
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Rating>> CreateRating(RatingCreateInput input)
    {
        var rating = await _service.CreateRating(input);

        return CreatedAtAction(nameof(Rating), new { id = rating.Id }, rating);
    }

    /// <summary>
    /// Delete one Rating
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRating([FromRoute()] RatingWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRating(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Ratings
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Rating>>> Ratings([FromQuery()] RatingFindManyArgs filter)
    {
        return Ok(await _service.Ratings(filter));
    }

    /// <summary>
    /// Meta data about Rating records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RatingsMeta(
        [FromQuery()] RatingFindManyArgs filter
    )
    {
        return Ok(await _service.RatingsMeta(filter));
    }

    /// <summary>
    /// Get one Rating
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Rating>> Rating([FromRoute()] RatingWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Rating(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Rating
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateRating(
        [FromRoute()] RatingWhereUniqueInput uniqueId,
        [FromQuery()] RatingUpdateInput ratingUpdateDto
    )
    {
        try
        {
            await _service.UpdateRating(uniqueId, ratingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a job record for Rating
    /// </summary>
    [HttpGet("{Id}/job")]
    public async Task<ActionResult<List<Job>>> GetJob([FromRoute()] RatingWhereUniqueInput uniqueId)
    {
        var job = await _service.GetJob(uniqueId);
        return Ok(job);
    }
}
