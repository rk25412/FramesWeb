using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.JSInterop;
using Path = System.IO.Path;

namespace Frames.Components.Shared;

public partial class ShowBill : ComponentBase
{
    [Parameter] public int? Month { get; set; }
    [Parameter] public int? Year { get; set; }
    [Parameter] public BillingDto? BillingDto { get; set; }
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
        if (BillingDto == null)
        {
            _billMonth = new DateTime(Year!.Value, Month!.Value, 1);
            _noOfDays = DateTime.DaysInMonth(Year!.Value, Month!.Value);
            _mainItems.AddRange(Configuration["MainItems"]!.Split(','));
            await LodBillingData();
        }
        else
        {
            _billingData = BillingDto;
            Year = _billingData.Year;
            Month = _billingData.Month;
            _mainItems.AddRange(Configuration["MainItems"]!.Split(','));
            _billMonth = new DateTime(_billingData.Year, _billingData.Month, 1);
            _noOfDays = DateTime.DaysInMonth(Year.Value, Month.Value);
        }
    }

    private async Task LodBillingData()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _billingData = await ServiceManager.BillingService.GetBillingData(Month!.Value, Year!.Value);
        _itemsOtherThanMain.AddRange(_billingData.BillingItems.Where(x => !_mainItems.Contains(x.Name))
            .OrderByDescending(x => x.TotalCount));
        _itemsOtherThanMain.Add(_itemsOtherThanMain[^1]);
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

        using var memoryStream = new MemoryStream();
        await using var pdfWriter = new PdfWriter(memoryStream);
        using var document = new PdfDocument(pdfWriter);
        document.SetDefaultPageSize(PageSize.A4);
        HtmlConverter.ConvertToPdf(html, document, new ConverterProperties());
        // using var streamRef = new DotNetStreamReference(stream: memoryStream);
        // await Js.InvokeVoidAsync("downloadFile", $"{_billMonth:yyyy-MM}.pdf", streamRef);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "billing.pdf");
        await File.WriteAllBytesAsync(filePath, memoryStream.ToArray());
    }
}