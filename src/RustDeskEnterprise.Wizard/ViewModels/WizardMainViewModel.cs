namespace RustDeskEnterprise.Wizard.ViewModels;

/// <summary>
/// ViewModel اصلی ویزارد
Main wizard ViewModel
/// </summary>
public partial class WizardMainViewModel : ObservableObject
{
    private readonly IConfigurationService _configurationService;
    private readonly OrganizationSettingsViewModel _organizationViewModel;
    private readonly RustDeskSettingsViewModel _rustDeskViewModel;
    private readonly UpdateSettingsViewModel _updateViewModel;
    private readonly NetworkSettingsViewModel _networkViewModel;
    private readonly ServiceSettingsViewModel _serviceViewModel;
    private readonly PackageBuilderSettingsViewModel _packageBuilderViewModel;
    private readonly WizardPageViewModel[] _pages;

    private EnterpriseConfiguration _currentConfiguration = new();

    /// <summary>
    /// وضعیت ویزارد
    /// Wizard state
    /// </summary>
    [ObservableProperty]
    private WizardState wizardState = new();

    /// <summary>
    /// صفحه جاری
    /// Current page
    /// </summary>
    [ObservableProperty]
    private WizardPageViewModel currentPage = null!;

    /// <summary>
    /// سازنده WizardMainViewModel
    /// Constructor for WizardMainViewModel
    /// </summary>
    /// <param name="configurationService">سرویس پیکربندی / Configuration service</param>
    public WizardMainViewModel(IConfigurationService configurationService)
    {
        _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));

        _organizationViewModel = new OrganizationSettingsViewModel();
        _rustDeskViewModel = new RustDeskSettingsViewModel();
        _updateViewModel = new UpdateSettingsViewModel();
        _networkViewModel = new NetworkSettingsViewModel();
        _serviceViewModel = new ServiceSettingsViewModel();
        _packageBuilderViewModel = new PackageBuilderSettingsViewModel();

        _pages = new WizardPageViewModel[]
        {
            _organizationViewModel,
            _rustDeskViewModel,
            _updateViewModel,
            _networkViewModel,
            _serviceViewModel,
            _packageBuilderViewModel
        };

        CurrentPage = _pages[0];
        WizardState.PropertyChanged += (s, e) => OnPropertyChanged(nameof(WizardState));
    }

    /// <summary>
    /// بارگذاری پیکربندی
    /// Load configuration
    /// </summary>
    [RelayCommand]
    public async Task LoadConfiguration()
    {
        try
        {
            _currentConfiguration = await _configurationService.LoadAsync();
            foreach (var page in _pages)
            {
                page.LoadSettings(_currentConfiguration);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading configuration: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    /// <summary>
    /// ذخیره پیکربندی
    /// Save configuration
    /// </summary>
    [RelayCommand]
    public async Task SaveConfiguration()
    {
        try
        {
            foreach (var page in _pages)
            {
                if (!page.Validate())
                {
                    MessageBox.Show(page.ErrorMessage ?? "Validation failed", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                page.SaveSettings(_currentConfiguration);
            }

            await _configurationService.SaveAsync(_currentConfiguration);
            MessageBox.Show("Configuration saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving configuration: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    /// <summary>
    /// حرکت به صفحه بعدی
    /// Move to next page
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanMoveNext))]
    public void MoveNext()
    {
        if (!CurrentPage.Validate())
        {
            MessageBox.Show(CurrentPage.ErrorMessage ?? "Validation failed", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        CurrentPage.SaveSettings(_currentConfiguration);
        WizardState.NextPage();
        CurrentPage = _pages[WizardState.CurrentPage - 1];
    }

    /// <summary>
    /// حرکت به صفحه قبلی
    /// Move to previous page
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanMovePrevious))]
    public void MovePrevious()
    {
        WizardState.PreviousPage();
        CurrentPage = _pages[WizardState.CurrentPage - 1];
    }

    /// <summary>
    /// آیا می‌توان به صفحه بعدی رفت
    /// Whether we can move to next page
    /// </summary>
    private bool CanMoveNext => WizardState.CanGoNext;

    /// <summary>
    /// آیا می‌توان به صفحه قبلی برگشت
    /// Whether we can move to previous page
    /// </summary>
    private bool CanMovePrevious => WizardState.CanGoBack;
}
