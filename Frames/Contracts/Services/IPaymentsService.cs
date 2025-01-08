namespace Frames.Contracts.Services;

public interface IPaymentsService
{
    Task<List<PaymentDto>> GetPayments(int month, int year);
    Task<PaymentDto> GetPayment(int paymentId);
    Task<PaymentDto> GetPayment(DateOnly date);
    Task CreateOrUpdatePayment(PaymentDto dto);
    Task RemovePayment(int paymentId);
}