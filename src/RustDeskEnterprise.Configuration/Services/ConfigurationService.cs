using System.Text.Json;

namespace RustDeskEnterprise.Configuration.Services;

/// <summary>
/// سرویس برای مدیریت تنظیمات برنامه
Service for managing application configuration
/// </summary>
public sealed class ConfigurationService : IConfigurationService
{
    private readonly string _configPath;
    private readonly IValidator<EnterpriseConfiguration> _validator;

    /// <summary>
    /// سازنده‌ی ConfigurationService
    /// Constructor for ConfigurationService
    /// </summary>
    /// <param name="configPath">مسیر فایل تنظیمات / Path to configuration file</param>
    /// <param name="validator">اعتبارسنج تنظیمات / Configuration validator</param>
    /// <exception cref="ArgumentNullException">اگر پارامتر null باشد / If parameter is null</exception>
    public ConfigurationService(string configPath, IValidator<EnterpriseConfiguration> validator)
    {
        _configPath = configPath ?? throw new ArgumentNullException(nameof(configPath));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    /// <summary>
    /// بارگذاری تنظیمات از فایل JSON
    /// Load configuration from JSON file
    /// </summary>
    /// <returns>تنظیمات سازمان / Enterprise configuration</returns>
    /// <exception cref="ConfigurationException">هنگام خواندن یا پردازش فایل / When reading or processing the file</exception>
    public async Task<EnterpriseConfiguration> LoadAsync()
    {
        try
        {
            // اگر فایل وجود ندارد، تنظیمات پیش‌فرض ایجاد کن
            // Create default configuration if file doesn't exist
            if (!File.Exists(_configPath))
            {
                var defaultConfig = new EnterpriseConfiguration();
                await SaveAsync(defaultConfig);
                return defaultConfig;
            }

            // فایل را بخوان و parse کن
            // Read and parse the file
            var json = await File.ReadAllTextAsync(_configPath);
            var config = JsonSerializer.Deserialize<EnterpriseConfiguration>(json);

            if (config == null)
            {
                throw new ConfigurationException(
                    "فایل تنظیمات نامعتبر است / Configuration file is invalid");
            }

            return config;
        }
        catch (JsonException ex)
        {
            throw new ConfigurationException(
                $"خطا در تجزیه‌ی JSON: {ex.Message} / Error parsing JSON: {ex.Message}", ex);
        }
        catch (IOException ex)
        {
            throw new ConfigurationException(
                $"خطا در خواندن فایل تنظیمات: {ex.Message} / Error reading configuration file: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ConfigurationException(
                $"خطای نامشخص هنگام بارگذاری تنظیمات: {ex.Message} / Unknown error loading configuration: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// ذخیره‌ی تنظیمات در فایل JSON
    /// Save configuration to JSON file
    /// </summary>
    /// <param name="configuration">تنظیمات برای ذخیره‌سازی / Configuration to save</param>
    /// <exception cref="ArgumentNullException">اگر configuration null باشد / If configuration is null</exception>
    /// <exception cref="ConfigurationException">هنگام نوشتن فایل / When writing the file</exception>
    public async Task SaveAsync(EnterpriseConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        try
        {
            // اطمینان حاصل کن که دایرکتوری وجود دارد
            // Ensure directory exists
            var directory = Path.GetDirectoryName(_configPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // تنظیمات را serialize کن
            // Serialize configuration
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(configuration, options);

            // فایل را بنویس
            // Write file
            await File.WriteAllTextAsync(_configPath, json);
        }
        catch (IOException ex)
        {
            throw new ConfigurationException(
                $"خطا در نوشتن فایل تنظیمات: {ex.Message} / Error writing configuration file: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ConfigurationException(
                $"خطای نامشخص هنگام ذخیره‌سازی تنظیمات: {ex.Message} / Unknown error saving configuration: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// اعتبارسنجی تنظیمات
    /// Validate configuration
    /// </summary>
    /// <param name="configuration">تنظیمات برای اعتبارسنجی / Configuration to validate</param>
    /// <returns>آیا تنظیمات معتبر است / Whether configuration is valid</returns>
    /// <exception cref="ArgumentNullException">اگر configuration null باشد / If configuration is null</exception>
    public async Task<bool> ValidateAsync(EnterpriseConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        return await Task.FromResult(_validator.Validate(configuration));
    }
}
