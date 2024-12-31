namespace Frames.Contracts.Repositories;

public interface IMasterFrameOutRepository
{
    Task<List<MasterFrameOut>> GetMasterFrameOuts(int month, int year, bool trackChanges);
    Task<List<MasterFrameOut>> GetMasterFrameOuts(DateOnly date, bool trackChanges);
}