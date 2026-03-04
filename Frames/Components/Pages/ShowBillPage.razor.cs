using Microsoft.AspNetCore.Components;

namespace Frames.Components.Pages;

public partial class ShowBillPage
{
    [Parameter] public int Month { get; set; }
    [Parameter] public int Year { get; set; }
    
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
        _isLoaded = false;
        
        UtilityService.ToggleLoader();
        
        
        
        UtilityService.ToggleLoader();
        
        _isLoaded = true;
    }
}