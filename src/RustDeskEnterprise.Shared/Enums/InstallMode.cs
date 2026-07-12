namespace RustDeskEnterprise.Shared.Enums;

/// <summary>
/// روش‌های نصب برنامه
Application installation modes
/// </summary>
public enum InstallMode
{
    /// <summary>
    /// نصب بدون تعامل کاربر (بدون رابط گرافیکی)
    /// Silent installation without user interaction
    /// </summary>
    Silent = 0,

    /// <summary>
    /// نصب تعاملی با کاربر
    /// Interactive installation with user interface
    /// </summary>
    Interactive = 1
}
