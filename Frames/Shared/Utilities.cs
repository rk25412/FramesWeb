using System.Globalization;

namespace Frames.Shared;

public static class Utilities
{
    public static List<DropdownDto<int>> GetDdlDataForMonths()
        => DateTimeFormatInfo.CurrentInfo.MonthNames
            .Select((x, i) => new DropdownDto<int>() { Value = i + 1, Text = x }).ToList();

    public static List<DropdownDto<int>> GetDdlDataForYears()
    {
        var maxYear = DateTime.Now.Year;

        var ddlDataForYears = new List<DropdownDto<int>>();
        for (var i = 0; i < 5; i++)
        {
            ddlDataForYears.Add(new DropdownDto<int>() { Value = maxYear - i, Text = (maxYear - i).ToString() });
        }

        return ddlDataForYears;
    }
}