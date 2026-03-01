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

    public async Task<WorkerDto> GetWorkerById(int workerId)
    {
        var workerEntity = await repoManager.Workers.GetWorkerById(workerId, false);
        return workerEntity == null ? throw new Exception($"Worker Id {workerId} not found") : workerEntity.ToDto();
    }

    public async Task CreateWorker(WorkerDto newWorker)
    {
        repoManager.Workers.CreateWorker(newWorker.ToEntity());
        await repoManager.SaveAsync();
        repoManager.Detach();
    }


    public async Task UpdateWorker(WorkerDto worker)
    {
        var entity = worker.ToEntity();
        entity.ModifiedDate = DateTime.Now;
        repoManager.Workers.UpdateWorker(entity);
        await repoManager.SaveAsync();
        repoManager.Detach();
    }

    public async Task RemoveWorker(int workerId)
    {
        repoManager.Workers.RemoveWorker(new Worker { Id = workerId });
        await repoManager.SaveAsync();
        repoManager.Detach();
    }
}