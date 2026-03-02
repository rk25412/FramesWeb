namespace Frames.Contracts.Services;

public interface IWorkerService
{
    Task<List<WorkerDto>> GetWorkers();
    Task<List<string>> GetWorkerNames();
    Task<WorkerDto> GetWorkerById(long workerId);
    Task CreateWorker(WorkerDto newWorker);
    Task UpdateWorker(WorkerDto worker);
    Task RemoveWorker(long workerId);
}