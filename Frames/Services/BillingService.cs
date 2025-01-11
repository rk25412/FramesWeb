namespace Frames.Services;

public class BillingService(IRepositoryManager repositoryManager) : IBillingService
{
    public async Task<BillingSummaryDto?> GetBillingSummary(int month, int year)
    {
        var billing = await repositoryManager.Billing.GetBillingSummary(month, year);
        return billing?.Summary?.ToBillingSummaryDto(month, year);
    }

    public async Task CalculateBilling(int month, int year)
    {
        var frameOuts = await repositoryManager.MasterFrameOuts.GetMasterFrameOuts(month, year, false);
        Billing billing = new()
        {
            Month = month,
            Year = year
        };

        foreach (var frameOut in frameOuts)
        {
            foreach (var frameOutType in frameOut.MasterFrameOutTypes)
            {
                var billingItem =
                    billing.BillingItems.FirstOrDefault((x => x.ItemName!.Equals(frameOutType.FrameType!.Name)));
                if (billingItem is null)
                {
                    billingItem = new BillingItem()
                    {
                        ItemName = frameOutType.FrameType!.Name,
                        Rate = frameOutType.FrameType!.MasterFrameRate
                    };
                    billing.BillingItems.Add(billingItem);
                }

                billingItem.BillingItemDetails.Add(new BillingItemDetail
                {
                    Date = DateOnly.FromDateTime(frameOut.DateTime),
                    Count = frameOutType.Count
                });
            }
        }
    }
}