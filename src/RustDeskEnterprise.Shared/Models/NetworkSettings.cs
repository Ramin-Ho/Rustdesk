namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// تنظیمات شبکه
Network configuration settings
/// </summary>
public class NetworkSettings
{
    /// <summary>
    /// آدرس سرور proxy
    /// Proxy server address
    /// </summary>
    [JsonPropertyName("proxyAddress")]
    public string? ProxyAddress { get; set; }

    /// <summary>
    /// نام‌کاربری برای proxy
    /// Proxy username
    /// </summary>
    [JsonPropertyName("proxyUsername")]
    public string? ProxyUsername { get; set; }

    /// <summary>
    /// رمز عبور برای proxy
    /// Proxy password
    /// </summary>
    [JsonPropertyName("proxyPassword")]
    public string? ProxyPassword { get; set; }

    /// <summary>
    /// مدت‌زمان timeout برای درخواست‌های شبکه (ثانیه)
    /// Network request timeout in seconds
    /// </summary>
    [JsonPropertyName("timeoutSeconds")]
    public int TimeoutSeconds { get; set; } = 30;
}
