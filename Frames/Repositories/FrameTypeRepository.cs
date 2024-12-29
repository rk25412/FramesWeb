using Frames.Data;
using Frames.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Frames.Repositories;

public class FrameTypeRepository(AppDbContext dbContext)
    : RepositoryBase<FrameType>(dbContext), IFrameTypeRepository
{
    public async Task<List<FrameType>> GetFrameTypes(bool trackChanges = false)
        => await FindAll(trackChanges).ToListAsync();

    public async Task<List<string>> GetFrameTypeNames()
        => await FindAll(false).Select(x => x.Name).ToListAsync();

    public void AddNewFrameType(FrameType frameType) => Create(frameType);

    public async Task<FrameType?> GetFrameTypeById(int id, bool trackChanges)
        => await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();

    public void UpdateFrameType(FrameType frameType) => Update(frameType);
    public void DeleteFrameType(int id) => Delete(new() { Id = id });
}