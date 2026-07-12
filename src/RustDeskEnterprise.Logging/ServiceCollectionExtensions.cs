using Microsoft.Extensions.DependencyInjection;

namespace RustDeskEnterprise.Logging;

/// <summary>
/// متد‌های توسعه برای کانتینر تزریق وابستگی‌ها
/// Extension methods for dependency injection container
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// اضافه کردن سرویس‌های ثبت‌سازی به کانتینر تزریق وابستگی‌ها
    /// Add logging services to the dependency injection container
    /// </summary>
    /// <param name="services">کانتینر سرویس‌ها / Service container</param>
    /// <param name="isDevelopment">آیا برنامه در حالت توسعه است / Whether the application is in development mode</param>
    /// <param name="customLogPath">مسیر سفارشی برای ذخیره‌سازی لاگ‌ها / Custom path for log storage</param>
    /// <returns>کانتینر سرویس‌ها برای زنجیرسازی / Service container for chaining</returns>
    public static IServiceCollection AddApplicationLogging(
        this IServiceCollection services,
        bool isDevelopment = false,
        string? customLogPath = null)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        // پیکربندی Serilog
        // Configure Serilog
        LoggerConfiguration.ConfigureLogging(isDevelopment, customLogPath);

        // ثبت factory برای ایجاد نمونه‌های IApplicationLogger
        // Register factory for creating IApplicationLogger instances
        services.AddSingleton<Func<string, IApplicationLogger>>(
            contextName => new ApplicationLogger(contextName));

        // ثبت سرویس سازنده برای ایجاد logger‌ها
        // Register factory service for creating loggers
        services.AddSingleton<ILoggerFactory, ApplicationLoggerFactory>();

        return services;
    }
}
