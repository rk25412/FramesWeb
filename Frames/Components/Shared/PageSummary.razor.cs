namespace Frames.Components.Shared;

public partial class PageSummary
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public string? HeaderTitle { get; set; }
    
    private string _id = Guid.NewGuid().ToString();
}