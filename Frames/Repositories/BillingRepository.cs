using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class BillingRepository(AppDbContext dbContext)
    : RepositoryBase<Billing>(dbContext), IBillingRepository
{
    public async Task<Billing?> GetBillingSummary(int month, int year)
    {
        var summary = await FindByCondition(x => x.Month == month && x.Year == year, false)
            .Include(x => x.Summary)
            .SingleOrDefaultAsync();
        return summary;
    }
}