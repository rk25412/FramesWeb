using Frames.Contracts.Repositories;
using Frames.Data;

namespace Frames.Repositories;

public class MasterFrameInRepository(AppDbContext dbContext)
    : RepositoryBase<MasterFrameIn>(dbContext), IMasterFrameInRepository
{
}