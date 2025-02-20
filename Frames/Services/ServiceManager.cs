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

    private readonly Lazy<IPaymentsService> _paymentsService =
        new(() => new PaymentsService(repositoryManager));

    private readonly Lazy<IBillingService> _billingService =
        new(() => new BillingService(repositoryManager));

    public IFrameTypeService FrameTypeService => _frameTypeService.Value;
    public IWorkerService WorkerService => _workerService.Value;
    public IMasterFrameInService MasterFrameInService => _masterFrameInService.Value;
    public IMasterFrameOutService MasterFrameOutService => _masterFrameOutService.Value;
    public IPaymentsService PaymentsService => _paymentsService.Value;
    public IBillingService BillingService => _billingService.Value;
}