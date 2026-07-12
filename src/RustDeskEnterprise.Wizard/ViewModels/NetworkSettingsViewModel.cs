namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel برای صفحه تنظیمات شبکه
ViewModel for Network Settings page
/// </summary>
public partial class NetworkSettingsViewModel : WizardPageViewModel
{
    /// <summary>
    /// آدرس سرور proxy
    /// Proxy server address
    /// </summary>
    [ObservableProperty]
    private string? proxyAddress;

    /// <summary>
    /// نام‌کاربری proxy
    /// Proxy username
    /// </summary>
    [ObservableProperty]
    private string? proxyUsername;

    /// <summary>
    /// رمز عبور proxy
    /// Proxy password
    /// </summary>
    [ObservableProperty]
    private string? proxyPassword;

    /// <summary>
    /// مهلت‌زمان درخواست (ثانیه)
    /// Timeout in seconds
    /// </summary>
    [ObservableProperty]
    private int timeoutSeconds = 30;

    public NetworkSettingsViewModel()
    {
        Title = "Network Settings";
        Description = "Configure network parameters";
    }

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    public override bool Validate()
    {
        if (TimeoutSeconds < 5 || TimeoutSeconds > 300)
        {
            ErrorMessage = "Timeout must be between 5 and 300 seconds";
            IsValid = false;
            return false;
        }

        IsValid = true;
        ErrorMessage = null;
        return true;
    }

    /// <summary>
    /// بارگذاری تنظیمات از پیکربندی
    /// Load settings from configuration
    /// </summary>
    public override void LoadSettings(EnterpriseConfiguration config)
    {
        ProxyAddress = config.Network.ProxyAddress;
        ProxyUsername = config.Network.ProxyUsername;
        ProxyPassword = config.Network.ProxyPassword;
        TimeoutSeconds = config.Network.TimeoutSeconds;
    }

    /// <summary>
    /// ذخیره تنظیمات در پیکربندی
    /// Save settings to configuration
    /// </summary>
    public override void SaveSettings(EnterpriseConfiguration config)
    {
        config.Network.ProxyAddress = ProxyAddress;
        config.Network.ProxyUsername = ProxyUsername;
        config.Network.ProxyPassword = ProxyPassword;
        config.Network.TimeoutSeconds = TimeoutSeconds;
    }
}
