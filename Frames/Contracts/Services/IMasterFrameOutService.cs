namespace Frames.Contracts.Services;

public interface IMasterFrameOutService
{
    Task<List<FrameOutDto>> GetFrameOuts(int month, int year);
    Task<FrameOutDto> GetFrameOuts(DateOnly date);
    Task CreateFrameOuts(FrameOutDto dto);
    Task DeleteFrameOuts(DateOnly date);
}