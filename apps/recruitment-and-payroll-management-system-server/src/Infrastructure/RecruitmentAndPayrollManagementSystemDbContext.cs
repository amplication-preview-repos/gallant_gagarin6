using Microsoft.EntityFrameworkCore;
using RecruitmentAndPayrollManagementSystem.Infrastructure.Models;

namespace RecruitmentAndPayrollManagementSystem.Infrastructure;

public class RecruitmentAndPayrollManagementSystemDbContext : DbContext
{
    public RecruitmentAndPayrollManagementSystemDbContext(
        DbContextOptions<RecruitmentAndPayrollManagementSystemDbContext> options
    )
        : base(options) { }

    public DbSet<StaffDbModel> StaffItems { get; set; }

    public DbSet<JobDbModel> Jobs { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }

    public DbSet<WalletDbModel> Wallets { get; set; }

    public DbSet<PayrollDbModel> Payrolls { get; set; }

    public DbSet<UserDbModel> Users { get; set; }

    public DbSet<ApplicationDbModel> Applications { get; set; }

    public DbSet<StaffAgencyDbModel> StaffAgencies { get; set; }

    public DbSet<RatingDbModel> Ratings { get; set; }

    public DbSet<TransactionDbModel> Transactions { get; set; }

    public DbSet<SkillDbModel> Skills { get; set; }
}
