namespace Frames.Contracts.Repositories;

public interface IMasterFrameOutTypeRepository
{
    void CreateFrameOutType(MasterFrameOutType frameOutType);
    void UpdateFrameOutType(MasterFrameOutType frameOutType);
    void DeleteFrameOutType(MasterFrameOutType frameOutType);
}