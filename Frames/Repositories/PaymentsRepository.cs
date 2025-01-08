using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class PaymentsRepository(AppDbContext dbContext)
    : RepositoryBase<Payments>(dbContext), IPaymentsRepository
{
    public async Task<List<Payments>> GetPayments(int month, int year)
        => await FindByCondition(x => x.Date.Month == month && x.Date.Year == year, false)
            .OrderByDescending(x => x.Date)
            .ToListAsync();

    public async Task<Payments?> GetPayment(int paymentId)
        => await FindByCondition(x => x.Id == paymentId, false).SingleOrDefaultAsync();

    public async Task<Payments?> GetPayment(DateOnly date)
        => await FindByCondition(x => x.Date == date, false).SingleOrDefaultAsync();

    public void CreatePayment(Payments payment) => Create(payment);
    public void UpdatePayment(Payments payment) => Update(payment);
    public void DeletePayment(int paymentId) => Delete(new Payments { Id = paymentId });
}