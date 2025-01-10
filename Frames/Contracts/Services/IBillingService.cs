namespace Frames.Contracts.Services;

public interface IBillingService
{
    Task<BillingSummaryDto?> GetBillingSummary(int month, int year);
}