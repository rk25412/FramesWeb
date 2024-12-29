namespace Frames.Contracts.Repositories;

public interface IMasterFrameOutRepository
{
    Task<List<MasterFrameOut>> GetMasterFrameOuts(int month, int year, bool trackChanges);
}