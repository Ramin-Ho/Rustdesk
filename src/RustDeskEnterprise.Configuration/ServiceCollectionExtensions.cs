using Microsoft.Extensions.DependencyInjection;
using RustDeskEnterprise.Configuration.Services;
using RustDeskEnterprise.Configuration.Validators;

namespace RustDeskEnterprise.Configuration;

/// <summary>
/// متد‌های تمدید برای تزریق وابستگی
Extension methods for dependency injection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// اضافه‌کردن سرویس‌های تنظیمات به کانتینر تزریق وابستگی
    /// Add configuration services to dependency injection container
    /// </summary>
    /// <param name="services">کانتینر سرویس‌ها / Service container</param>
    /// <param name="configPath">مسیر فایل تنظیمات / Path to configuration file</param>
    /// <returns>کانتینر سرویس‌ها برای زنجیرسازی / Service container for chaining</returns>
    /// <exception cref="ArgumentNullException">اگر services یا configPath null باشد / If services or configPath is null</exception>
    public static IServiceCollection AddConfigurationServices(
        this IServiceCollection services,
        string configPath)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (string.IsNullOrWhiteSpace(configPath))
        {
            throw new ArgumentNullException(nameof(configPath));
        }

        // ثبت validator
        // Register validator
        services.AddSingleton<IValidator<EnterpriseConfiguration>, ConfigurationValidator>();

        // ثبت configuration service
        // Register configuration service
        services.AddSingleton<IConfigurationService>(sp =>
            new ConfigurationService(
                configPath,
                sp.GetRequiredService<IValidator<EnterpriseConfiguration>>()));

        return services;
    }
}
