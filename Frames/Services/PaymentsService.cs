using Frames.Repositories;

namespace Frames.Services;

public class PaymentsService(IRepositoryManager repositoryManager) : IPaymentsService
{
}