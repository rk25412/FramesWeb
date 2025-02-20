namespace Frames.Components.Pages;

public partial class BillingPage : ComponentBase
{
    private readonly List<DropdownDto<int>> _monthDropdown = [];
    private readonly List<DropdownDto<int>> _yearDropdown = [];
    private int _selectedMonth;
    private int _selectedYear;
    
    private BillingSummaryDto? _billingSummaryDto;

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

        _billingSummaryDto = await ServiceManager.BillingService.GetBillingSummary(_selectedMonth, _selectedYear);

        UtilityService.ToggleLoader();
    }

    private async Task CalculateBilling()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        
        await ServiceManager.BillingService.CalculateBilling(_selectedMonth, _selectedYear);
        UtilityService.ToggleLoader();
    }

    private async Task MonthYearDropdownChanged() => await GetBillingSummary();

    private void OpenBill()
    {
        NavigationManager.NavigateTo($"/show-bill/{_billingSummaryDto!.Month}/{_billingSummaryDto!.Year}");
        //
        //
        // await DialogService.OpenAsync<ShowBill>("Billing",
        //     new Dictionary<string, object>()
        //     {
        //         ["Month"] = _billingSummaryDto!.Month,
        //         ["Year"] = _billingSummaryDto!.Year,
        //     },
        //     new DialogOptions()
        //     {
        //         Width = "min(800px, 90%)",
        //         Height = "auto"
        //     });
    }
}