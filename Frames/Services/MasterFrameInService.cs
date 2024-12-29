using Frames.Contracts.Repositories;
using Frames.Contracts.Services;

namespace Frames.Services;

public class MasterFrameInService(IRepositoryManager repositoryManager) : IMasterFrameInService
{
    public async Task<List<FrameInDto>> GetMasterFramesIn(int month, int year)
    {
        var entities = await repositoryManager.MasterFrameIns.GetMasterFrameIns(month, year, false);
        var groupedByDateEntities = entities.GroupBy(x => x.DateTime.Date);
        var dtos = groupedByDateEntities.Select(x => x.ToList().ToDto()).ToList();
        return dtos;
    }

    public async Task<FrameInDto> GetMasterFrameIn(DateOnly date)
    {
        var entities = await repositoryManager.MasterFrameIns.GetMasterFrameIns(date, false);
        var groupedByDateEntities = entities.GroupBy(x => x.DateTime.Date);
        var dtos = groupedByDateEntities.Select(x => x.ToList().ToDto()).ToList();
        return dtos.First();
    }
}