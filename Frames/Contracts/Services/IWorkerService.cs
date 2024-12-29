namespace Frames.Contracts.Services;

public interface IWorkerService
{
    Task<List<WorkerDto>> GetWorkers();
    Task<List<string>> GetWorkerNames();
    Task CreateWorker(WorkerDto newWorker);
    Task<WorkerDto> GetWorkerById(int workerId);
    Task UpdateWorker(WorkerDto worker);
    Task DeleteWorker(int workerId);
}