namespace Frames.Services;

public class UtilityService
{
    public Action? ToggleLoaderAction { get; set; }
    public Action? StateChangeAction { get; set; }

    public void ToggleLoader()
    {
        ToggleLoaderAction?.Invoke();
        StateChangeAction?.Invoke();
    }
}