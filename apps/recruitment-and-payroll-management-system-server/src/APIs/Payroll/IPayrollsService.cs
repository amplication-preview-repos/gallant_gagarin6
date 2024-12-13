using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.APIs.Dtos;

namespace RecruitmentAndPayrollManagementSystem.APIs;

public interface IPayrollsService
{
    /// <summary>
    /// Create one Payroll
    /// </summary>
    public Task<Payroll> CreatePayroll(PayrollCreateInput payroll);

    /// <summary>
    /// Delete one Payroll
    /// </summary>
    public Task DeletePayroll(PayrollWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Payrolls
    /// </summary>
    public Task<List<Payroll>> Payrolls(PayrollFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Payroll records
    /// </summary>
    public Task<MetadataDto> PayrollsMeta(PayrollFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Payroll
    /// </summary>
    public Task<Payroll> Payroll(PayrollWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Payroll
    /// </summary>
    public Task UpdatePayroll(PayrollWhereUniqueInput uniqueId, PayrollUpdateInput updateDto);
}
