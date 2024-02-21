namespace Poc.Nasa.Portal.Domain.Shared;

public static class Utils
{
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;

        return value.Substring(0, Math.Min(value.Length, maxLength));
    }
}