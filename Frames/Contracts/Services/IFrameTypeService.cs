namespace Frames.Contracts.Services;

public interface IFrameTypeService
{
    Task<List<FrameTypeDto>> GetFrameTypes();
    Task<List<string>> GetFrameTypeNames();
    Task CreateFrameType(FrameTypeDto newFrameType);
    Task<FrameTypeDto> GetFrameTypeById(int frameTypeId);
    Task UpdateFrameType(FrameTypeDto frameType);
    Task DeleteFrameType(int frameTypeId);
}