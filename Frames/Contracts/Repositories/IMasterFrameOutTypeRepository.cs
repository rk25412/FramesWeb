namespace Frames.Contracts.Repositories;

public interface IMasterFrameOutTypeRepository
{
    void UpdateMasterOutType(MasterFrameOutType masterFrameOutType);
    void DeleteMasterOutType(MasterFrameOutType masterFrameOutType);
    // void DeleteMasterOutType(int masterOutId);
}