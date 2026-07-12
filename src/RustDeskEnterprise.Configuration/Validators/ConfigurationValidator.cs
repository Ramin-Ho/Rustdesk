namespace RustDeskEnterprise.Configuration.Validators;

/// <summary>
/// اعتبارسنج برای تنظیمات سازمان
Validator for enterprise configuration
/// </summary>
public sealed class ConfigurationValidator : IValidator<EnterpriseConfiguration>
{
    private readonly List<string> _errors = new();

    /// <summary>
    /// اعتبارسنجی تنظیمات کاملِ سازمان
    /// Validate complete enterprise configuration
    /// </summary>
    /// <param name="obj">تنظیمات برای اعتبارسنجی / Configuration to validate</param>
    /// <returns>آیا تنظیمات معتبر است / Whether configuration is valid</returns>
    public bool Validate(EnterpriseConfiguration obj)
    {
        _errors.Clear();

        if (obj == null)
        {
            _errors.Add("تنظیمات null است / Configuration is null");
            return false;
        }

        ValidateRustDeskSettings(obj.RustDesk);
        ValidateUpdateSettings(obj.Update);
        ValidateNetworkSettings(obj.Network);
        ValidateServiceSettings(obj.Service);
        ValidateOrganizationSettings(obj.Organization);

        return _errors.Count == 0;
    }

    /// <summary>
    /// دریافت پیام‌های خطای اعتبارسنجی
    /// Get validation error messages
    /// </summary>
    /// <returns>لیست پیام‌های خطا / List of error messages</returns>
    public IEnumerable<string> GetErrors() => _errors.AsReadOnly();

    /// <summary>
    /// اعتبارسنجی تنظیمات RustDesk
    /// Validate RustDesk settings
    /// </summary>
    private void ValidateRustDeskSettings(RustDeskSettings settings)
    {
        if (settings == null)
        {
            _errors.Add("تنظیمات RustDesk null است / RustDesk settings is null");
            return;
        }

        if (string.IsNullOrWhiteSpace(settings.IdServer))
        {
            _errors.Add("سرور شناسایی (ID Server) نمی‌تواند خالی باشد / ID Server cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(settings.RelayServer))
        {
            _errors.Add("سرور رله (Relay Server) نمی‌تواند خالی باشد / Relay Server cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(settings.PublicKey))
        {
            _errors.Add("کلید عمومی نمی‌تواند خالی باشد / Public Key cannot be empty");
        }
    }

    /// <summary>
    /// اعتبارسنجی تنظیمات به‌روزرسانی
    /// Validate update settings
    /// </summary>
    private void ValidateUpdateSettings(UpdateSettings settings)
    {
        if (settings == null)
        {
            _errors.Add("تنظیمات به‌روزرسانی null است / Update settings is null");
            return;
        }

        if (settings.CheckIntervalHours < ConfigurationConstants.MinUpdateIntervalHours ||
            settings.CheckIntervalHours > ConfigurationConstants.MaxUpdateIntervalHours)
        {
            _errors.Add(
                $"بازه‌ی زمانی بررسی به‌روزرسانی باید بین {ConfigurationConstants.MinUpdateIntervalHours} " +
                $"و {ConfigurationConstants.MaxUpdateIntervalHours} ساعت باشد / " +
                $"Update check interval must be between {ConfigurationConstants.MinUpdateIntervalHours} " +
                $"and {ConfigurationConstants.MaxUpdateIntervalHours} hours");
        }
    }

    /// <summary>
    /// اعتبارسنجی تنظیمات شبکه
    /// Validate network settings
    /// </summary>
    private void ValidateNetworkSettings(NetworkSettings settings)
    {
        if (settings == null)
        {
            _errors.Add("تنظیمات شبکه null است / Network settings is null");
            return;
        }

        if (settings.TimeoutSeconds < ConfigurationConstants.MinNetworkTimeoutSeconds ||
            settings.TimeoutSeconds > ConfigurationConstants.MaxNetworkTimeoutSeconds)
        {
            _errors.Add(
                $"timeout شبکه باید بین {ConfigurationConstants.MinNetworkTimeoutSeconds} " +
                $"و {ConfigurationConstants.MaxNetworkTimeoutSeconds} ثانیه باشد / " +
                $"Network timeout must be between {ConfigurationConstants.MinNetworkTimeoutSeconds} " +
                $"and {ConfigurationConstants.MaxNetworkTimeoutSeconds} seconds");
        }
    }

    /// <summary>
    /// اعتبارسنجی تنظیمات سرویس
    /// Validate service settings
    /// </summary>
    private void ValidateServiceSettings(ServiceSettings settings)
    {
        if (settings == null)
        {
            _errors.Add("تنظیمات سرویس null است / Service settings is null");
            return;
        }

        if (string.IsNullOrWhiteSpace(settings.ServiceName))
        {
            _errors.Add("نام سرویس نمی‌تواند خالی باشد / Service name cannot be empty");
        }
    }

    /// <summary>
    /// اعتبارسنجی تنظیمات سازمان
    /// Validate organization settings
    /// </summary>
    private void ValidateOrganizationSettings(OrganizationSettings settings)
    {
        if (settings == null)
        {
            _errors.Add("تنظیمات سازمان null است / Organization settings is null");
            return;
        }

        if (string.IsNullOrWhiteSpace(settings.Name))
        {
            _errors.Add("نام سازمان نمی‌تواند خالی باشد / Organization name cannot be empty");
        }
    }
}
