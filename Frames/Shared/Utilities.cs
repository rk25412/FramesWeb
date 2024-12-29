using System.Globalization;

namespace Frames.Shared;

public static class Utilities
{
    public static List<DropdownDto<int>> GetDdlDataForMonths()
        => DateTimeFormatInfo.CurrentInfo.MonthNames
            .Select((x, i) => new DropdownDto<int>() { Value = i + 1, Text = x }).ToList();

    public static List<DropdownDto<int>> GetDdlDataForYears() =>
    [
        new DropdownDto<int>() { Value = 2020, Text = "2020" },
        new DropdownDto<int>() { Value = 2021, Text = "2021" },
        new DropdownDto<int>() { Value = 2022, Text = "2022" },
        new DropdownDto<int>() { Value = 2023, Text = "2023" },
        new DropdownDto<int>() { Value = 2024, Text = "2024" },
        new DropdownDto<int>() { Value = 2025, Text = "2025" },
        new DropdownDto<int>() { Value = 2026, Text = "2026" },
        new DropdownDto<int>() { Value = 2027, Text = "2027" },
        new DropdownDto<int>() { Value = 2028, Text = "2028" },
        new DropdownDto<int>() { Value = 2029, Text = "2029" },
    ];
}