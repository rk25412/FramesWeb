namespace Frames.Components.Shared;

public partial class AddEditFrameType
{
    [Parameter] public int FrameTypeId { get; set; }

    private FrameTypeDto? _newFrameType;
    private readonly List<string> _frameNames = [];

    protected override async Task OnInitializedAsync()
    {
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
    }

    private void Cancel() => DialogService.Close(true);

    private bool ValidateNewFrameName(string name)
        => !_frameNames.Contains(name, StringComparer.InvariantCultureIgnoreCase);

    private async Task OnSubmit(FrameTypeDto newFrameType)
    {
        if (FrameTypeId is 0)
            await ServiceManager.FrameTypeService.CreateFrameType(newFrameType);
        else
            await ServiceManager.FrameTypeService.UpdateFrameType(newFrameType);

        Cancel();
    }
}