using RustDeskEnterprise.Shared.Enums;

namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// اطلاعات نسخه RustDesk
RustDesk version information
/// </summary>
public class RustDeskVersionInfo
{
    /// <summary>
    /// نسخه‌ی RustDesk
    /// RustDesk version
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// مسیر نصب
    /// Installation path
    /// </summary>
    [JsonPropertyName("installPath")]
    public string? InstallPath { get; set; }

    /// <summary>
    /// تاریخ نصب
    /// Installation date
    /// </summary>
    [JsonPropertyName("installDate")]
    public DateTime? InstallDate { get; set; }

    /// <summary>
    /// معماری سیستم
    /// System architecture
    /// </summary>
    [JsonPropertyName("architecture")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Architecture Architecture { get; set; } = Architecture.X64;
}
