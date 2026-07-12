namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel برای صفحه تنظیمات ساخت بسته
ViewModel for Package Builder Settings page
/// </summary>
public partial class PackageBuilderSettingsViewModel : WizardPageViewModel
{
    /// <summary>
    /// دایرکتوری خروجی
    /// Output directory
    /// </summary>
    [ObservableProperty]
    private string outputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    /// <summary>
    /// نام بسته
    /// Package name
    /// </summary>
    [ObservableProperty]
    private string packageName = "RustDeskEnterprise";

    /// <summary>
    /// شماره نسخه
    /// Version number
    /// </summary>
    [ObservableProperty]
    private string versionNumber = "1.0.0";

    /// <summary>
    /// ایجاد بسته EXE
    /// Create EXE package
    /// </summary>
    [ObservableProperty]
    private bool createExe = true;

    /// <summary>
    /// ایجاد بسته MSI
    /// Create MSI package
    /// </summary>
    [ObservableProperty]
    private bool createMsi = true;

    /// <summary>
    /// ایجاد بسته قابل‌حمل
    /// Create portable package
    /// </summary>
    [ObservableProperty]
    private bool createPortable = false;

    public PackageBuilderSettingsViewModel()
    {
        Title = "Package Builder Settings";
        Description = "Configure package creation options";
    }

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    public override bool Validate()
    {
        if (string.IsNullOrWhiteSpace(OutputDirectory))
        {
            ErrorMessage = "Output directory is required";
            IsValid = false;
            return false;
        }

        if (string.IsNullOrWhiteSpace(PackageName))
        {
            ErrorMessage = "Package name is required";
            IsValid = false;
            return false;
        }

        if (string.IsNullOrWhiteSpace(VersionNumber))
        {
            ErrorMessage = "Version number is required";
            IsValid = false;
            return false;
        }

        if (!CreateExe && !CreateMsi && !CreatePortable)
        {
            ErrorMessage = "At least one package type must be selected";
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
        // Package builder settings are not in the configuration yet
        // This is a placeholder for future integration
    }

    /// <summary>
    /// ذخیره تنظیمات در پیکربندی
    /// Save settings to configuration
    /// </summary>
    public override void SaveSettings(EnterpriseConfiguration config)
    {
        // Package builder settings are not in the configuration yet
        // This is a placeholder for future integration
    }
}
