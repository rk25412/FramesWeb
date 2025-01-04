namespace Frames.Components.Pages;

public partial class MasterFrameIn
{
    private readonly List<FrameInDto> _frameInlist = [];
    private readonly List<DropdownDto<int>> _monthDropdown = [];
    private readonly List<DropdownDto<int>> _yearDropdown = [];
    private int _selectedMonth;
    private int _selectedYear;
    private RadzenDataGrid<FrameInDto>? _grid0;
    private int _maxDataColCount;

    protected override void OnInitialized()
    {
        InvokeAsync(async () =>
        {
            _monthDropdown.AddRange(Utilities.GetDdlDataForMonths());
            _yearDropdown.AddRange(Utilities.GetDdlDataForYears());
            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
            await LoadGridData();
        });
    }

    private async Task MonthYearDropdownChanged() => await LoadGridData();

    private async Task LoadGridData()
    {
        _frameInlist.Clear();
        var data = await ServiceManager.MasterFrameInService.GetMasterFrameIns(_selectedMonth, _selectedYear);
        _frameInlist.AddRange(data);
        _maxDataColCount = _frameInlist.Count > 0 ? _frameInlist.Max(x => x.ItemsCount) : 0;
        _grid0?.Reload();
    }

    private async Task OnAddUpdateMasterInClick(FrameInDto? dto = null)
    {
        await DialogService.OpenAsync<CreateOrUpdateMasterFrameIn>(
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

    private async Task OnRemoveMasterInClick(FrameInDto dto)
    {
        var confirm = await DialogService.Confirm($"Are you sure you want to delete records for {dto.Date}?",
            $"Delete {dto.Date}");
        if (confirm is true)
        {
            await ServiceManager.MasterFrameInService.RemoveMasterFrameIn(dto.Date);
            await LoadGridData();
        }
    }
}