namespace Frames.Services;

public class MasterFrameOutService(IRepositoryManager repositoryManager) : IMasterFrameOutService
{
    public async Task<List<FrameOutDto>> GetFrameOuts(int month, int year)
    {
        var entities = await repositoryManager.MasterFrameOuts.GetMasterFrameOuts(month, year, false);
        var groupedByDateEntities = entities.GroupBy(x => x.DateTime.Date);
        var dtos = groupedByDateEntities.Select(x => x.ToList().ToDto()).ToList();
        return dtos;
    }

    public async Task<FrameOutDto> GetFrameOuts(DateOnly date)
    {
        var entities = await repositoryManager.MasterFrameOuts.GetMasterFrameOuts(date, false);
        var groupedByDateEntities = entities.GroupBy(x => x.DateTime.Date);
        var dtos = groupedByDateEntities.Select(x => x.ToList().ToDto()).ToList();
        return dtos.FirstOrDefault() ?? new FrameOutDto() { Date = date };
    }
}