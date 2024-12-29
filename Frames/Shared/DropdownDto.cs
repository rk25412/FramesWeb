namespace Frames.Shared;

public class DropdownDto<T>
{
    public required T Value { get; set; }
    public required string Text { get; set; }
}