namespace Frames.Contracts.Repositories;

public interface IPaymentsRepository
{
    Task<List<Payments>> GetPayments(int month, int year);
    Task<Payments?> GetPayment(int paymentId);
    Task<Payments?> GetPayment(DateOnly date);
    void CreatePayment(Payments payment);
    void UpdatePayment(Payments payment);
    void DeletePayment(int paymentId);
}