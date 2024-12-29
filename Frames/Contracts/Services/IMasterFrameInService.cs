namespace Frames.Contracts.Services;

public interface IMasterFrameInService
{
    Task<List<FrameInDto>> GetMasterFramesIn(int month, int year);
    Task<FrameInDto> GetMasterFrameIn(DateOnly date);
}