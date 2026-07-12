namespace RustDeskEnterprise.Tests.Shared;

/// <summary>
/// تست‌های مدل‌های Shared
Unit tests for Shared models
/// </summary>
public class SharedModelsTests
{
    [Fact]
    public void OrganizationSettings_ShouldHaveDefaultValues()
    {
        // Act
        var settings = new OrganizationSettings();

        // Assert
        Assert.Equal("RustDesk Enterprise", settings.Name);
        Assert.Null(settings.LogoPath);
        Assert.Null(settings.SupportEmail);
        Assert.Null(settings.SupportPhone);
    }

    [Fact]
    public void RustDeskSettings_ShouldHaveDefaultValues()
    {
        // Act
        var settings = new RustDeskSettings();

        // Assert
        Assert.Equal("rustdesk", settings.IdServer);
        Assert.Equal("rustdesk", settings.RelayServer);
        Assert.Equal("9h3VrRUBXkHHtEUHCeWhreRTpZfLycCKMPCfskww6iM", settings.PublicKey);
    }

    [Fact]
    public void UpdateSettings_ShouldHaveDefaultValues()
    {
        // Act
        var settings = new UpdateSettings();

        // Assert
        Assert.Equal(UpdateMode.Offline, settings.Mode);
        Assert.Equal(6, settings.CheckIntervalHours);
        Assert.False(settings.AutoUpdateEnabled);
    }

    [Fact]
    public void NetworkSettings_ShouldHaveDefaultTimeout()
    {
        // Act
        var settings = new NetworkSettings();

        // Assert
        Assert.Equal(30, settings.TimeoutSeconds);
    }

    [Fact]
    public void ServiceSettings_ShouldHaveDefaultValues()
    {
        // Act
        var settings = new ServiceSettings();

        // Assert
        Assert.True(settings.EnableService);
        Assert.True(settings.AutoStart);
        Assert.Equal("RustDeskEnterpriseService", settings.ServiceName);
    }

    [Fact]
    public void EnterpriseConfiguration_ShouldInitializeAllSections()
    {
        // Act
        var config = new EnterpriseConfiguration();

        // Assert
        Assert.NotNull(config.Organization);
        Assert.NotNull(config.RustDesk);
        Assert.NotNull(config.Update);
        Assert.NotNull(config.Network);
        Assert.NotNull(config.Service);
    }

    [Fact]
    public void RustDeskVersionInfo_ShouldHaveDefaultArchitecture()
    {
        // Act
        var versionInfo = new RustDeskVersionInfo();

        // Assert
        Assert.Equal(Architecture.X64, versionInfo.Architecture);
    }

    [Fact]
    public void UpdateMode_ShouldHaveCorrectValues()
    {
        // Assert
        Assert.Equal(0, (int)UpdateMode.Online);
        Assert.Equal(1, (int)UpdateMode.Offline);
        Assert.Equal(2, (int)UpdateMode.LocalShare);
        Assert.Equal(3, (int)UpdateMode.Manual);
    }

    [Fact]
    public void InstallMode_ShouldHaveCorrectValues()
    {
        // Assert
        Assert.Equal(0, (int)InstallMode.Silent);
        Assert.Equal(1, (int)InstallMode.Interactive);
    }

    [Fact]
    public void Architecture_ShouldHaveCorrectValues()
    {
        // Assert
        Assert.Equal(0, (int)Architecture.X86);
        Assert.Equal(1, (int)Architecture.X64);
        Assert.Equal(2, (int)Architecture.Arm);
    }
}
