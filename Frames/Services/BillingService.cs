namespace Frames.Services;

public class BillingService(IRepositoryManager repositoryManager) : IBillingService
{
    public async Task<BillingSummaryDto?> GetBillingSummary(int month, int year)
    {
        var billing = await repositoryManager.Billing.GetBillingData(month, year);
        return billing?.ToBillingSummaryDto();
    }

    public async Task<BillingDto> GetBillingData(int month, int year)
    {
        var billing = await repositoryManager.Billing.GetBillingData(month, year);
        return billing is null ? throw new Exception("Billing Data not found") : billing.ToDto();
    }

    public async Task CalculateBilling(int month, int year)
    {
        var frameOuts = await repositoryManager.MasterFrameOuts.GetMasterFrameOuts(month, year, false);
        if (frameOuts.Count <= 0)
            return;
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

        var payments = await repositoryManager.Payments.GetPayments(month, year);

        billing.Paid.AddRange(payments.Select(payment => new Paid()
            { Date = payment.Date, Amount = payment.Amount, PaymentId = payment.Id }));

        var lastMonthSummary = month is 1
            ? await GetBillingSummary(12, year - 1)
            : await GetBillingSummary(month - 1, year);

        billing.Summary = new BillingSummary
        {
            Total = billing.BillingItems.Select(x => x.BillingItemDetails.Sum(y => y.Count) * x.Rate).Sum(),
            TotalPaid = billing.Paid.Sum(x => x.Amount),
            LastMonth = lastMonthSummary?.GrandTotal ?? 0
        };

        repositoryManager.Billing.CreateBilling(billing);
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}