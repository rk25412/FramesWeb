namespace Frames.Components.Shared;

public partial class CreateOrUpdatePayment
{
    [Parameter] public DateOnly? Date { get; set; }
    private PaymentDto? _payment;

    protected override async Task OnInitializedAsync()
    {
        Date ??= DateOnly.FromDateTime(DateTime.Now);
        await GetData();
    }

    private async Task GetData()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _payment = await ServiceManager.PaymentsService.GetPayment(Date ?? DateOnly.FromDateTime(DateTime.Now));
        UtilityService.ToggleLoader();
    }

    private async Task OnSubmit(PaymentDto dto)
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        await ServiceManager.PaymentsService.CreateOrUpdatePayment(_payment!);
        UtilityService.ToggleLoader();
        CloseDialog();
    }
    
    
    private void CloseDialog() => DialogService.Close(true);
}