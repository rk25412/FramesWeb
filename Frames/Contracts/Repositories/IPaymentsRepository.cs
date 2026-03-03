namespace Frames.Contracts.Repositories;

public interface IPaymentsRepository
{
    Task<List<Payment>> GetPayments(int month, int year);
    Task<Payment?> GetPayment(long paymentId);
    Task<Payment?> GetPayment(DateOnly date);
    void CreatePayment(Payment payment);
    void UpdatePayment(Payment payment);
    void DeletePayment(long paymentId);
}