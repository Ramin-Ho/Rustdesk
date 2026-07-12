namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel برای صفحه تنظیمات سرویس Windows
ViewModel for Windows Service Settings page
/// </summary>
public partial class ServiceSettingsViewModel : WizardPageViewModel
{
    /// <summary>
    /// فعال‌سازی سرویس
    /// Enable service
    /// </summary>
    [ObservableProperty]
    private bool enableService = true;

    /// <summary>
    /// شروع خودکار
    /// Auto start
    /// </summary>
    [ObservableProperty]
    private bool autoStart = true;

    /// <summary>
    /// نام سرویس
    /// Service name
    /// </summary>
    [ObservableProperty]
    private string serviceName = "RustDeskEnterpriseService";

    public ServiceSettingsViewModel()
    {
        Title = "Windows Service Settings";
        Description = "Configure background service";
    }

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    public override bool Validate()
    {
        if (string.IsNullOrWhiteSpace(ServiceName))
        {
            ErrorMessage = "Service name is required";
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
        EnableService = config.Service.EnableService;
        AutoStart = config.Service.AutoStart;
        ServiceName = config.Service.ServiceName;
    }

    /// <summary>
    /// ذخیره تنظیمات در پیکربندی
    /// Save settings to configuration
    /// </summary>
    public override void SaveSettings(EnterpriseConfiguration config)
    {
        config.Service.EnableService = EnableService;
        config.Service.AutoStart = AutoStart;
        config.Service.ServiceName = ServiceName;
    }
}
