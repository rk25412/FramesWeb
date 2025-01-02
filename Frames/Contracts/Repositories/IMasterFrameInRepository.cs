namespace Frames.Contracts.Repositories;

public interface IMasterFrameInRepository
{
    Task<List<MasterFrameIn>> GetMasterFrameIns(int month, int year, bool trackChanges);
    Task<List<MasterFrameIn>> GetMasterFrameIns(DateOnly date, bool trackChanges);
    Task<MasterFrameIn?> GetMasterFrameIn(int id, bool trackChanges);
    void CreateMasterFrameIn(MasterFrameIn masterFrameIn);
    void UpdateMasterFrameIn(MasterFrameIn masterFrameIn);
    void RemoveMasterFrameIn(MasterFrameIn masterFrameIn);
}