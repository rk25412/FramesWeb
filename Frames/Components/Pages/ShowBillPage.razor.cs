using Microsoft.AspNetCore.Components;

namespace Frames.Components.Pages;

public partial class ShowBillPage
{
    [Parameter] public int Month { get; set; }
    [Parameter] public int Year { get; set; }

    private BillingDto? _billingDto;
    
    
    private bool _isLoaded = false;

    protected override void OnInitialized()
    {
        if ((Month is < 1 or > 12) || (Year > 2020 && Year < DateTime.Now.Year))
        {
            NavigationManager.NavigateTo("/", true);
            return;
        }
        
        InvokeAsync(async() => await LoadBill());
    }

    private async Task LoadBill()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _billingDto = await ServiceManager.BillingService.GetBillingData(Month, Year);
        await InvokeAsync(StateHasChanged);
        UtilityService.ToggleLoader();
    }
}