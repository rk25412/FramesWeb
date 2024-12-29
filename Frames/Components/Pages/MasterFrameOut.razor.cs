namespace Frames.Components.Pages;

public partial class MasterFrameOut : ComponentBase
{
    private readonly List<DropdownDto<int>> _monthDropdown = [];
    private readonly List<DropdownDto<int>> _yearDropdown = [];
    private int _selectedMonth;
    private int _selectedYear;

    protected override async Task OnInitializedAsync()
    {
        _monthDropdown.AddRange(Utilities.GetDdlDataForMonths());
        _yearDropdown.AddRange(Utilities.GetDdlDataForYears());
        _selectedMonth = DateTime.Now.Month;
        _selectedYear = DateTime.Now.Year;

        await LoadGridData();
    }
    
    private async Task MonthYearDropdownChanged() => await LoadGridData();

    private async Task LoadGridData()
    {
        
    }
}