namespace Frames.Contracts.Services;

public interface IPaymentsService
{
    Task<List<PaymentDto>> GetPayments(int month, int year);
    Task<PaymentDto> GetPayment(long paymentId);
    Task<PaymentDto> GetPayment(DateOnly date);
    Task CreateOrUpdatePayment(PaymentDto dto);
    Task RemovePayment(long paymentId);
}