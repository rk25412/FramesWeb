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

    public async Task CreateOrUpdateFrameOuts(FrameOutDto dto)
    {
        var entities = dto.ToEntity();
        foreach (var entity in entities)
        {
            if (entity.Id is 0)
                repositoryManager.MasterFrameOuts.CreateMasterFrameOut(entity);
            else
                repositoryManager.MasterFrameOuts.UpdateMasterFrameOut(entity);
        }

        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task DeleteFrameOuts(DateOnly date)
    {
        repositoryManager.MasterFrameOuts.RemoveMasterFrameOutByDate(date);
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}