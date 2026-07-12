namespace RustDeskEnterprise.Tests.Configuration;

/// <summary>
/// تست‌های ConfigurationService
Unit tests for ConfigurationService
/// </summary>
public class ConfigurationServiceTests : IDisposable
{
    private readonly string _testConfigPath;
    private readonly IValidator<EnterpriseConfiguration> _validator;

    public ConfigurationServiceTests()
    {
        _testConfigPath = Path.Combine(Path.GetTempPath(), $"test_config_{Guid.NewGuid()}.json");
        _validator = new ConfigurationValidator();
    }

    public void Dispose()
    {
        if (File.Exists(_testConfigPath))
        {
            File.Delete(_testConfigPath);
        }
    }

    [Fact]
    public async Task LoadAsync_WithMissingFile_ShouldCreateDefaultConfiguration()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);

        // Act
        var config = await service.LoadAsync();

        // Assert
        Assert.NotNull(config);
        Assert.Equal("9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM", config.RustDesk.PublicKey);
        Assert.True(File.Exists(_testConfigPath));
    }

    [Fact]
    public async Task SaveAsync_WithValidConfiguration_ShouldSaveToFile()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);
        var config = new EnterpriseConfiguration
        {
            Organization = new OrganizationSettings { Name = "Test Organization" },
            RustDesk = new RustDeskSettings
            {
                IdServer = "test.rustdesk.com",
                RelayServer = "relay.rustdesk.com",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            }
        };

        // Act
        await service.SaveAsync(config);

        // Assert
        Assert.True(File.Exists(_testConfigPath));
        var fileContent = await File.ReadAllTextAsync(_testConfigPath);
        Assert.Contains("Test Organization", fileContent);
        Assert.Contains("test.rustdesk.com", fileContent);
    }

    [Fact]
    public async Task SaveAsync_WithNullConfiguration_ShouldThrowArgumentNullException()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => service.SaveAsync(null!));
    }

    [Fact]
    public async Task SaveAsync_AndLoadAsync_ShouldPreserveConfiguration()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);
        var originalConfig = new EnterpriseConfiguration
        {
            Organization = new OrganizationSettings
            {
                Name = "My Organization",
                SupportEmail = "support@example.com",
                SupportPhone = "+1-555-0100"
            },
            RustDesk = new RustDeskSettings
            {
                IdServer = "id.example.com",
                RelayServer = "relay.example.com",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM",
                Password = "secret"
            },
            Update = new UpdateSettings
            {
                Mode = UpdateMode.LocalShare,
                LocalSharePath = @"\\network\share\updates",
                CheckIntervalHours = 12,
                AutoUpdateEnabled = true
            }
        };

        // Act
        await service.SaveAsync(originalConfig);
        var loadedConfig = await service.LoadAsync();

        // Assert
        Assert.Equal(originalConfig.Organization.Name, loadedConfig.Organization.Name);
        Assert.Equal(originalConfig.Organization.SupportEmail, loadedConfig.Organization.SupportEmail);
        Assert.Equal(originalConfig.RustDesk.IdServer, loadedConfig.RustDesk.IdServer);
        Assert.Equal(originalConfig.Update.Mode, loadedConfig.Update.Mode);
        Assert.Equal(originalConfig.Update.CheckIntervalHours, loadedConfig.Update.CheckIntervalHours);
    }

    [Fact]
    public async Task ValidateAsync_WithValidConfiguration_ShouldReturnTrue()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);
        var config = new EnterpriseConfiguration
        {
            Organization = new OrganizationSettings { Name = "Test Org" },
            RustDesk = new RustDeskSettings
            {
                IdServer = "rustdesk",
                RelayServer = "rustdesk",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            },
            Update = new UpdateSettings { CheckIntervalHours = 6 },
            Network = new NetworkSettings { TimeoutSeconds = 30 },
            Service = new ServiceSettings { ServiceName = "RustDeskEnterpriseService" }
        };

        // Act
        var result = await service.ValidateAsync(config);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task ValidateAsync_WithInvalidConfiguration_ShouldReturnFalse()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);
        var config = new EnterpriseConfiguration
        {
            RustDesk = new RustDeskSettings
            {
                IdServer = "",
                RelayServer = "rustdesk",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            }
        };

        // Act
        var result = await service.ValidateAsync(config);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task ValidateAsync_WithNullConfiguration_ShouldThrowArgumentNullException()
    {
        // Arrange
        var service = new ConfigurationService(_testConfigPath, _validator);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => service.ValidateAsync(null!));
    }

    [Fact]
    public async Task LoadAsync_WithInvalidJson_ShouldThrowConfigurationException()
    {
        // Arrange
        await File.WriteAllTextAsync(_testConfigPath, "{ invalid json");
        var service = new ConfigurationService(_testConfigPath, _validator);

        // Act & Assert
        await Assert.ThrowsAsync<ConfigurationException>(() => service.LoadAsync());
    }
}
