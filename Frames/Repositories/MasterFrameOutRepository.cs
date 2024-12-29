using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class MasterFrameOutRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameOut>(dbContext), IMasterFrameOutRepository
{
    public async Task<List<MasterFrameOut>> GetMasterFrameOuts(int month, int year, bool trackChanges)
        => await FindByCondition(x => x.DateTime.Month == month && x.DateTime.Year == year, trackChanges)
            .Include(x => x.MasterFrameOutTypes)
            .OrderByDescending(x => x.DateTime)
            .ToListAsync();
}