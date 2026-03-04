using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class BillingRepository(AppDbContext dbContext)
    : RepositoryBase<Billing>(dbContext), IBillingRepository
{
    public async Task<Billing?> GetBillingData(int month, int year)
        => await FindByCondition(x => x.Month == month && x.Year == year, false)
            .Select(b => new Billing()
            {
                Month = b.Month,
                Year = b.Year,
                BillingItems = b.BillingItems.Select(bi => new BillingItem
                {
                    ItemName = bi.ItemName,
                    Rate = bi.Rate,
                    BillingId = bi.BillingId,
                    BillingItemDetails = bi.BillingItemDetails.Select(bid => new BillingItemDetail()
                    {
                        Date = bid.Date,
                        Count = bid.Count,
                        BillingItemId = bid.BillingItemId,
                    }).ToList()
                }).ToList(),
                Summary = b.Summary,
            }).FirstOrDefaultAsync();

    public void CreateBilling(Billing billing) => Create(billing);
}