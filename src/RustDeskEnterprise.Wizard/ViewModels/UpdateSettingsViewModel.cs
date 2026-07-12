namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel برای صفحه تنظیمات به‌روزرسانی
ViewModel for Update Settings page
/// </summary>
public partial class UpdateSettingsViewModel : WizardPageViewModel
{
    /// <summary>
    /// روش به‌روزرسانی
    /// Update mode
    /// </summary>
    [ObservableProperty]
    private UpdateMode updateMode = UpdateMode.Offline;

    /// <summary>
    /// آدرس URL برای به‌روزرسانی
    /// URL for updates
    /// </summary>
    [ObservableProperty]
    private string? updateUrl;

    /// <summary>
    /// مسیر اشتراک‌گذاری محلی
    /// Local share path
    /// </summary>
    [ObservableProperty]
    private string? localSharePath;

    /// <summary>
    /// بازه‌ی زمانی بررسی (ساعت)
    /// Check interval in hours
    /// </summary>
    [ObservableProperty]
    private int checkIntervalHours = 6;

    /// <summary>
    /// فعال‌سازی به‌روزرسانی خودکار
    /// Enable auto update
    /// </summary>
    [ObservableProperty]
    private bool autoUpdateEnabled = false;

    public UpdateSettingsViewModel()
    {
        Title = "Update Settings";
        Description = "Configure update mechanism";
    }

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    public override bool Validate()
    {
        if (UpdateMode == UpdateMode.Online && string.IsNullOrWhiteSpace(UpdateUrl))
        {
            ErrorMessage = "Update URL is required for online updates";
            IsValid = false;
            return false;
        }

        if (UpdateMode == UpdateMode.LocalShare && string.IsNullOrWhiteSpace(LocalSharePath))
        {
            ErrorMessage = "Local share path is required";
            IsValid = false;
            return false;
        }

        if (CheckIntervalHours < 1 || CheckIntervalHours > 720)
        {
            ErrorMessage = "Check interval must be between 1 and 720 hours";
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
        UpdateMode = config.Update.Mode;
        UpdateUrl = config.Update.UpdateUrl;
        LocalSharePath = config.Update.LocalSharePath;
        CheckIntervalHours = config.Update.CheckIntervalHours;
        AutoUpdateEnabled = config.Update.AutoUpdateEnabled;
    }

    /// <summary>
    /// ذخیره تنظیمات در پیکربندی
    /// Save settings to configuration
    /// </summary>
    public override void SaveSettings(EnterpriseConfiguration config)
    {
        config.Update.Mode = UpdateMode;
        config.Update.UpdateUrl = UpdateUrl;
        config.Update.LocalSharePath = LocalSharePath;
        config.Update.CheckIntervalHours = CheckIntervalHours;
        config.Update.AutoUpdateEnabled = AutoUpdateEnabled;
    }
}
