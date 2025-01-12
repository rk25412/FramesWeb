namespace Frames.Components.Pages;

public partial class Workers
{
    private readonly List<WorkerDto> _workers = [];
    private RadzenDataGrid<WorkerDto>? _workersGrid;

    protected override void OnInitialized()
    {
        InvokeAsync(async () => { await LoadWorkers(); });
    }

    private async Task LoadWorkers()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        _workers.Clear();
        var workers = await ServiceManager.WorkerService.GetWorkers();
        _workers.AddRange(workers);
        _workersGrid?.Reload();
        UtilityService.ToggleLoader();
    }

    private async Task OnAddWorkerClick()
    {
        await DialogService.OpenAsync<CreateOrEditWorker>(
            "Add Worker",
            null,
            new DialogOptions()
            {
                Width = "min(700px, 90%)",
                Height = "auto"
            });

        await LoadWorkers();
    }

    private async Task OnUpdateWorkerClick(WorkerDto workerDto)
    {
        await DialogService.OpenAsync<CreateOrEditWorker>(
            "Edit Worker",
            new Dictionary<string, object>()
            {
                ["WorkerId"] = workerDto.Id
            },
            new DialogOptions()
            {
                Width = "min(700px, 90%)",
                Height = "auto"
            });

        await LoadWorkers();
    }

    private async Task OnDeleteWorkerClick(WorkerDto workerDto)
    {
        var confirm = await DialogService.Confirm("Are you sure you want to delete this Worker?",
            $"Delete {workerDto.Name}");
        if (confirm is true)
        {
            await ServiceManager.WorkerService.RemoveWorker(workerDto.Id);
            await LoadWorkers();
        }
    }
}