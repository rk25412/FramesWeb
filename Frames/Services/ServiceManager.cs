namespace Frames.Services;

public class ServiceManager(IRepositoryManager repositoryManager) : IServiceManager
{
    private readonly Lazy<IFrameTypeService> _frameTypeService =
        new(() => new FrameTypeService(repositoryManager));
    private readonly Lazy<IWorkerService> _workerService = 
        new(() => new WorkerService(repositoryManager));
    private readonly Lazy<IMasterFrameInService> _masterFrameInService =
        new(() => new MasterFrameInService(repositoryManager));

    public IFrameTypeService FrameTypeService => _frameTypeService.Value;
    public IWorkerService WorkerService => _workerService.Value;
    public IMasterFrameInService MasterFrameInService => _masterFrameInService.Value;
}