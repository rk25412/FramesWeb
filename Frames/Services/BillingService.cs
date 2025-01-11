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
        
    }
}