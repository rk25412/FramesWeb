namespace Frames.Contracts.Services;

public interface IMasterFrameOutService
{
    Task<List<FrameOutDto>> GetFrameOuts(int month, int year);
    Task<FrameOutDto> GetFrameOuts(DateOnly date);
    Task CreateOrUpdateFrameOuts(FrameOutDto dto);
    Task RemoveFrameOuts(DateOnly date);
    Task RemoveFrameOuts(List<int> ids);
}