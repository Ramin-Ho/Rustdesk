namespace RustDeskEnterprise.Shared.Exceptions;

/// <summary>
/// استثنای مربوط به خطاهای به‌روزرسانی
Exception for update-related errors
/// </summary>
public class UpdateException : Exception
{
    /// <summary>
    /// سازنده‌ی پیش‌فرض
    /// Default constructor
    /// </summary>
    public UpdateException()
    {
    }

    /// <summary>
    /// سازنده با پیام
    /// Constructor with message
    /// </summary>
    /// <param name="message">پیام خطا / Error message</param>
    public UpdateException(string? message) : base(message)
    {
    }

    /// <summary>
    /// سازنده با پیام و استثنای داخلی
    /// Constructor with message and inner exception
    /// </summary>
    /// <param name="message">پیام خطا / Error message</param>
    /// <param name="innerException">استثنای داخلی / Inner exception</param>
    public UpdateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
