using RustDeskEnterprise.Shared.Models;

namespace RustDeskEnterprise.Shared.Interfaces;

/// <summary>
/// رابط سرویس تنظیمات
Interface for configuration service
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// بارگذاری تنظیمات از فایل
    /// Load configuration from file
    /// </summary>
    /// <returns>تنظیمات سازمان / Enterprise configuration</returns>
    /// <exception cref="Exception">هنگام خواندن یا پردازش فایل / When reading or processing the file</exception>
    Task<EnterpriseConfiguration> LoadAsync();

    /// <summary>
    /// ذخیره‌ی تنظیمات در فایل
    /// Save configuration to file
    /// </summary>
    /// <param name="configuration">تنظیمات برای ذخیره‌سازی / Configuration to save</param>
    /// <exception cref="ArgumentNullException">اگر configuration null باشد / If configuration is null</exception>
    /// <exception cref="Exception">هنگام نوشتن فایل / When writing the file</exception>
    Task SaveAsync(EnterpriseConfiguration configuration);

    /// <summary>
    /// اعتبارسنجی تنظیمات
    /// Validate configuration
    /// </summary>
    /// <param name="configuration">تنظیمات برای اعتبارسنجی / Configuration to validate</param>
    /// <returns>آیا تنظیمات معتبر است / Whether configuration is valid</returns>
    Task<bool> ValidateAsync(EnterpriseConfiguration configuration);
}
