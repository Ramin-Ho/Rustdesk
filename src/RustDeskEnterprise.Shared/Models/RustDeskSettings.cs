namespace RustDeskEnterprise.Shared.Models;

/// <summary>
/// تنظیمات سرور RustDesk
RustDesk server configuration settings
/// </summary>
public class RustDeskSettings
{
    /// <summary>
    /// آدرس سرور شناسایی (ID Server)
    /// RustDesk ID Server address
    /// </summary>
    [JsonPropertyName("idServer")]
    public string IdServer { get; set; } = "rustdesk";

    /// <summary>
    /// آدرس سرور رله (Relay Server)
    /// RustDesk Relay Server address
    /// </summary>
    [JsonPropertyName("relayServer")]
    public string RelayServer { get; set; } = "rustdesk";

    /// <summary>
    /// کلید عمومی
    /// Public key for encryption
    /// </summary>
    [JsonPropertyName("publicKey")]
    public string PublicKey { get; set; } = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM";

    /// <summary>
    /// کلمه‌ی عبور
    /// Password for authentication
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}
