namespace Frames.Components.Pages;

public partial class FrameTypes
{
    private readonly List<FrameTypeDto> _frameTypesList = [];
    private RadzenDataGrid<FrameTypeDto>? _frameTypeGrid;

    protected override void OnInitialized()
    {
        InvokeAsync(async () => { await LoadFrameTypes(); });
    }

    private async Task LoadFrameTypes()
    {
        _frameTypesList.Clear();
        var framesList = await ServiceManager.FrameTypeService.GetFrameTypes();
        _frameTypesList.AddRange(framesList);
        _frameTypeGrid?.Reload();
    }

    private async Task OnAddFrameTypeClick()
    {
        await DialogService.OpenAsync<CreateOrUpdateFrameType>(
            "Add Frame Type",
            null,
            new DialogOptions()
            {
                Width = "min(700px, 90%)",
                Height = "auto"
            });

        await LoadFrameTypes();
    }

    private async Task OnUpdateFrameTypeClick(FrameTypeDto frameType)
    {
        await DialogService.OpenAsync<CreateOrUpdateFrameType>(
            "Edit Frame Type",
            new Dictionary<string, object>()
            {
                { "FrameTypeId", frameType.Id }
            },
            new DialogOptions()
            {
                Width = "min(700px, 90%)",
                Height = "auto"
            });

        await LoadFrameTypes();
    }

    private async Task OnDeleteClick(FrameTypeDto frameType)
    {
        var confirm = await DialogService.Confirm("Are you sure you want to delete this frame type?",
            $"Delete {frameType.Name}");
        if (confirm is true)
        {
            await ServiceManager.FrameTypeService.RemoveFrameType(frameType.Id);
            await LoadFrameTypes();
        }
    }
}