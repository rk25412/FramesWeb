namespace Frames.Repositories;

public class RepositoryManager(AppDbContext context) : IRepositoryManager
{
    private readonly Lazy<IFrameTypeRepository> _frameTypeRepository =
        new(() => new FrameTypeRepository(context));

    private readonly Lazy<IWorkerRepository> _workerRepository =
        new(() => new WorkerRepository(context));

    private readonly Lazy<IMasterFrameInRepository> _masterFrameInRepository =
        new(() => new MasterFrameInRepository(context));

    private readonly Lazy<IMasterFrameOutRepository> _masterFrameOutRepository =
        new(() => new MasterFrameOutRepository(context));

    private readonly Lazy<IPaymentsRepository> _paymentsRepository =
        new(() => new PaymentsRepository(context));
    
    public IFrameTypeRepository FrameTypes => _frameTypeRepository.Value;
    public IWorkerRepository Workers => _workerRepository.Value;
    public IMasterFrameInRepository MasterFrameIns => _masterFrameInRepository.Value;
    public IMasterFrameOutRepository MasterFrameOuts => _masterFrameOutRepository.Value;
    public IPaymentsRepository Payments => _paymentsRepository.Value;
    public void Detach() => context.ChangeTracker.Clear();
    public async Task SaveAsync() => await context.SaveChangesAsync();
}