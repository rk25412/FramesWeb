namespace Frames.Components.Shared;

public partial class CreateOrEditWorker
{
    [Parameter] public int WorkerId { get; set; }

    private WorkerDto? _workerDto;
    private readonly List<string> _workerNames = [];

    protected override async Task OnInitializedAsync()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        var workerNames = await ServiceManager.WorkerService.GetWorkerNames();
        if (WorkerId is 0)
        {
            _workerDto = new WorkerDto();
        }
        else
        {
            var worker = await ServiceManager.WorkerService.GetWorkerById(WorkerId);
            _workerDto = worker;
            workerNames = workerNames
                .Where(x => !x.Equals(_workerDto?.Name, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        _workerNames.AddRange(workerNames);
        UtilityService.ToggleLoader();
    }
    
    private void CloseDialog() => DialogService.Close(true);
    
    private bool ValidateNewWorkerName(string newWorkerName)
        => !_workerNames.Contains(newWorkerName, StringComparer.InvariantCultureIgnoreCase);

    private async Task OnSubmit(WorkerDto workerDto)
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        if (WorkerId is 0)
            await ServiceManager.WorkerService.CreateWorker(workerDto);
        else
            await ServiceManager.WorkerService.UpdateWorker(workerDto);

        UtilityService.ToggleLoader();
        CloseDialog();
    }
}