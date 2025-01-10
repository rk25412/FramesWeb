using Microsoft.AspNetCore.Components;

namespace Frames.Components.Pages;

public partial class Billing : ComponentBase
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

        await GetBillingSummary();
    }

    private async Task GetBillingSummary()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);


        UtilityService.ToggleLoader();
    }

    private async Task CalculateBilling()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        
        
        UtilityService.ToggleLoader();
    }

    private async Task MonthYearDropdownChanged() => await GetBillingSummary();
}