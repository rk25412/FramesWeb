namespace Frames.Components.Shared;

public partial class AddUpdateMasterFrameOut : ComponentBase
{
    [Parameter] public DateOnly? Date { get; set; }

    private readonly List<FrameTypeDto> _frameTypes = [];
    private FrameOutDto _frameOutDto = new();
    private RadzenDataGrid<FrameOutTimeDto>? _lineItemsGrid;
    private readonly List<int> _itemsToDelete = [];

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

    private async Task OnSubmit()
    {
        await ServiceManager.MasterFrameOutService.CreateFrameOuts(_frameOutDto);
        Cancel();
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
        _lineItemsGrid?.Reload();
    }

    private void OnRemoveRecordClick(FrameOutTimeDto dto)
    {
        if (dto.Id is not 0)
        {
            _itemsToDelete.Add(dto.Id);
        }

        _frameOutDto.FrameOutTimeDtos.Remove(dto);
    }

    private void Cancel() => DialogService.Close(true);
}