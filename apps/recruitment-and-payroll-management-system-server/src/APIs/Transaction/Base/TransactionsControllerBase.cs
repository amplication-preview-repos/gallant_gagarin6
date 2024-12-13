using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;
using RecruitmentAndPayrollManagementSystem.APIs.Errors;

namespace RecruitmentAndPayrollManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TransactionsControllerBase : ControllerBase
{
    protected readonly ITransactionsService _service;

    public TransactionsControllerBase(ITransactionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Transaction
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Transaction>> CreateTransaction(TransactionCreateInput input)
    {
        var transaction = await _service.CreateTransaction(input);

        return CreatedAtAction(nameof(Transaction), new { id = transaction.Id }, transaction);
    }

    /// <summary>
    /// Delete one Transaction
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTransaction(
        [FromRoute()] TransactionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTransaction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Transactions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Transaction>>> Transactions(
        [FromQuery()] TransactionFindManyArgs filter
    )
    {
        return Ok(await _service.Transactions(filter));
    }

    /// <summary>
    /// Meta data about Transaction records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TransactionsMeta(
        [FromQuery()] TransactionFindManyArgs filter
    )
    {
        return Ok(await _service.TransactionsMeta(filter));
    }

    /// <summary>
    /// Get one Transaction
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Transaction>> Transaction(
        [FromRoute()] TransactionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Transaction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Transaction
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTransaction(
        [FromRoute()] TransactionWhereUniqueInput uniqueId,
        [FromQuery()] TransactionUpdateInput transactionUpdateDto
    )
    {
        try
        {
            await _service.UpdateTransaction(uniqueId, transactionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a wallet record for Transaction
    /// </summary>
    [HttpGet("{Id}/wallet")]
    public async Task<ActionResult<List<Wallet>>> GetWallet(
        [FromRoute()] TransactionWhereUniqueInput uniqueId
    )
    {
        var wallet = await _service.GetWallet(uniqueId);
        return Ok(wallet);
    }
}
