namespace Frames.Contracts.Repositories;

public interface IMasterFrameOutTypeRepository
{
    void UpdateMasterOutType(MasterFrameOutType masterFrameOutType);
    void RemoveMasterOutType(MasterFrameOutType masterFrameOutType);
}