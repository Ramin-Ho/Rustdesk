namespace RustDeskEnterprise.Logging;

/// <summary>
/// سازنده برای ایجاد نمونه‌های IApplicationLogger
/// Factory for creating IApplicationLogger instances
/// </summary>
public sealed class ApplicationLoggerFactory : ILoggerFactory
{
    private readonly Func<string, IApplicationLogger> _loggerFactory;

    /// <summary>
    /// سازنده برای ایجاد نمونه جدید از ApplicationLoggerFactory
    /// Constructor to create a new instance of ApplicationLoggerFactory
    /// </summary>
    /// <param name="loggerFactory">تابع سازنده برای ایجاد logger‌ها / Factory function for creating loggers</param>
    public ApplicationLoggerFactory(Func<string, IApplicationLogger> loggerFactory)
    {
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
    }

    /// <summary>
    /// ایجاد یک نمونه جدید از logger برای متن مشخص‌شده
    /// Create a new logger instance for the specified context
    /// </summary>
    /// <param name="contextName">نام متن برای نشان‌دادن منبع لاگ / Context name for identifying log source</param>
    /// <returns>نمونه جدید از IApplicationLogger / New instance of IApplicationLogger</returns>
    public IApplicationLogger CreateLogger(string contextName)
    {
        if (string.IsNullOrWhiteSpace(contextName))
        {
            throw new ArgumentException("نام متن نمی‌تواند خالی باشد / Context name cannot be empty", nameof(contextName));
        }

        return _loggerFactory(contextName);
    }

    /// <summary>
    /// ایجاد یک نمونه جدید از logger برای نوع مشخص‌شده
    /// Create a new logger instance for the specified type
    /// </summary>
    /// <typeparam name="T">نوع برای استفاده به عنوان نام متن / Type to use as context name</typeparam>
    /// <returns>نمونه جدید از IApplicationLogger / New instance of IApplicationLogger</returns>
    public IApplicationLogger CreateLogger<T>()
    {
        var contextName = typeof(T).FullName ?? typeof(T).Name;
        return CreateLogger(contextName);
    }
}
