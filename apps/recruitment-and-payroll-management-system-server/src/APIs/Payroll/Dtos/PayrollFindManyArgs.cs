using Microsoft.AspNetCore.Mvc;
using RecruitmentAndPayrollManagementSystem.APIs.Common;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PayrollFindManyArgs : FindManyInput<Payroll, PayrollWhereInput> { }
