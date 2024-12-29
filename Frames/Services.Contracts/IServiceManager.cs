namespace Frames.Services.Contracts;

public interface IServiceManager
{
    IFrameTypeService FrameTypeService { get; }
    IWorkerService WorkerService { get; }
}