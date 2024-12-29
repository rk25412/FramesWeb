namespace Frames.Contracts.Services;

public interface IMasterFrameInService
{
    Task<List<FrameInDto>> GetMasterFrameIns(int month, int year);
    Task<FrameInDto> GetMasterFrameIn(DateOnly date);
    Task CreateOrUpdateMasterFrameIn(FrameInDto frameInDto);
    Task DeleteMasterFrameIn(DateOnly date);
    Task DeleteMasterFrameIn(List<int> ids);
}