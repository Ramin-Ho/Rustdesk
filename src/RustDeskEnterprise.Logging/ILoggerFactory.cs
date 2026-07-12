namespace RustDeskEnterprise.Logging;

/// <summary>
/// رابط سازنده برای ایجاد نمونه‌های logger
/// Factory interface for creating logger instances
/// </summary>
public interface ILoggerFactory
{
    /// <summary>
    /// ایجاد ی�� نمونه جدید از logger برای متن مشخص‌شده
    /// Create a new logger instance for the specified context
    /// </summary>
    /// <param name="contextName">نام متن برای نشان‌دادن منبع لاگ / Context name for identifying log source</param>
    /// <returns>نمونه جدید از IApplicationLogger / New instance of IApplicationLogger</returns>
    IApplicationLogger CreateLogger(string contextName);

    /// <summary>
    /// ایجاد یک نمونه جدید از logger برای نوع مشخص‌شده
    /// Create a new logger instance for the specified type
    /// </summary>
    /// <typeparam name="T">نوع برای استفاده به عنوان نام متن / Type to use as context name</typeparam>
    /// <returns>نمونه جدید از IApplicationLogger / New instance of IApplicationLogger</returns>
    IApplicationLogger CreateLogger<T>();
}
