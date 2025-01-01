namespace Frames.Components.Pages;

public partial class MasterFrameOut : ComponentBase
{
    private readonly List<DropdownDto<int>> _monthDropdown = [];
    private readonly List<DropdownDto<int>> _yearDropdown = [];
    private int _selectedMonth;
    private int _selectedYear;
    private readonly List<FrameOutDto> _frameOutList = [];
    private RadzenDataGrid<FrameOutDto>? _grid0;
    private int _maxDataColCount;

    protected override async Task OnInitializedAsync()
    {
        _monthDropdown.AddRange(Utilities.GetDdlDataForMonths());
        _yearDropdown.AddRange(Utilities.GetDdlDataForYears());
        _selectedMonth = DateTime.Now.Month;
        _selectedYear = DateTime.Now.Year;

        await LoadGridData();
    }

    private async Task LoadGridData()
    {
        _frameOutList.Clear();
        var frameOutData = await ServiceManager.MasterFrameOutService.GetFrameOuts(_selectedMonth, _selectedYear);
        _frameOutList.AddRange(frameOutData);
        _maxDataColCount = _frameOutList.Count > 0 ? _frameOutList.Max(x => x.ItemsCount) : 0;
        _grid0?.Reload();
    }

    private async Task MonthYearDropdownChanged() => await LoadGridData();

    private async Task OnAddUpdateClick(FrameOutDto? dto = null)
    {
        await DialogService.OpenAsync<CreateOrUpdateMasterFrameOut>(
            "Add/Update Master Frame In",
            new Dictionary<string, object?>()
            {
                ["Date"] = dto?.Date ?? null,
            },
            new DialogOptions()
            {
                Width = "min(700px, 90%)",
                Height = "auto"
            });

        await LoadGridData();
    }

    private async Task OnRemoveClick(FrameOutDto dto)
    {
        var confirm = await DialogService.Confirm(
            $"Are you sure?",
            $"Delete all the records for {dto.Date}?");
        if (confirm is true)
        {
            await ServiceManager.MasterFrameOutService.DeleteFrameOuts(dto.Date);
            await LoadGridData();
        }
    }
}