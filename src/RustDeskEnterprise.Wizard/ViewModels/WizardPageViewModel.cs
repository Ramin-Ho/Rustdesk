namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel پایه‌ای برای تمام صفحات ویزارد
Base ViewModel for all wizard pages
/// </summary>
public abstract partial class WizardPageViewModel : ObservableObject
{
    /// <summary>
    /// عنوان صفحه
    /// Page title
    /// </summary>
    [ObservableProperty]
    private string title = "Page";

    /// <summary>
    /// توضیح صفحه
    /// Page description
    /// </summary>
    [ObservableProperty]
    private string description = "";

    /// <summary>
    /// آیا صفحه معتبر است
    /// Whether page is valid
    /// </summary>
    [ObservableProperty]
    private bool isValid = true;

    /// <summary>
    /// پیام خطا
    /// Error message
    /// </summary>
    [ObservableProperty]
    private string? errorMessage;

    /// <summary>
    /// اعتبارسنجی صفحه
    /// Validate the page
    /// </summary>
    /// <returns>آیا صفحه معتبر است / Whether page is valid</returns>
    public abstract bool Validate();

    /// <summary>
    /// بارگذاری تنظیمات
    /// Load settings
    /// </summary>
    /// <param name="config">تنظیمات سازمان / Enterprise configuration</param>
    public abstract void LoadSettings(EnterpriseConfiguration config);

    /// <summary>
    /// ذخیره تنظیمات
    /// Save settings
    /// </summary>
    /// <param name="config">تنظیمات سازمان / Enterprise configuration</param>
    public abstract void SaveSettings(EnterpriseConfiguration config);
}
