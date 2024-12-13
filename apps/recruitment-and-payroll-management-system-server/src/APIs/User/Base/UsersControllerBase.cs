using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsersControllerBase : ControllerBase
{
    protected readonly IUsersService _service;

    public UsersControllerBase(IUsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
    {
        var user = await _service.CreateUser(input);

        return CreatedAtAction(nameof(User), new { id = user.Id }, user);
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUser([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteUser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<User>>> Users([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.Users(filter));
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsersMeta([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.UsersMeta(filter));
    }

    /// <summary>
    /// Get one User
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> User([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.User(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one User
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] UserUpdateInput userUpdateDto
    )
    {
        try
        {
            await _service.UpdateUser(uniqueId, userUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple applications records to User
    /// </summary>
    [HttpPost("{Id}/applications")]
    public async Task<ActionResult> ConnectApplications(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple applications records from User
    /// </summary>
    [HttpDelete("{Id}/applications")]
    public async Task<ActionResult> DisconnectApplications(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple applications records for User
    /// </summary>
    [HttpGet("{Id}/applications")]
    public async Task<ActionResult<List<Application>>> FindApplications(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple applications records for User
    /// </summary>
    [HttpPatch("{Id}/applications")]
    public async Task<ActionResult> UpdateApplications(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple Jobs records to User
    /// </summary>
    [HttpPost("{Id}/jobs")]
    public async Task<ActionResult> ConnectJobs(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] JobWhereUniqueInput[] jobsId
    )
    {
        try
        {
            await _service.ConnectJobs(uniqueId, jobsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Jobs records from User
    /// </summary>
    [HttpDelete("{Id}/jobs")]
    public async Task<ActionResult> DisconnectJobs(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] JobWhereUniqueInput[] jobsId
    )
    {
        try
        {
            await _service.DisconnectJobs(uniqueId, jobsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Jobs records for User
    /// </summary>
    [HttpGet("{Id}/jobs")]
    public async Task<ActionResult<List<Job>>> FindJobs(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] JobFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindJobs(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Jobs records for User
    /// </summary>
    [HttpPatch("{Id}/jobs")]
    public async Task<ActionResult> UpdateJobs(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] JobWhereUniqueInput[] jobsId
    )
    {
        try
        {
            await _service.UpdateJobs(uniqueId, jobsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple skills records to User
    /// </summary>
    [HttpPost("{Id}/skills")]
    public async Task<ActionResult> ConnectSkills(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple skills records from User
    /// </summary>
    [HttpDelete("{Id}/skills")]
    public async Task<ActionResult> DisconnectSkills(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple skills records for User
    /// </summary>
    [HttpGet("{Id}/skills")]
    public async Task<ActionResult<List<Skill>>> FindSkills(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple skills records for User
    /// </summary>
    [HttpPatch("{Id}/skills")]
    public async Task<ActionResult> UpdateSkills(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple staffAgencies records to User
    /// </summary>
    [HttpPost("{Id}/staffAgencies")]
    public async Task<ActionResult> ConnectStaffAgencies(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] StaffAgencyWhereUniqueInput[] staffAgenciesId
    )
    {
        try
        {
            await _service.ConnectStaffAgencies(uniqueId, staffAgenciesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple staffAgencies records from User
    /// </summary>
    [HttpDelete("{Id}/staffAgencies")]
    public async Task<ActionResult> DisconnectStaffAgencies(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] StaffAgencyWhereUniqueInput[] staffAgenciesId
    )
    {
        try
        {
            await _service.DisconnectStaffAgencies(uniqueId, staffAgenciesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple staffAgencies records for User
    /// </summary>
    [HttpGet("{Id}/staffAgencies")]
    public async Task<ActionResult<List<StaffAgency>>> FindStaffAgencies(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] StaffAgencyFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindStaffAgencies(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple staffAgencies records for User
    /// </summary>
    [HttpPatch("{Id}/staffAgencies")]
    public async Task<ActionResult> UpdateStaffAgencies(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] StaffAgencyWhereUniqueInput[] staffAgenciesId
    )
    {
        try
        {
            await _service.UpdateStaffAgencies(uniqueId, staffAgenciesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a staffAgency record for User
    /// </summary>
    [HttpGet("{Id}/staffAgency")]
    public async Task<ActionResult<List<StaffAgency>>> GetStaffAgency(
        [FromRoute()] UserWhereUniqueInput uniqueId
    )
    {
        var staffAgency = await _service.GetStaffAgency(uniqueId);
        return Ok(staffAgency);
    }

    /// <summary>
    /// Get a staffData record for User
    /// </summary>
    [HttpGet("{Id}/staffData")]
    public async Task<ActionResult<List<Staff>>> GetStaffData(
        [FromRoute()] UserWhereUniqueInput uniqueId
    )
    {
        var staff = await _service.GetStaffData(uniqueId);
        return Ok(staff);
    }

    /// <summary>
    /// Get a wallet record for User
    /// </summary>
    [HttpGet("{Id}/wallets")]
    public async Task<ActionResult<List<Wallet>>> GetWallets(
        [FromRoute()] UserWhereUniqueInput uniqueId
    )
    {
        var wallet = await _service.GetWallets(uniqueId);
        return Ok(wallet);
    }
}
