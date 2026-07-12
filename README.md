# RustDeskEnterprise

## Project Description

RustDeskEnterprise is an enterprise-grade deployment manager for RustDesk, built with .NET 8 LTS and C# 13. This solution provides comprehensive tools for managing RustDesk installations across hundreds or thousands of client machines in enterprise environments.

## Key Features (Planned)

- **Installation Management**: Deploy RustDesk across enterprise networks
- **Version Control**: Upgrade and downgrade RustDesk versions seamlessly
- **Automatic Updates**: Scheduled automatic update system
- **Offline Updates**: Support for internal file server-based updates
- **Configuration Management**: Centralized configuration with JSON-based settings
- **Package Builder**: Create customized EXE and MSI packages
- **Configuration Wizard**: WPF-based MVVM wizard for easy setup
- **Windows Service**: Background service for update checking and management
- **Administration Console**: Future enterprise administration interface

## Architecture Overview

The solution follows **Clean Architecture** principles with clear separation of concerns:

### Project Structure

```
src/
├── RustDeskEnterprise.Shared           # Shared models, interfaces, enums, constants
├── RustDeskEnterprise.Configuration    # Configuration models and management
├── RustDeskEnterprise.Logging          # Serilog-based logging infrastructure
├── RustDeskEnterprise.Update           # Update engine (future)
├── RustDeskEnterprise.Service          # Windows Service
├── RustDeskEnterprise.Wizard           # WPF Configuration Wizard (MVVM)
├── RustDeskEnterprise.PackageBuilder   # Package creation and customization
├── RustDeskEnterprise.Bootstrapper     # EXE installer launcher
├── RustDeskEnterprise.Admin            # Administration console (future)
└── RustDeskEnterprise.Tests            # Unit and integration tests

installer/
├── WiX/                                # WiX Toolset configuration (future)

docs/                                  # Documentation
packages/                              # Build artifacts
scripts/                               # Build and deployment scripts
```

### Dependency Flow

```
UI Layers (Wizard, Admin, Service)
         ↓
   Business Layer
         ↓
  Application Layer (Configuration, Update, Logging)
         ↓
  Domain Layer (Shared)
```

## Technology Stack

- **Framework**: .NET 8 LTS
- **Language**: C# 13
- **UI Framework**: WPF with MVVM
- **MVVM Toolkit**: CommunityToolkit.Mvvm
- **Logging**: Serilog with file rolling logs
- **Configuration**: JSON-based with Microsoft.Extensions.Configuration
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection
- **Testing**: XUnit (planned)

## Build Instructions

### Prerequisites

- .NET 8 SDK or later
- Visual Studio 2022 v17.8 or later (recommended)
- Windows 10/11 or Windows Server 2019+

### Building the Solution

```bash
# Navigate to the solution directory
cd RustDeskEnterprise

# Restore NuGet packages
dotnet restore

# Build the solution
dotnet build

# Run tests
dotnet test

# Build in Release mode
dotnet build -c Release
```

### Project Build Order

The projects should be built in this order (dependencies):
1. RustDeskEnterprise.Shared
2. RustDeskEnterprise.Logging
3. RustDeskEnterprise.Configuration
4. RustDeskEnterprise.Update
5. RustDeskEnterprise.PackageBuilder
6. RustDeskEnterprise.Service
7. RustDeskEnterprise.Wizard
8. RustDeskEnterprise.Bootstrapper
9. RustDeskEnterprise.Admin
10. RustDeskEnterprise.Tests

## Coding Standards

### C# Code Style

- **Naming**: Follow Microsoft C# naming conventions
  - Classes and methods: PascalCase
  - Local variables and parameters: camelCase
  - Private fields: _camelCase
  - Constants: PascalCase

- **Documentation**: All public members must have XML documentation
  - Comments written in Persian
  - Code identifiers in English

- **Language**: C# 13
  - Nullable reference types enabled
  - Implicit using directives
  - Latest language features utilized

### Project Layout

Each project follows this structure:
```
ProjectName/
├── ProjectName.csproj        # NuGet dependencies and project settings
├── GlobalUsings.cs           # Global using statements
├── Interfaces/               # Public contracts (if applicable)
├── Models/                   # Data models
├── Services/                 # Business logic
├── ViewModels/               # MVVM ViewModels (UI projects only)
├── Views/                    # XAML views (WPF projects only)
└── Extensions/               # Extension methods
```

## Configuration

### Logging Configuration

- **Location**: `C:\ProgramData\RustDeskEnterprise\Logs`
- **Format**: Daily rolling logs with 30-day retention
- **Log File Size**: 100 MB per file with automatic rollover
- **Development**: Debug level logging
- **Production**: Information level logging

### Application Configuration

- **File Format**: JSON (appsettings.json)
- **Location**: Application directory
- **Sections**:
  - Organization settings
  - RustDesk server configuration
  - Update settings
  - Network settings
  - Windows Service settings
  - Package Builder settings

## Localization

The solution supports multiple languages:
- **Persian** (Farsi) - Primary
- **English** - Secondary

## Themes

UI applications support:
- **Light Theme**
- **Dark Theme**

## Contributing

This is a closed-source enterprise project. Please follow the coding standards and architecture guidelines when contributing.

## License

Proprietary - RustDesk Enterprise

## Support

For issues and questions, please contact the development team.

---

**Created**: 2026-07-12  
**Version**: 1.0.0-alpha  
**Status**: Architecture phase - Business logic implementation in progress
