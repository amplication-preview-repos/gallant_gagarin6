using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WalletsControllerBase : ControllerBase
{
    protected readonly IWalletsService _service;

    public WalletsControllerBase(IWalletsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Wallet
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Wallet>> CreateWallet(WalletCreateInput input)
    {
        var wallet = await _service.CreateWallet(input);

        return CreatedAtAction(nameof(Wallet), new { id = wallet.Id }, wallet);
    }

    /// <summary>
    /// Delete one Wallet
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWallet([FromRoute()] WalletWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteWallet(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Wallets
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Wallet>>> Wallets([FromQuery()] WalletFindManyArgs filter)
    {
        return Ok(await _service.Wallets(filter));
    }

    /// <summary>
    /// Meta data about Wallet records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WalletsMeta(
        [FromQuery()] WalletFindManyArgs filter
    )
    {
        return Ok(await _service.WalletsMeta(filter));
    }

    /// <summary>
    /// Get one Wallet
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Wallet>> Wallet([FromRoute()] WalletWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Wallet(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Wallet
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWallet(
        [FromRoute()] WalletWhereUniqueInput uniqueId,
        [FromQuery()] WalletUpdateInput walletUpdateDto
    )
    {
        try
        {
            await _service.UpdateWallet(uniqueId, walletUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Transactions records to Wallet
    /// </summary>
    [HttpPost("{Id}/transactions")]
    public async Task<ActionResult> ConnectTransactions(
        [FromRoute()] WalletWhereUniqueInput uniqueId,
        [FromQuery()] TransactionWhereUniqueInput[] transactionsId
    )
    {
        try
        {
            await _service.ConnectTransactions(uniqueId, transactionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Transactions records from Wallet
    /// </summary>
    [HttpDelete("{Id}/transactions")]
    public async Task<ActionResult> DisconnectTransactions(
        [FromRoute()] WalletWhereUniqueInput uniqueId,
        [FromBody()] TransactionWhereUniqueInput[] transactionsId
    )
    {
        try
        {
            await _service.DisconnectTransactions(uniqueId, transactionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Transactions records for Wallet
    /// </summary>
    [HttpGet("{Id}/transactions")]
    public async Task<ActionResult<List<Transaction>>> FindTransactions(
        [FromRoute()] WalletWhereUniqueInput uniqueId,
        [FromQuery()] TransactionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindTransactions(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Transactions records for Wallet
    /// </summary>
    [HttpPatch("{Id}/transactions")]
    public async Task<ActionResult> UpdateTransactions(
        [FromRoute()] WalletWhereUniqueInput uniqueId,
        [FromBody()] TransactionWhereUniqueInput[] transactionsId
    )
    {
        try
        {
            await _service.UpdateTransactions(uniqueId, transactionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a user record for Wallet
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] WalletWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
