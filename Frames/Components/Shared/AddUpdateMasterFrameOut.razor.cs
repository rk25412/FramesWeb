namespace Frames.Components.Shared;

public partial class AddUpdateMasterFrameOut : ComponentBase
{
    [Parameter] public DateOnly? Date { get; set; }

    private readonly List<FrameTypeDto> _frameTypes = [];
    private FrameOutDto _frameOutDto = new();
    private RadzenDataGrid<FrameOutTimeDto>? _lineItemsGrid;

    protected override async Task OnInitializedAsync()
    {
        Date ??= DateOnly.FromDateTime(DateTime.Now);
        _frameTypes.AddRange(await ServiceManager.FrameTypeService.GetFrameTypes());
        await LoadFrameOutData();
    }

    private async Task LoadFrameOutData()
    {
        _frameOutDto = await ServiceManager.MasterFrameOutService.GetFrameOuts(Date!.Value);
    }

    private void OnSubmit()
    {
    }

    private async Task OnDateChange()
    {
        await LoadFrameOutData();
    }

    private void OnAddRecordClick()
    {
        _frameOutDto.FrameOutTimeDtos.Add(new FrameOutTimeDto
        {
            Time = TimeOnly.FromDateTime(DateTime.Now),
            FrameOutTypes = _frameTypes.Select(x => new FrameOutTypeDto()
            {
                Count = 0,
                FrameTypeId = x.Id,
                FrameName = x.Name,
                FrameRate = x.MasterRate ?? 0m
            }).ToList()
        });
    }

    private void OnRemoveRecordClick(FrameOutTimeDto dto)
    {
        _frameOutDto.FrameOutTimeDtos.Remove(dto);
    }
}