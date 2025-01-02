namespace Frames.Contracts.Services;

public interface IMasterFrameOutTypeService
{
    Task RemoveMasterFrameOutTypes(List<int> frameOutTypeIds);
}