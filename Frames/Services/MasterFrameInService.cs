using Frames.Contracts.Repositories;
using Frames.Contracts.Services;

namespace Frames.Services;

public class MasterFrameInService(IRepositoryManager repositoryManager) : IMasterFrameInService
{
    public async Task<List<FrameInDto>> GetMasterFrameIns(int month, int year)
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
        return dtos.FirstOrDefault() ?? new FrameInDto() { Date = date };
    }

    public async Task CreateOrUpdateMasterFrameIn(FrameInDto frameInDto)
    {
        var entities = frameInDto.ToEntity();
        foreach (var item in entities)
        {
            if (item.Id is 0)
                repositoryManager.MasterFrameIns.CreateMasterFrameIn(item);
            else
                repositoryManager.MasterFrameIns.UpdateMasterFrameIn(item);
        }

        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task DeleteMasterFrameIn(DateOnly date)
    {
        var itemsToDelete = await repositoryManager.MasterFrameIns.GetMasterFrameIns(date, false);
        itemsToDelete.ForEach(x => repositoryManager.MasterFrameIns.DeleteMasterFrameIn(x));
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }

    public async Task DeleteMasterFrameIn(List<int> ids)
    {
        ids.ForEach(x => repositoryManager.MasterFrameIns.DeleteMasterFrameIn(new() { Id = x }));
        await repositoryManager.SaveAsync();
        repositoryManager.Detach();
    }
}