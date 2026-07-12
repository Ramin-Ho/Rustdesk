namespace RustDeskEnterprise.Shared.Exceptions;

/// <summary>
/// استثنای مربوط به خطاهای تنظیمات
Exception for configuration-related errors
/// </summary>
public class ConfigurationException : Exception
{
    /// <summary>
    /// سازنده‌ی پیش‌فرض
    /// Default constructor
    /// </summary>
    public ConfigurationException()
    {
    }

    /// <summary>
    /// سازنده با پیام
    /// Constructor with message
    /// </summary>
    /// <param name="message">پیام خطا / Error message</param>
    public ConfigurationException(string? message) : base(message)
    {
    }

    /// <summary>
    /// سازنده با پیام و استثنای داخلی
    /// Constructor with message and inner exception
    /// </summary>
    /// <param name="message">پیام خطا / Error message</param>
    /// <param name="innerException">استثنای داخلی / Inner exception</param>
    public ConfigurationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
