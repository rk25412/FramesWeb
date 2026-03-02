namespace Frames.Contracts.Repositories;

public interface IWorkerRepository
{
    Task<List<Worker>> GetAllWorkers(bool trackChanges);
    Task<List<string>> GetAllWorkerNames();
    Task<Worker?> GetWorkerById(long id, bool trackChanges);
    void CreateWorker(Worker worker);
    void UpdateWorker(Worker worker);
    void RemoveWorker(Worker worker);
}