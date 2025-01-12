using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class BillingRepository(AppDbContext dbContext)
    : RepositoryBase<Billing>(dbContext), IBillingRepository
{
    public async Task<Billing?> GetBillingData(int month, int year)
        => await FindByCondition(x => x.Month == month && x.Year == year, false)
            .Include(x => x.Summary)
            .Include(x => x.Paid)
            .Include(x => x.BillingItems)
            .ThenInclude(x => x.BillingItemDetails)
            .SingleOrDefaultAsync();

    public void CreateBilling(Billing billing) => Create(billing);
}