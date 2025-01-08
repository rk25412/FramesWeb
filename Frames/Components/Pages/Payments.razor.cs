using Microsoft.AspNetCore.Components;

namespace Frames.Components.Pages;

public partial class Payments : ComponentBase
{
    private readonly List<PaymentDto> _payments = [];
    private readonly List<DropdownDto<int>> _monthDropdown = [];
    private readonly List<DropdownDto<int>> _yearDropdown = [];
    private RadzenDataGrid<PaymentDto>? _grid0;
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

    private async Task LoadGridData()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _payments.Clear();
        var payments = await ServiceManager.PaymentsService.GetPayments(_selectedMonth, _selectedYear);
        _payments.AddRange(payments);
        _grid0?.Reload();
        UtilityService.ToggleLoader();
    }

    private async Task MonthYearDropdownChanged() => await LoadGridData();

    private async Task OnAddUpdateClick(PaymentDto? paymentDto = null)
    {
        await DialogService.OpenAsync<CreateOrUpdatePayment>(
            "Add/Update payment",
            new Dictionary<string, object?>()
            {
                ["Date"] = paymentDto?.Date
            },
            new DialogOptions()
            {
                Width = "min(700px, 90%)",
                Height = "auto"
            });

        await LoadGridData();
    }

    private async Task OnRemoveClick(PaymentDto paymentDto)
    {
        var confirm = await DialogService.Confirm("Are you sure, you want to delete this payment?",
            $"Delete Payment for {paymentDto.Date}?");
        if (confirm is true)
        {
            await ServiceManager.PaymentsService.RemovePayment(paymentDto.Id);
            await LoadGridData();
        }
    }
}