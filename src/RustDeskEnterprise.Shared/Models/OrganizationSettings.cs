namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// تنظیمات سازمان
Organization settings configuration
/// </summary>
public class OrganizationSettings
{
    /// <summary>
    /// نام سازمان
    /// Organization name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = "RustDesk Enterprise";

    /// <summary>
    /// مسیر لوگوی سازمان
    /// Organization logo path
    /// </summary>
    [JsonPropertyName("logoPath")]
    public string? LogoPath { get; set; }

    /// <summary>
    /// ایمیل پشتیبانی
    /// Support email address
    /// </summary>
    [JsonPropertyName("supportEmail")]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// شماره تلفن پشتیبانی
    /// Support phone number
    /// </summary>
    [JsonPropertyName("supportPhone")]
    public string? SupportPhone { get; set; }
}
