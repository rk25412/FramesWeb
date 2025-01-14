using Microsoft.JSInterop;

namespace Frames.Components.Shared;

public partial class ShowBill : ComponentBase
{
    [Parameter] public int Month { get; set; }
    [Parameter] public int Year { get; set; }
    [Inject] public required IJSRuntime Js { get; set; } = null!;
    [Inject] public required IConfiguration Configuration { get; set; }
    [Inject] public required IServiceProvider ServiceProvider { get; set; }
    [Inject] public required ILoggerFactory LoggerFactory { get; set; }

    private DateTime _billMonth = DateTime.Now;
    private BillingDto? _billingData;
    private readonly List<string> _mainItems = [];
    private int _noOfDays;
    private readonly List<BillingItemDto> _itemsOtherThanMain = [];

    protected override async Task OnInitializedAsync()
    {
        _billMonth = new DateTime(Year, Month, 1);
        _noOfDays = DateTime.DaysInMonth(Year, Month);
        _mainItems.AddRange(Configuration["MainItems"]!.Split(','));
        await LodBillingData();
    }

    private async Task LodBillingData()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _billingData = await ServiceManager.BillingService.GetBillingData(Month, Year);
        _itemsOtherThanMain.AddRange(_billingData.BillingItems.Where(x => !_mainItems.Contains(x.Name))
            .OrderByDescending(x => x.TotalCount));
        UtilityService.ToggleLoader();
    }

    private async Task DownloadPdf()
    {
        await using var htmlRenderer =
            new Microsoft.AspNetCore.Components.Web.HtmlRenderer(ServiceProvider, LoggerFactory);

        var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            var dictionary = new Dictionary<string, object?>
            {
                ["BillingDto"] = _billingData!
            };
            var parameters = ParameterView.FromDictionary(dictionary);
            var output = await htmlRenderer.RenderComponentAsync<ShowBill>(parameters);
            return output.ToHtmlString();
        });

        await Js.InvokeVoidAsync("createPdf", html);
    }
}