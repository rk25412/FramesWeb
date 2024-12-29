using Frames.Contracts.Repositories;
using Frames.Data;
using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class WorkerRepository(AppDbContext dbContext) : RepositoryBase<Worker>(dbContext), IWorkerRepository
{
    public async Task<List<Worker>> GetAllWorkers(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();

    public async Task<List<string>> GetAllWorkerNames()
        => await FindAll(false).Select(x => x.Name).ToListAsync();

    public async Task<Worker?> GetWorkerById(int id, bool trackChanges)
        => await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();

    public void CreateWorker(Worker worker) => Create(worker);

    public void UpdateWorker(Worker worker) => Update(worker);

    public void DeleteWorker(Worker worker) => Delete(worker);
}