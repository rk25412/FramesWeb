using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class PaymentsRepository(AppDbContext dbContext)
    : RepositoryBase<Payment>(dbContext), IPaymentsRepository
{
    public async Task<List<Payment>> GetPayments(int month, int year)
        => await FindByCondition(x => x.Date.Month == month && x.Date.Year == year, false)
            .OrderByDescending(x => x.Date)
            .ToListAsync();

    public async Task<Payment?> GetPayment(long paymentId)
        => await FindByCondition(x => x.Id == paymentId, false).SingleOrDefaultAsync();

    public async Task<Payment?> GetPayment(DateOnly date)
        => await FindByCondition(x => x.Date == date, false).SingleOrDefaultAsync();

    public void CreatePayment(Payment payment) => Create(payment);
    public void UpdatePayment(Payment payment) => Update(payment);
    public void DeletePayment(long paymentId) => Delete(new Payment { Id = paymentId });
}