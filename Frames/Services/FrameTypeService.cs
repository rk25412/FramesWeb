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

    public async Task CreateFrameType(FrameTypeDto newFrameType)
    {
        repositoryManager.FrameTypes.CreateNewFrameType(newFrameType.ToEntity());
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task<FrameTypeDto> GetFrameTypeById(int frameTypeId)
    {
        var frameType = await repositoryManager.FrameTypes.GetFrameTypeById(frameTypeId, false);
        if (frameType is null)
        {
            throw new Exception($"Frame Type Id {frameTypeId} not found");
        }

        return frameType.ToDto();
    }

    public async Task UpdateFrameType(FrameTypeDto frameTypeDto)
    {
        repositoryManager.FrameTypes.UpdateFrameType(frameTypeDto.ToEntity());
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task DeleteFrameType(int frameTypeId)
    {
        repositoryManager.FrameTypes.DeleteFrameType(new() { Id = frameTypeId });
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}