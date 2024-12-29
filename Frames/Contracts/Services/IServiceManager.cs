namespace Frames.Contracts.Services;

public interface IServiceManager
{
    IFrameTypeService FrameTypeService { get; }
    IWorkerService WorkerService { get; }
    IMasterFrameInService MasterFrameInService { get; }
}