using Microsoft.EntityFrameworkCore;

namespace Frames.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<FrameType> FrameTypes => Set<FrameType>();
    public DbSet<MasterFrameIn> MasterFrameIns => Set<MasterFrameIn>();
    public DbSet<MasterFrameOut> MasterFrameOuts => Set<MasterFrameOut>();
    public DbSet<MasterFrameOutType> MasterFrameOutTypes => Set<MasterFrameOutType>();
    public DbSet<Worker> Workers => Set<Worker>();
    public DbSet<WorkerFrameIn> WorkerFrameIns => Set<WorkerFrameIn>();
    public DbSet<WorkerFrameOut> WorkerFrameOuts => Set<WorkerFrameOut>();
    public DbSet<WorkerFrameOutType> WorkerFrameOutTypes => Set<WorkerFrameOutType>();
    public DbSet<Payments> Payments => Set<Payments>();
    public DbSet<Billing> Billing => Set<Billing>();
    public DbSet<BillingItem> BillingItem => Set<BillingItem>();
    public DbSet<BillingItemDetail> BillingItemDetail => Set<BillingItemDetail>();
    public DbSet<BillingSummary> BillingSummary => Set<BillingSummary>();
    public DbSet<Paid> Paid => Set<Paid>();
}