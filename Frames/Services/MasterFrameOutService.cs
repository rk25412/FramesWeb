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
            switch (entity.Id)
            {
                case 0 when entity.MasterFrameOutTypes.Any(x => x.Count > 0):
                    repositoryManager.MasterFrameOuts.CreateMasterFrameOut(entity);
                    break;
                case > 0 when entity.MasterFrameOutTypes.Any(x => x.Count > 0):
                    var frameOutTypes = entity.MasterFrameOutTypes.ToList();
                    entity.MasterFrameOutTypes = [];
                    repositoryManager.MasterFrameOuts.UpdateMasterFrameOut(entity);
                    foreach (var frameOutType in frameOutTypes)
                    {
                        switch (frameOutType.Id)
                        {
                            case > 0 when frameOutType.Count <= 0:
                                repositoryManager.MasterFrameOutTypes.DeleteFrameOutType(frameOutType);
                                break;
                            case > 0 when frameOutType.Count > 0:
                                repositoryManager.MasterFrameOutTypes.UpdateFrameOutType(frameOutType);
                                break;
                            case 0:
                                repositoryManager.MasterFrameOutTypes.CreateFrameOutType(frameOutType);
                                break;
                        }
                    }
                    break;
                case > 0:
                    repositoryManager.MasterFrameOuts.RemoveMasterFramesOut(entity);
                    break;
            }
        }

        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task RemoveFrameOuts(DateOnly date)
    {
        repositoryManager.MasterFrameOuts.RemoveMasterFrameOutByDate(date);
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task RemoveFrameOuts(List<long> ids)
    {
        ids.ForEach(id => repositoryManager.MasterFrameOuts.RemoveMasterFramesOut(new MasterFrameOut { Id = id }));
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}