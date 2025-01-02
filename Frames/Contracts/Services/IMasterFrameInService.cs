namespace Frames.Contracts.Services;

public interface IMasterFrameInService
{
    Task<List<FrameInDto>> GetMasterFrameIns(int month, int year);
    Task<FrameInDto> GetMasterFrameIn(DateOnly date);
    Task CreateOrUpdateMasterFrameIn(FrameInDto frameInDto);
    Task RemoveMasterFrameIn(DateOnly date);
    Task RemoveMasterFrameIn(List<int> ids);
}