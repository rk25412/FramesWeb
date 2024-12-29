using Frames.Repositories.Contracts;
using Frames.Services.Contracts;

namespace Frames.Services;

public class ServiceManager(IRepositoryManager repositoryManager) : IServiceManager
{
    private readonly Lazy<IFrameTypeService> _frameTypeService =
        new(() => new FrameTypeService(repositoryManager));
    private readonly Lazy<IWorkerService> _workerRepository = 
        new(() => new WorkerService(repositoryManager));

    public IFrameTypeService FrameTypeService => _frameTypeService.Value;
    public IWorkerService WorkerService => _workerRepository.Value;
}