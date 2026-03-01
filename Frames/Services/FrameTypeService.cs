namespace Frames.Services;

public class FrameTypeService(IRepositoryManager repositoryManager) : IFrameTypeService
{
    public async Task<List<FrameTypeDto>> GetFrameTypes()
    {
        var frameTypeEntity = await repositoryManager.FrameTypes.GetFrameTypes(false);
        var frameTypeDto = frameTypeEntity.Select(x => x.ToDto()).ToList();
        return frameTypeDto;
    }

    public async Task<List<string>> GetFrameTypeNames()
        => await repositoryManager.FrameTypes.GetFrameTypeNames();

    public async Task<FrameTypeDto> GetFrameTypeById(int frameTypeId)
    {
        var frameType = await repositoryManager.FrameTypes.GetFrameTypeById(frameTypeId, false);
        if (frameType is null)
        {
            throw new Exception($"Frame Type Id {frameTypeId} not found");
        }

        return frameType.ToDto();
    }
    
    public async Task CreateFrameType(FrameTypeDto newFrameType)
    {
        repositoryManager.FrameTypes.CreateNewFrameType(newFrameType.ToEntity());
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task UpdateFrameType(FrameTypeDto frameTypeDto)
    {
        var frameTypeEntity = frameTypeDto.ToEntity();
        frameTypeEntity.ModifiedDate = DateTime.Now;
        repositoryManager.FrameTypes.UpdateFrameType(frameTypeEntity);
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task RemoveFrameType(int frameTypeId)
    {
        repositoryManager.FrameTypes.RemoveFrameType(new FrameType { Id = frameTypeId });
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}