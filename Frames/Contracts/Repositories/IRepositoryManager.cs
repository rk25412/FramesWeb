namespace Frames.Contracts.Repositories;

public interface IRepositoryManager
{
    IFrameTypeRepository FrameTypes { get; }
    IWorkerRepository Workers { get; }
    IMasterFrameInRepository MasterFrameIns { get; }
    IMasterFrameOutRepository MasterFrameOuts { get; }
    IPaymentsRepository Payments { get; }
    IBillingRepository Billing { get; }
    void Detach();
    Task SaveAsync();
}