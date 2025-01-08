namespace Frames.Repositories;

public class PaymentsRepository(AppDbContext dbContext)
    : RepositoryBase<Payments>(dbContext), IPaymentsRepository
{
}