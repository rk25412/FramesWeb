namespace Frames.Repositories;

public class MasterFrameOutTypeRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameOutType>(dbContext), IMasterFrameOutTypeRepository
{
    public void CreateFrameOutType(MasterFrameOutType frameOutType) => Create(frameOutType);

    public void UpdateFrameOutType(MasterFrameOutType frameOutType) => Update(frameOutType);

    public void DeleteFrameOutType(MasterFrameOutType frameOutType) => Delete(frameOutType);
}