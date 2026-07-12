using RustDeskEnterprise.Shared.Enums;

namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// تنظیمات به‌روزرسانی
Update management settings
/// </summary>
public class UpdateSettings
{
    /// <summary>
    /// روش به‌روزرسانی
    /// Update method/mode
    /// </summary>
    [JsonPropertyName("mode")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UpdateMode Mode { get; set; } = UpdateMode.Offline;

    /// <summary>
    /// مسیر اشتراک‌گذاری محلی برای فایل‌های به‌روزرسانی
    /// Local share path for update files
    /// </summary>
    [JsonPropertyName("localSharePath")]
    public string? LocalSharePath { get; set; }

    /// <summary>
    /// آدرس URL برای دانلود به‌روزرسانی‌ها
    /// URL for downloading updates
    /// </summary>
    [JsonPropertyName("updateUrl")]
    public string? UpdateUrl { get; set; }

    /// <summary>
    /// بازه‌ی زمانی بررسی به‌روزرسانی‌ها (ساعت)
    /// Check for updates interval in hours
    /// </summary>
    [JsonPropertyName("checkIntervalHours")]
    public int CheckIntervalHours { get; set; } = 6;

    /// <summary>
    /// آیا به‌روزرسانی خودکار فعال باشد؟
    /// Enable automatic updates
    /// </summary>
    [JsonPropertyName("autoUpdateEnabled")]
    public bool AutoUpdateEnabled { get; set; } = false;
}
