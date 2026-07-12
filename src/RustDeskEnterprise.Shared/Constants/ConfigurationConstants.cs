namespace RustDeskEnterprise.Shared.Constants;

/// <summary>
ثابت‌های تنظیمات برنامه
Application configuration constants
/// </summary>
public static class ConfigurationConstants
{
    /// <summary>
    /// نام فایل تنظیمات پیش‌فرض
    /// Default configuration file name
    /// </summary>
    public const string DefaultConfigFileName = "appsettings.json";

    /// <summary>
    /// مسیر پیش‌فرض برای داده‌های برنامه
    /// Default data directory path
    /// </summary>
    public const string DefaultDataPath = @"C:\ProgramData\RustDeskEnterprise";

    /// <summary>
    /// مسیر پیش‌فرض برای فایل‌های لاگ
    /// Default logs directory path
    /// </summary>
    public const string DefaultLogsPath = @"C:\ProgramData\RustDeskEnterprise\Logs";

    /// <summary>
    /// حداقل مقدار برای بازه‌ی زمانی بررسی‌های به‌روزرسانی (ساعت)
    /// Minimum value for update check interval in hours
    /// </summary>
    public const int MinUpdateIntervalHours = 1;

    /// <summary>
    /// حداکثر مقدار برای بازه‌ی زمانی بررسی‌های به‌روزرسانی (ساعت)
    /// Maximum value for update check interval in hours
    /// </summary>
    public const int MaxUpdateIntervalHours = 720; // 30 days

    /// <summary>
    /// مقدار پیش‌فرض برای بازه‌ی زمانی بررسی‌های به‌روزرسانی (ساعت)
    /// Default update check interval in hours
    /// </summary>
    public const int DefaultUpdateIntervalHours = 6;

    /// <summary>
    /// حداقل مقدار برای timeout شبکه (ثانیه)
    /// Minimum network timeout in seconds
    /// </summary>
    public const int MinNetworkTimeoutSeconds = 5;

    /// <summary>
    /// حداکثر مقدار برای timeout شبکه (ثانیه)
    /// Maximum network timeout in seconds
    /// </summary>
    public const int MaxNetworkTimeoutSeconds = 300;

    /// <summary>
    /// مقدار پیش‌فرض برای timeout شبکه (ثانیه)
    /// Default network timeout in seconds
    /// </summary>
    public const int DefaultNetworkTimeoutSeconds = 30;

    /// <summary>
    /// نام پیش‌فرض سرویس Windows
    /// Default Windows service name
    /// </summary>
    public const string DefaultServiceName = "RustDeskEnterpriseService";

    /// <summary>
    /// نام پیش‌فرض سرویس RustDesk
    /// Default RustDesk service name
    /// </summary>
    public const string RustDeskServiceName = "rustdesk";
}
