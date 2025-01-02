using System.Linq.Expressions;
using Frames.Services;
using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class MasterFrameOutRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameOut>(dbContext), IMasterFrameOutRepository
{
    public async Task<List<MasterFrameOut>> GetMasterFrameOuts(int month, int year, bool trackChanges)
        => await FindByCondition(x => x.DateTime.Month == month && x.DateTime.Year == year, trackChanges)
            .Include(x => x.MasterFrameOutTypes)
            .ThenInclude(x => x.FrameType)
            .OrderByDescending(x => x.DateTime)
            .ToListAsync();

    public async Task<List<MasterFrameOut>> GetMasterFrameOuts(DateOnly date, bool trackChanges)
        => await FindByCondition(x => DateOnly.FromDateTime(x.DateTime) == date, trackChanges)
            .Include(x => x.MasterFrameOutTypes)
            .ThenInclude(x => x.FrameType)
            .OrderByDescending(x => x.DateTime)
            .ToListAsync();

    public void CreateMasterFrameOuts(List<MasterFrameOut> entities) => entities.ForEach(Create);
    public void CreateMasterFrameOut(MasterFrameOut masterFrameOut) => Create(masterFrameOut);
    public void UpdateMasterFrameOut(MasterFrameOut masterFrameOut) => Update(masterFrameOut);
    public void RemoveMasterFramesOut(MasterFrameOut frameOut) => Delete(frameOut);

    public void RemoveMasterFrameOutByDate(DateOnly date) =>
        DeleteByCodition(x => DateOnly.FromDateTime(x.DateTime) == date);
}