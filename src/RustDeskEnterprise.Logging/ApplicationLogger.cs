using Serilog;
using ILogger = Serilog.ILogger;

namespace RustDeskEnterprise.Logging;

/// <summary>
/// پیاده‌سازی سیستم ثبت‌سازی برنامه با استفاده از Serilog
/// Implementation of application logging system using Serilog
/// </summary>
public sealed class ApplicationLogger : IApplicationLogger
{
    private readonly ILogger _logger;
    private readonly string _contextName;

    /// <summary>
    /// سازنده برای ایجاد نمونه جدید از ApplicationLogger
    /// Constructor to create a new instance of ApplicationLogger
    /// </summary>
    /// <param name="contextName">نام متن برای نشان‌دادن منبع لاگ / Context name for identifying log source</param>
    public ApplicationLogger(string contextName)
    {
        _contextName = contextName ?? throw new ArgumentNullException(nameof(contextName));
        _logger = Log.ForContext("SourceContext", _contextName);
    }

    /// <summary>
    /// ثبت یک پیام اطلاعاتی
    /// Log an information message
    /// </summary>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    public void LogInformation(string message, params object[] args)
    {
        try
        {
            if (args.Length > 0)
            {
                _logger.Information(message, args);
            }
            else
            {
                _logger.Information(message);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "خطا در ثبت‌سازی پیام اطلاعاتی / Error logging information message");
        }
    }

    /// <summary>
    /// ثبت یک پیام هشدار
    /// Log a warning message
    /// </summary>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    public void LogWarning(string message, params object[] args)
    {
        try
        {
            if (args.Length > 0)
            {
                _logger.Warning(message, args);
            }
            else
            {
                _logger.Warning(message);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "خطا در ثبت‌سازی پیام هشدار / Error logging warning message");
        }
    }

    /// <summary>
    /// ثبت یک پیام خطا
    /// Log an error message
    /// </summary>
    /// <param name="exception">استثنایی که رخ داده است / Exception that occurred</param>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    public void LogError(Exception? exception, string message, params object[] args)
    {
        try
        {
            if (args.Length > 0)
            {
                _logger.Error(exception, message, args);
            }
            else
            {
                _logger.Error(exception, message);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "خطا در ثبت‌سازی پیام خطا / Error logging error message");
        }
    }

    /// <summary>
    /// ثبت یک پیام خطای بحرانی
    /// Log a fatal error message
    /// </summary>
    /// <param name="exception">استثنایی که رخ داده است / Exception that occurred</param>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    public void LogFatal(Exception? exception, string message, params object[] args)
    {
        try
        {
            if (args.Length > 0)
            {
                _logger.Fatal(exception, message, args);
            }
            else
            {
                _logger.Fatal(exception, message);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "خطا در ثبت‌سازی پیام خطای بحرانی / Error logging fatal message");
        }
    }

    /// <summary>
    /// ثبت یک پیام اشکال‌زدایی (فقط در حالت توسعه)
    /// Log a debug message (development only)
    /// </summary>
    /// <param name="message">متن پیام / Message text</param>
    /// <param name="args">آرگومان‌های قالب / Format arguments</param>
    public void LogDebug(string message, params object[] args)
    {
        try
        {
            if (args.Length > 0)
            {
                _logger.Debug(message, args);
            }
            else
            {
                _logger.Debug(message);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "خطا در ثبت‌سازی پیام اشکال‌زدایی / Error logging debug message");
        }
    }
}
