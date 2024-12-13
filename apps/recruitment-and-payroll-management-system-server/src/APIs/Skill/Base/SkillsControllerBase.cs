using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SkillsControllerBase : ControllerBase
{
    protected readonly ISkillsService _service;

    public SkillsControllerBase(ISkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Skill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Skill>> CreateSkill(SkillCreateInput input)
    {
        var skill = await _service.CreateSkill(input);

        return CreatedAtAction(nameof(Skill), new { id = skill.Id }, skill);
    }

    /// <summary>
    /// Delete one Skill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSkill([FromRoute()] SkillWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Skills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Skill>>> Skills([FromQuery()] SkillFindManyArgs filter)
    {
        return Ok(await _service.Skills(filter));
    }

    /// <summary>
    /// Meta data about Skill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SkillsMeta([FromQuery()] SkillFindManyArgs filter)
    {
        return Ok(await _service.SkillsMeta(filter));
    }

    /// <summary>
    /// Get one Skill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Skill>> Skill([FromRoute()] SkillWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Skill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Skill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSkill(
        [FromRoute()] SkillWhereUniqueInput uniqueId,
        [FromQuery()] SkillUpdateInput skillUpdateDto
    )
    {
        try
        {
            await _service.UpdateSkill(uniqueId, skillUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Job record for Skill
    /// </summary>
    [HttpGet("{Id}/job")]
    public async Task<ActionResult<List<Job>>> GetJob([FromRoute()] SkillWhereUniqueInput uniqueId)
    {
        var job = await _service.GetJob(uniqueId);
        return Ok(job);
    }

    /// <summary>
    /// Get a StaffItems record for Skill
    /// </summary>
    [HttpGet("{Id}/staffItems")]
    public async Task<ActionResult<List<Staff>>> GetStaffItems(
        [FromRoute()] SkillWhereUniqueInput uniqueId
    )
    {
        var staff = await _service.GetStaffItems(uniqueId);
        return Ok(staff);
    }

    /// <summary>
    /// Get a User record for Skill
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] SkillWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
