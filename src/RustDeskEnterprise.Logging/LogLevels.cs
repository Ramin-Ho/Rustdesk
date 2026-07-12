namespace RustDeskEnterprise.Logging;

/// <summary>
/// سطح‌های ثبت‌سازی که برنامه از آنها استفاده می‌کند
/// Logging levels used by the application
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// اطلاعات عمومی
    /// General information
    /// </summary>
    Information,

    /// <summary>
    /// هشدار‌ها
    /// Warnings
    /// </summary>
    Warning,

    /// <summary>
    /// خطاها
    /// Errors
    /// </summary>
    Error,

    /// <summary>
    /// خطاهای بحرانی
    /// Fatal errors
    /// </summary>
    Fatal,

    /// <summary>
    /// اطلاعات تفصیلی (فقط در حالت توسعه)
    /// Debug information (development only)
    /// </summary>
    Debug
}
