namespace Frames.Contracts.Repositories;

public interface IBillingRepository
{
    Task<Billing?> GetBillingData(int month, int year);
    void CreateBilling(Billing billing);
}