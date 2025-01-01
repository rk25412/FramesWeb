namespace Frames.Repositories;

public class MasterFrameOutTypeRepository(AppDbContext context)
    : RepositoryBase<MasterFrameOutType>(context), IMasterFrameOutTypeRepository
{
    public void UpdateMasterOutType(MasterFrameOutType masterFrameOutType) => Update(masterFrameOutType);
    public void DeleteMasterOutType(MasterFrameOutType masterFrameOutType) => Delete(masterFrameOutType);
    // public void DeleteMasterOutType(int masterOutId) => DeleteByCodition(x => x.)
}