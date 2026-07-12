namespace RustDeskEnterprise.Shared.Enums;

/// <summary>
/// معماری سیستم‌های پشتیبانی‌شده
Supported system architectures
/// </summary>
public enum Architecture
{
    /// <summary>
    /// معماری 32 بیتی
    /// 32-bit architecture
    /// </summary>
    X86 = 0,

    /// <summary>
    /// معماری 64 بیتی
    /// 64-bit architecture
    /// </summary>
    X64 = 1,

    /// <summary>
    /// معماری ARM
    /// ARM architecture
    /// </summary>
    Arm = 2
}
