namespace Frames.Services;

public class WorkerService(IRepositoryManager repoManager) : IWorkerService
{
    public async Task<List<WorkerDto>> GetWorkers()
    {
        var workersEntity = await repoManager.Workers.GetAllWorkers(false);
        var workersDto = workersEntity.Select(x => x.ToDto()).ToList();
        return workersDto;
    }

    public async Task<List<string>> GetWorkerNames()
        => await repoManager.Workers.GetAllWorkerNames();

    public async Task CreateWorker(WorkerDto newWorker)
    {
        repoManager.Workers.CreateWorker(newWorker.ToEntity());
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
        return workerEntity.ToDto();
    }

    public async Task UpdateWorker(WorkerDto worker)
    {
        repoManager.Workers.UpdateWorker(worker.ToEntity());
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