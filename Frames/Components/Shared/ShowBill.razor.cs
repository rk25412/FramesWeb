namespace Frames.Components.Shared;

public partial class ShowBill : ComponentBase
{
    [Parameter] public int Month { get; set; }
    [Parameter] public int Year { get; set; }
    [Inject] public required IConfiguration Configuration { get; set; }

    private DateTime BillMonth;
    private BillingDto? _billingData;
    private readonly List<string> _mainItems = [];

    protected override async Task OnInitializedAsync()
    {
        BillMonth = new DateTime(Year, Month, 1);
        _mainItems.AddRange(Configuration["MainItems"]!.Split(','));
        await LodBillingData();
    }

    private async Task LodBillingData()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _billingData = await ServiceManager.BillingService.GetBillingData(Month, Year);
        UtilityService.ToggleLoader();
    }
}