namespace Frames.Repositories;

public class MasterFrameOutRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameOut>(dbContext), IMasterFrameOutRepository
{
}