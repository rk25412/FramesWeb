using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class MasterFrameInRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameIn>(dbContext), IMasterFrameInRepository
{
    public async Task<List<MasterFrameIn>> GetMasterFrameIns(int month, int year, bool trackChanges)
        => await FindByCondition(x => x.DateTime.Month == month && x.DateTime.Year == year, trackChanges)
            .OrderByDescending(x => x.DateTime)
            .ToListAsync();

    public async Task<List<MasterFrameIn>> GetMasterFrameIns(DateOnly date, bool trackChanges)
        => await FindByCondition(x => DateOnly.FromDateTime(x.DateTime) == date, trackChanges)
            .OrderByDescending(x => x.DateTime).ToListAsync();

    public async Task<MasterFrameIn?> GetMasterFrameIn(int id, bool trackChanges)
        => await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();

    public void CreateMasterFrameIn(MasterFrameIn masterFrameIn) => Create(masterFrameIn);
    public void UpdateMasterFrameIn(MasterFrameIn masterFrameIn) => Update(masterFrameIn);
    public void RemoveMasterFrameIn(MasterFrameIn masterFrameIn) => Delete(masterFrameIn);
}