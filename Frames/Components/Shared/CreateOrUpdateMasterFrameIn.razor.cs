namespace Frames.Components.Shared;

public partial class CreateOrUpdateMasterFrameIn : ComponentBase
{
    [Parameter] public DateOnly? Date { get; set; }

    private FrameInDto _frameInDto = new();
    private RadzenDataGrid<FrameInTimeAndCount>? _lineItemsGrid;
    private readonly List<int> _itemsToDelete = [];

    protected override async Task OnInitializedAsync()
    {
        Date ??= DateOnly.FromDateTime(DateTime.Now);
        await LoadFrameInData();
    }

    private async Task OnDateChange()
    {
        await LoadFrameInData();
    }

    private async Task LoadFrameInData()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _frameInDto = await ServiceManager.MasterFrameInService.GetMasterFrameIn(Date!.Value);
        _lineItemsGrid?.Reload();
        UtilityService.ToggleLoader();
    }

    private async Task OnSubmit(FrameInDto frameInDto)
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        await ServiceManager.MasterFrameInService.CreateOrUpdateMasterFrameIn(frameInDto);
        await ServiceManager.MasterFrameInService.RemoveMasterFrameIn(_itemsToDelete);
        UtilityService.ToggleLoader();
        CloseDialog();
    }

    private void CloseDialog() => DialogService.Close(true);

    private void OnAddRecordClick()
    {
        _frameInDto.InItems.Add(new FrameInTimeAndCount()
        {
            Time = TimeOnly.FromDateTime(DateTime.Now),
            Count = 1
        });
        _lineItemsGrid?.Reload();
    }

    private void OnRemoveRecordClick(FrameInTimeAndCount dto)
    {
        _frameInDto.InItems.Remove(dto);
        if (dto.Id is not 0)
        {
            _itemsToDelete.Add(dto.Id);
        }
        _lineItemsGrid?.Reload();
    }
}