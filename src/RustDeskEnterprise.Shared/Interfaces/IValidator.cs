namespace RustDeskEnterprise.Shared.Interfaces;

/// <summary>
/// رابط کلی برای اعتبارسنجی
Generic interface for validation
/// </summary>
/// <typeparam name="T">نوع شیء برای اعتبارسنجی / Type of object to validate</typeparam>
public interface IValidator<T>
{
    /// <summary>
    /// اعتبارسنجی یک شیء
    /// Validate an object
    /// </summary>
    /// <param name="obj">شیء برای اعتبارسنجی / Object to validate</param>
    /// <returns>آیا شیء معتبر است / Whether object is valid</returns>
    bool Validate(T obj);

    /// <summary>
    /// دریافت پیام‌های خطا
    /// Get validation error messages
    /// </summary>
    /// <returns>لیست پیام‌های خطا / List of error messages</returns>
    IEnumerable<string> GetErrors();
}
