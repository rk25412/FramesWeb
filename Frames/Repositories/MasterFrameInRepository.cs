using Frames.Contracts.Repositories;
using Frames.Data;
using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class MasterFrameInRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameIn>(dbContext), IMasterFrameInRepository
{
    public async Task<List<MasterFrameIn>> GetMasterFrameIns(int month, int year, bool trackChanges)
        => await FindByCondition(x => x.DateTime.Month == month && x.DateTime.Year == year, trackChanges)
            .ToListAsync();

    public async Task<List<MasterFrameIn>> GetMasterFrameIns(DateOnly date, bool trackChanges)
    {
        var minDate = new DateTime(date.Year, date.Month, 1).AddDays(-1);
        var maxDate = new DateTime(date.Year, date.Month, 1).AddMonths(1);
        return await FindByCondition(x => x.DateTime > minDate && x.DateTime < maxDate, trackChanges).ToListAsync();
    }

    public async Task<MasterFrameIn?> GetMasterFrameIn(int id, bool trackChanges)
     => await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();

    public void CreateMasterFrameIn(MasterFrameIn masterFrameIn) => Create(masterFrameIn);
    public void CreateMultipleMasterFrameIns(List<MasterFrameIn> masterFrameIns) => masterFrameIns.ForEach(Create);
    public void UpdateMasterFrameIn(MasterFrameIn masterFrameIn) => Update(masterFrameIn);
    public void DeleteMasterFrameIn(MasterFrameIn masterFrameIn) => Delete(masterFrameIn);
}