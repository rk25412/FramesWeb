namespace Frames.Contracts.Services;

public interface IFrameTypeService
{
    Task<List<FrameTypeDto>> GetFrameTypes();
    Task<List<string>> GetFrameTypeNames();
    Task<FrameTypeDto> GetFrameTypeById(int frameTypeId);
    Task CreateFrameType(FrameTypeDto newFrameType);
    Task UpdateFrameType(FrameTypeDto frameType);
    Task RemoveFrameType(int frameTypeId);
}