namespace Frames.Contracts.Services;

public interface IBillingService
{
    Task<BillingSummaryDto?> GetBillingSummary(int month, int year);
    Task<BillingDto> GetBillingData(int month, int year);
    Task CalculateBilling(int month, int year);
}