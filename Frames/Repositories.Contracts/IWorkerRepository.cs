namespace Frames.Repositories.Contracts;

public interface IWorkerRepository
{
    Task<List<Worker>> GetAllWorkers(bool trackChanges);
    Task<List<string>> GetAllWorkerNames();
    Task<Worker?> GetWorkerById(int id, bool trackChanges);
    void AddWorker(Worker worker);
    void UpdateWorker(Worker worker);
    void DeleteWorker(Worker worker);
}