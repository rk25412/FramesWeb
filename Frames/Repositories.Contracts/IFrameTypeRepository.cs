namespace Frames.Repositories.Contracts;

public interface IFrameTypeRepository
{
    Task<List<FrameType>> GetFrameTypes(bool trackChanges);
    Task<List<string>> GetFrameTypeNames();
    Task<FrameType?> GetFrameTypeById(int id, bool trackChanges);
    void AddNewFrameType(FrameType frameType);
    void UpdateFrameType(FrameType frameType);
    void DeleteFrameType(int frameTypeId);
}