namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// تنظیمات کاملِ سازمان
Complete enterprise configuration
/// </summary>
public class EnterpriseConfiguration
{
    /// <summary>
    /// تنظیمات سازمان
    /// Organization settings
    /// </summary>
    [JsonPropertyName("organization")]
    public OrganizationSettings Organization { get; set; } = new();

    /// <summary>
    /// تنظیمات سرور RustDesk
    /// RustDesk server settings
    /// </summary>
    [JsonPropertyName("rustDesk")]
    public RustDeskSettings RustDesk { get; set; } = new();

    /// <summary>
    /// تنظیمات به‌روزرسانی
    /// Update settings
    /// </summary>
    [JsonPropertyName("update")]
    public UpdateSettings Update { get; set; } = new();

    /// <summary>
    /// تنظیمات شبکه
    /// Network settings
    /// </summary>
    [JsonPropertyName("network")]
    public NetworkSettings Network { get; set; } = new();

    /// <summary>
    /// تنظیمات سرویس Windows
    /// Windows Service settings
    /// </summary>
    [JsonPropertyName("service")]
    public ServiceSettings Service { get; set; } = new();
}
