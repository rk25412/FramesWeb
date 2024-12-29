using Frames.Data;
using Frames.Repositories.Contracts;

namespace Frames.Repositories;

public class RepositoryManager(AppDbContext context) : IRepositoryManager
{
    private readonly Lazy<IFrameTypeRepository> _frameTypeRepository =
        new(() => new FrameTypeRepository(context));

    private readonly Lazy<IWorkerRepository> _workerRepository =
        new(() => new WorkerRepository(context));
    public IFrameTypeRepository FrameTypes => _frameTypeRepository.Value;
    public IWorkerRepository Workers => _workerRepository.Value;
    
    public void Save() => context.SaveChanges();
    public void Detach() => context.ChangeTracker.Clear();
    public async Task SaveAsync() => await context.SaveChangesAsync();
}