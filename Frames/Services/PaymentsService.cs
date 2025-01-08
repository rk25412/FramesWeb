namespace Frames.Services;

public class PaymentsService(IRepositoryManager repositoryManager) : IPaymentsService
{
    public async Task<List<PaymentDto>> GetPayments(int month, int year)
    {
        var payments = await repositoryManager.Payments.GetPayments(month, year);
        var dto = payments.Select(x => x.ToDto()).ToList();
        return dto;
    }

    public async Task<PaymentDto> GetPayment(int paymentId)
    {
        var payment = await repositoryManager.Payments.GetPayment(paymentId);
        if (payment is null)
            throw new Exception($"Payment with Id {paymentId} not found");
        return payment.ToDto();
    }

    public async Task<PaymentDto> GetPayment(DateOnly date)
    {
        var payment = await repositoryManager.Payments.GetPayment(date);
        return payment is null ? new PaymentDto() { Date = date, Amount = 1000 } : payment.ToDto();
    }

    public async Task CreateOrUpdatePayment(PaymentDto dto)
    {
        var entity = dto.ToEntity();
        if (entity.Id is 0)
            repositoryManager.Payments.CreatePayment(entity);
        else
            repositoryManager.Payments.UpdatePayment(entity);

        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task RemovePayment(int paymentId)
    {
        repositoryManager.Payments.DeletePayment(paymentId);
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}