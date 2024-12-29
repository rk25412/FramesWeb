namespace Frames.Contracts.Repositories;

public interface IRepositoryManager
{
    public IFrameTypeRepository FrameTypes { get; }
    public IWorkerRepository Workers { get; }
    public IMasterFrameInRepository MasterFrameIns { get; }
    void Detach();
    Task SaveAsync();
}