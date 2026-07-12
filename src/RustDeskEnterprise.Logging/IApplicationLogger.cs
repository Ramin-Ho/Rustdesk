namespace RustDeskEnterprise.Logging;

/// <summary>
/// رابط برای سیستم ثبت‌سازی برنامه
/// Interface for application logging system
/// </summary>
public interface IApplicationLogger
{
    /// <summary>
    /// ثبت یک پیام اطلاعاتی
    /// Log an information message
    /// </summary>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    void LogInformation(string message, params object[] args);

    /// <summary>
    /// ثبت یک پیام هشدار
    /// Log a warning message
    /// </summary>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    void LogWarning(string message, params object[] args);

    /// <summary>
    /// ثبت یک پیام خطا
    /// Log an error message
    /// </summary>
    /// <param name="exception">استثنایی که رخ داده است / Exception that occurred</param>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    void LogError(Exception? exception, string message, params object[] args);

    /// <summary>
    /// ثبت یک پیام خطای بحرانی
    /// Log a fatal error message
    /// </summary>
    /// <param name="exception">استثنایی که رخ داده است / Exception that occurred</param>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    void LogFatal(Exception? exception, string message, params object[] args);

    /// <summary>
    /// ثبت یک پیام اشکال‌زدایی (فقط در حالت توسعه)
    /// Log a debug message (development only)
    /// </summary>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    void LogDebug(string message, params object[] args);
}
