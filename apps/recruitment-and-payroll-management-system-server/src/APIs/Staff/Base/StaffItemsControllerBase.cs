using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class StaffItemsControllerBase : ControllerBase
{
    protected readonly IStaffItemsService _service;

    public StaffItemsControllerBase(IStaffItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Staff
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Staff>> CreateStaff(StaffCreateInput input)
    {
        var staff = await _service.CreateStaff(input);

        return CreatedAtAction(nameof(Staff), new { id = staff.Id }, staff);
    }

    /// <summary>
    /// Delete one Staff
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteStaff([FromRoute()] StaffWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteStaff(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many StaffItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Staff>>> StaffItems([FromQuery()] StaffFindManyArgs filter)
    {
        return Ok(await _service.StaffItems(filter));
    }

    /// <summary>
    /// Meta data about Staff records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> StaffItemsMeta(
        [FromQuery()] StaffFindManyArgs filter
    )
    {
        return Ok(await _service.StaffItemsMeta(filter));
    }

    /// <summary>
    /// Get one Staff
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Staff>> Staff([FromRoute()] StaffWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Staff(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Staff
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateStaff(
        [FromRoute()] StaffWhereUniqueInput uniqueId,
        [FromQuery()] StaffUpdateInput staffUpdateDto
    )
    {
        try
        {
            await _service.UpdateStaff(uniqueId, staffUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple skills records to Staff
    /// </summary>
    [HttpPost("{Id}/skills")]
    public async Task<ActionResult> ConnectSkills(
        [FromRoute()] StaffWhereUniqueInput uniqueId,
        [FromQuery()] SkillWhereUniqueInput[] skillsId
    )
    {
        try
        {
            await _service.ConnectSkills(uniqueId, skillsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple skills records from Staff
    /// </summary>
    [HttpDelete("{Id}/skills")]
    public async Task<ActionResult> DisconnectSkills(
        [FromRoute()] StaffWhereUniqueInput uniqueId,
        [FromBody()] SkillWhereUniqueInput[] skillsId
    )
    {
        try
        {
            await _service.DisconnectSkills(uniqueId, skillsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple skills records for Staff
    /// </summary>
    [HttpGet("{Id}/skills")]
    public async Task<ActionResult<List<Skill>>> FindSkills(
        [FromRoute()] StaffWhereUniqueInput uniqueId,
        [FromQuery()] SkillFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSkills(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple skills records for Staff
    /// </summary>
    [HttpPatch("{Id}/skills")]
    public async Task<ActionResult> UpdateSkills(
        [FromRoute()] StaffWhereUniqueInput uniqueId,
        [FromBody()] SkillWhereUniqueInput[] skillsId
    )
    {
        try
        {
            await _service.UpdateSkills(uniqueId, skillsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user record for Staff
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] StaffWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
