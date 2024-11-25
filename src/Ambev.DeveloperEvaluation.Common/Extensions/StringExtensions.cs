namespace Ambev.DeveloperEvaluation.Common.Extensions;

public static class StringExtensions
{
    public static bool ValidGuid(this string value)
    {
        return Guid.TryParse(value, out _);
    }
}