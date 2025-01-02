namespace Frames.Services;

public class ServiceManager(IRepositoryManager repositoryManager) : IServiceManager
{
    private readonly Lazy<IFrameTypeService> _frameTypeService =
        new(() => new FrameTypeService(repositoryManager));

    private readonly Lazy<IWorkerService> _workerService =
        new(() => new WorkerService(repositoryManager));

    private readonly Lazy<IMasterFrameInService> _masterFrameInService =
        new(() => new MasterFrameInService(repositoryManager));

    private readonly Lazy<IMasterFrameOutService> _masterFrameOutService =
        new(() => new MasterFrameOutService(repositoryManager));

    private readonly Lazy<IMasterFrameOutTypeService> _masterFrameOutTypeService =
        new(() => new MasterFrameOutTypeService(repositoryManager));

    public IFrameTypeService FrameTypeService => _frameTypeService.Value;
    public IWorkerService WorkerService => _workerService.Value;
    public IMasterFrameInService MasterFrameInService => _masterFrameInService.Value;
    public IMasterFrameOutService MasterFrameOutService => _masterFrameOutService.Value;
    public IMasterFrameOutTypeService MasterFrameOutTypeService => _masterFrameOutTypeService.Value;
}