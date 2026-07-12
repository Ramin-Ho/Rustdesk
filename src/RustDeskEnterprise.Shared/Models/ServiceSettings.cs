namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// تنظیمات سرویس Windows
Windows Service configuration settings
/// </summary>
public class ServiceSettings
{
    /// <summary>
    /// آیا سرویس Windows فعال باشد؟
    /// Enable Windows Service
    /// </summary>
    [JsonPropertyName("enableService")]
    public bool EnableService { get; set; } = true;

    /// <summary>
    /// آیا سرویس به‌طور خودکار هنگام بوت شود؟
    /// Auto-start service on boot
    /// </summary>
    [JsonPropertyName("autoStart")]
    public bool AutoStart { get; set; } = true;

    /// <summary>
    /// نام سرویس Windows
    /// Windows Service name
    /// </summary>
    [JsonPropertyName("serviceName")]
    public string ServiceName { get; set; } = "RustDeskEnterpriseService";
}
