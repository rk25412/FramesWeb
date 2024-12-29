using Frames.Repositories.Contracts;
using Frames.Services.Contracts;

namespace Frames.Services;

public class WorkerService(IRepositoryManager repoManager) : IWorkerService
{
    public async Task<List<WorkerDto>> GetWorkers()
    {
        var workersEntity = await repoManager.Workers.GetAllWorkers(false);
        var workersDto = workersEntity.Select(x => x.ToWorkerDto()).ToList();
        return workersDto;
    }

    public async Task<List<string>> GetWorkerNames()
        => await repoManager.Workers.GetAllWorkerNames();

    public async Task AddWorker(WorkerDto newWorker)
    {
        repoManager.Workers.AddWorker(newWorker.ToWorkerEntity());
        await repoManager.SaveAsync();
        repoManager.Detach();
    }

    public async Task<WorkerDto> GetWorkerById(int workerId)
    {
        var workerEntity = await repoManager.Workers.GetWorkerById(workerId, false);
        if (workerEntity == null)
        {
            throw new Exception($"Worker Id {workerId} not found");
        }
        return workerEntity.ToWorkerDto();
    }

    public async Task UpdateWorker(WorkerDto worker)
    {
        repoManager.Workers.UpdateWorker(worker.ToWorkerEntity());
        await repoManager.SaveAsync();
        repoManager.Detach();
    }

    public async Task DeleteWorker(int workerId)
    {
        repoManager.Workers.DeleteWorker(new Worker { Id = workerId });
        await repoManager.SaveAsync();
        repoManager.Detach();
    }
}