namespace Frames.Contracts.Repositories;

public interface IBillingRepository
{
    Task<Billing?> GetBillingSummary(int month, int year);
}