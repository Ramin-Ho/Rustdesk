namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel برای صفحه تنظیمات سازمان
ViewModel for Organization Settings page
/// </summary>
public partial class OrganizationSettingsViewModel : WizardPageViewModel
{
    /// <summary>
    /// نام سازمان
    /// Organization name
    /// </summary>
    [ObservableProperty]
    private string organizationName = "RustDesk Enterprise";

    /// <summary>
    /// مسیر لوگو
    /// Logo path
    /// </summary>
    [ObservableProperty]
    private string? logoPath;

    /// <summary>
    /// ایمیل پشتیبانی
    /// Support email
    /// </summary>
    [ObservableProperty]
    private string? supportEmail;

    /// <summary>
    /// شماره تلفن پشتیبانی
    /// Support phone
    /// </summary>
    [ObservableProperty]
    private string? supportPhone;

    public OrganizationSettingsViewModel()
    {
        Title = "Organization Settings";
        Description = "Configure your organization information";
    }

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    public override bool Validate()
    {
        if (string.IsNullOrWhiteSpace(OrganizationName))
        {
            ErrorMessage = "Organization name is required";
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
        OrganizationName = config.Organization.Name;
        LogoPath = config.Organization.LogoPath;
        SupportEmail = config.Organization.SupportEmail;
        SupportPhone = config.Organization.SupportPhone;
    }

    /// <summary>
    /// ذخیره تنظیمات در پیکربندی
    /// Save settings to configuration
    /// </summary>
    public override void SaveSettings(EnterpriseConfiguration config)
    {
        config.Organization.Name = OrganizationName;
        config.Organization.LogoPath = LogoPath;
        config.Organization.SupportEmail = SupportEmail;
        config.Organization.SupportPhone = SupportPhone;
    }
}
