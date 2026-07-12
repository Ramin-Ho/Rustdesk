namespace RustDeskEnterprise.Tests.Configuration;

/// <summary>
/// تست‌های ConfigurationValidator
Unit tests for ConfigurationValidator
/// </summary>
public class ConfigurationValidatorTests
{
    [Fact]
    public void Validate_WithValidConfiguration_ShouldReturnTrue()
    {
        // Arrange
        var validator = new ConfigurationValidator();
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
        var result = validator.Validate(config);

        // Assert
        Assert.True(result);
        Assert.Empty(validator.GetErrors());
    }

    [Fact]
    public void Validate_WithNullConfiguration_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();

        // Act
        var result = validator.Validate(null!);

        // Assert
        Assert.False(result);
        Assert.NotEmpty(validator.GetErrors());
    }

    [Fact]
    public void Validate_WithEmptyIdServer_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();
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
        var result = validator.Validate(config);

        // Assert
        Assert.False(result);
        Assert.Contains(validator.GetErrors(), e => e.Contains("ID Server"));
    }

    [Fact]
    public void Validate_WithEmptyRelayServer_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();
        var config = new EnterpriseConfiguration
        {
            RustDesk = new RustDeskSettings
            {
                IdServer = "rustdesk",
                RelayServer = "",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            }
        };

        // Act
        var result = validator.Validate(config);

        // Assert
        Assert.False(result);
        Assert.Contains(validator.GetErrors(), e => e.Contains("Relay Server"));
    }

    [Fact]
    public void Validate_WithEmptyPublicKey_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();
        var config = new EnterpriseConfiguration
        {
            RustDesk = new RustDeskSettings
            {
                IdServer = "rustdesk",
                RelayServer = "rustdesk",
                PublicKey = ""
            }
        };

        // Act
        var result = validator.Validate(config);

        // Assert
        Assert.False(result);
        Assert.Contains(validator.GetErrors(), e => e.Contains("Public Key"));
    }

    [Fact]
    public void Validate_WithInvalidUpdateInterval_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();
        var config = new EnterpriseConfiguration
        {
            RustDesk = new RustDeskSettings
            {
                IdServer = "rustdesk",
                RelayServer = "rustdesk",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            },
            Update = new UpdateSettings { CheckIntervalHours = 0 }
        };

        // Act
        var result = validator.Validate(config);

        // Assert
        Assert.False(result);
        Assert.Contains(validator.GetErrors(), e => e.Contains("Update check interval"));
    }

    [Fact]
    public void Validate_WithInvalidNetworkTimeout_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();
        var config = new EnterpriseConfiguration
        {
            RustDesk = new RustDeskSettings
            {
                IdServer = "rustdesk",
                RelayServer = "rustdesk",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            },
            Network = new NetworkSettings { TimeoutSeconds = 1000 }
        };

        // Act
        var result = validator.Validate(config);

        // Assert
        Assert.False(result);
        Assert.Contains(validator.GetErrors(), e => e.Contains("timeout"));
    }

    [Fact]
    public void Validate_WithEmptyServiceName_ShouldReturnFalse()
    {
        // Arrange
        var validator = new ConfigurationValidator();
        var config = new EnterpriseConfiguration
        {
            RustDesk = new RustDeskSettings
            {
                IdServer = "rustdesk",
                RelayServer = "rustdesk",
                PublicKey = "9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM"
            },
            Service = new ServiceSettings { ServiceName = "" }
        };

        // Act
        var result = validator.Validate(config);

        // Assert
        Assert.False(result);
        Assert.Contains(validator.GetErrors(), e => e.Contains("Service name"));
    }
}
