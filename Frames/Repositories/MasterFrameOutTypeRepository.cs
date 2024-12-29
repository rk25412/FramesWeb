namespace Frames.Repositories;

public class MasterFrameOutTypeRepository(AppDbContext context)
    : RepositoryBase<MasterFrameOutType>(context), IMasterFrameOutTypeRepository
{
}