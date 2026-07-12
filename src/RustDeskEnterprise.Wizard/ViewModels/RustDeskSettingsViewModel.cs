namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel برای صفحه تنظیمات سرور RustDesk
ViewModel for RustDesk Server Settings page
/// </summary>
public partial class RustDeskSettingsViewModel : WizardPageViewModel
{
    /// <summary>
    /// سرور شناسایی
    /// ID Server
    /// </summary>
    [ObservableProperty]
    private string idServer = "rustdesk";

    /// <summary>
    /// سرور رله
    /// Relay Server
    /// </summary>
    [ObservableProperty]
    private string relayServer = "rustdesk";

    /// <summary>
    /// کلید عمومی
    /// Public Key
    /// </summary>
    [ObservableProperty]
    private string publicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM";

    /// <summary>
    /// رمز عبور
    /// Password
    /// </summary>
    [ObservableProperty]
    private string? password;

    public RustDeskSettingsViewModel()
    {
        Title = "RustDesk Server Settings";
        Description = "Configure RustDesk server information";
    }

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    public override bool Validate()
    {
        if (string.IsNullOrWhiteSpace(IdServer))
        {
            ErrorMessage = "ID Server cannot be empty";
            IsValid = false;
            return false;
        }

        if (string.IsNullOrWhiteSpace(RelayServer))
        {
            ErrorMessage = "Relay Server cannot be empty";
            IsValid = false;
            return false;
        }

        if (string.IsNullOrWhiteSpace(PublicKey))
        {
            ErrorMessage = "Public Key cannot be empty";
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
        IdServer = config.RustDesk.IdServer;
        RelayServer = config.RustDesk.RelayServer;
        PublicKey = config.RustDesk.PublicKey;
        Password = config.RustDesk.Password;
    }

    /// <summary>
    /// ذخیره تنظیمات در پیکربندی
    /// Save settings to configuration
    /// </summary>
    public override void SaveSettings(EnterpriseConfiguration config)
    {
        config.RustDesk.IdServer = IdServer;
        config.RustDesk.RelayServer = RelayServer;
        config.RustDesk.PublicKey = PublicKey;
        config.RustDesk.Password = Password;
    }
}
