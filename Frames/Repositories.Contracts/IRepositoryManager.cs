namespace Frames.Repositories.Contracts;

public interface IRepositoryManager
{
    public IFrameTypeRepository FrameTypes { get; }
    public IWorkerRepository Workers { get; }
    void Save();
    void Detach();
    Task SaveAsync();
}