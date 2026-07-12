using Serilog;
using Serilog.Events;

namespace RustDeskEnterprise.Logging;

/// <summary>
/// پیکربندی و راه‌اندازی سیستم ثبت‌سازی Serilog
/// Configuration and initialization of Serilog logging system
/// </summary>
public static class LoggerConfiguration
{
    /// <summary>
    /// مسیر پیش‌فرض ذخیره‌سازی فایل‌های لاگ
    /// Default path for storing log files
    /// </summary>
    private const string DefaultLogPath = @"C:\ProgramData\RustDeskEnterprise\Logs";

    /// <summary>
    /// الگوی نام فایل لاگ روزانه
    /// Daily log file naming pattern
    /// </summary>
    private const string DailyLogFilePattern = "RustDeskEnterprise-.txt";

    /// <summary>
    /// راه‌اندازی و پیکربندی سیستم ثبت‌سازی سراسری
    /// Initialize and configure the global logging system
    /// </summary>
    /// <param name="isDevelopment">آیا برنامه در حالت توسعه است / Whether the application is in development mode</param>
    /// <param name="customLogPath">مسیر سفارشی برای ذخیره‌سازی لاگ‌ها / Custom path for log storage</param>
    /// <exception cref="DirectoryNotFoundException">اگر دایرکتوری مشخص‌شده وجود نداشته باشد / If specified directory does not exist</exception>
    public static void ConfigureLogging(bool isDevelopment = false, string? customLogPath = null)
    {
        var logPath = customLogPath ?? DefaultLogPath;

        try
        {
            // ایجاد دایرکتوری لاگ در صورت عدم وجود
            // Create log directory if it doesn't exist
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }
        catch (Exception ex)
        {
            throw new DirectoryNotFoundException($"خطا در ایجاد دایرکتوری لاگ: {logPath}. Error creating log directory: {logPath}", ex);
        }

        var logFilePath = Path.Combine(logPath, DailyLogFilePattern);

        var loggerConfig = new Serilog.LoggerConfiguration()
            .MinimumLevel.Is(isDevelopment ? LogEventLevel.Debug : LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                path: logFilePath,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30,
                fileSizeLimitBytes: 104857600, // 100 MB
                rollOnFileSizeLimit: true,
                shared: true
            );

        Log.Logger = loggerConfig.CreateLogger();
    }

    /// <summary>
    /// بستن و تخلیه تمام منابع ثبت‌سازی
    /// Close and flush all logging resources
    /// </summary>
    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }
}
