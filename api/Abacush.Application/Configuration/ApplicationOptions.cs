namespace Abacush.Application.Configuration;

public sealed class ApplicationOptions
{
    public const string SectionName = "Application";

    public string ApplicationName { get; set; } = "Abacush";

    public string TimeZone { get; set; } = "UTC";
}
