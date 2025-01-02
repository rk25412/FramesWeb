namespace Frames.Services;

public class MasterFrameOutTypeService(IRepositoryManager repositoryManager) : IMasterFrameOutTypeService
{
    public async Task RemoveMasterFrameOutTypes(List<int> frameOutTypeIds)
    {
        frameOutTypeIds.ForEach(x => repositoryManager.MasterFrameOutTypes.RemoveMasterOutType(new() {Id = x}));
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}