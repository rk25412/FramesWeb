namespace Frames.Repositories;

public class MasterFrameOutTypeRepository(AppDbContext context)
    : RepositoryBase<MasterFrameOutType>(context), IMasterFrameOutTypeRepository
{
    public void UpdateMasterOutType(MasterFrameOutType masterFrameOutType) => Update(masterFrameOutType);
}