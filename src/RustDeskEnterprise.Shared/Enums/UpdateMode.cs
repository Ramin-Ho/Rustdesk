namespace RustDeskEnterprise.Shared.Enums;

/// <summary>
/// روش‌های مختلف برای به‌روزرسانی
Different methods for updating
/// </summary>
public enum UpdateMode
{
    /// <summary>
    /// به‌روزرسانی آنلاین از سرور
    /// Online update from server
    /// </summary>
    Online = 0,

    /// <summary>
    /// به‌روزرسانی آفلاین از فایل محلی
    /// Offline update from local file
    /// </summary>
    Offline = 1,

    /// <summary>
    /// به‌روزرسانی از اشتراک‌گذاری شبکه‌ای
    /// Update from network share
    /// </summary>
    LocalShare = 2,

    /// <summary>
    /// به‌روزرسانی دستی
    /// Manual update
    /// </summary>
    Manual = 3
}
