namespace Frames.Contracts.Repositories;

public interface IBillingRepository
{
    Task<Billing?> GetBillingSummary(int month, int year);
    void CreateBilling(Billing billing);
}