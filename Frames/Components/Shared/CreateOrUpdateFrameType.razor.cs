namespace Frames.Components.Shared;

public partial class CreateOrUpdateFrameType
{
    [Parameter] public int FrameTypeId { get; set; }

    private FrameTypeDto? _newFrameType;
    private readonly List<string> _frameNames = [];

    protected override async Task OnInitializedAsync()
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        var frameNames = await ServiceManager.FrameTypeService.GetFrameTypeNames();
        if (FrameTypeId == 0)
        {
            _newFrameType = new FrameTypeDto();
        }
        else
        {
            var frameType = await ServiceManager.FrameTypeService.GetFrameTypeById(FrameTypeId);
            _newFrameType = frameType;
            frameNames = frameNames
                .Where(x => !x.Equals(_newFrameType?.Name, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        _frameNames.AddRange(frameNames);
        UtilityService.ToggleLoader();
    }

    private void CloseDialog() => DialogService.Close(true);

    private bool ValidateNewFrameName(string name)
        => !_frameNames.Contains(name, StringComparer.InvariantCultureIgnoreCase);

    private async Task OnSubmit(FrameTypeDto newFrameType)
    {
        UtilityService.ToggleLoader();
        await Task.Delay(1);
        if (FrameTypeId is 0)
            await ServiceManager.FrameTypeService.CreateFrameType(newFrameType);
        else
            await ServiceManager.FrameTypeService.UpdateFrameType(newFrameType);

        UtilityService.ToggleLoader();
        CloseDialog();
    }
}