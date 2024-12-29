namespace Frames.Contracts.Repositories;

public interface IFrameTypeRepository
{
    Task<List<FrameType>> GetFrameTypes(bool trackChanges);
    Task<List<string>> GetFrameTypeNames();
    Task<FrameType?> GetFrameTypeById(int id, bool trackChanges);
    void CreateNewFrameType(FrameType frameType);
    void UpdateFrameType(FrameType frameType);
    void DeleteFrameType(FrameType frameType);
}