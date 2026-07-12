namespace RustDeskEnterprise.Wizard.Models;

/// <summary>
/// مدل برای نشان‌دادن وضعیت ویزارد
Model for wizard state
/// </summary>
public partial class WizardState : ObservableObject
{
    /// <summary>
    /// شماره صفحه جاری (1-based)
    /// Current page number (1-based)
    /// </summary>
    [ObservableProperty]
    private int currentPage = 1;

    /// <summary>
    /// تعداد کل صفحات
    /// Total number of pages
    /// </summary>
    public const int TotalPages = 6;

    /// <summary>
    /// آیا می‌توان به صفحه قبلی برگشت
    /// Whether we can go to previous page
    /// </summary>
    public bool CanGoBack => CurrentPage > 1;

    /// <summary>
    /// آیا می‌توان به صفحه بعدی رفت
    /// Whether we can go to next page
    /// </summary>
    public bool CanGoNext => CurrentPage < TotalPages;

    /// <summary>
    /// نام صفحه جاری
    /// Current page name
    /// </summary>
    public string CurrentPageName => CurrentPage switch
    {
        1 => "OrganizationSettings",
        2 => "RustDeskSettings",
        3 => "UpdateSettings",
        4 => "NetworkSettings",
        5 => "ServiceSettings",
        6 => "PackageBuilderSettings",
        _ => "Unknown"
    };

    /// <summary>
    /// حرکت به صفحه بعدی
    /// Move to next page
    /// </summary>
    public void NextPage()
    {
        if (CanGoNext)
        {
            CurrentPage++;
        }
    }

    /// <summary>
    /// حرکت به صفحه قبلی
    /// Move to previous page
    /// </summary>
    public void PreviousPage()
    {
        if (CanGoBack)
        {
            CurrentPage--;
        }
    }
}
