
using CommunityToolkit.Mvvm.Messaging;
using L00177804_Project.Service.ThemeService;
using L00177804_Project.Service.VehicleStoreService;


namespace L00177804_Project;

public partial class App : Application
{
    private readonly string syncKey = "syncfusion";
    public App()
	{
   
        string key = GetKey();
 
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(key);
   
		InitializeComponent();
		MainPage = new AppShell();

        // Register the recipient with the messenger again
        WeakReferenceMessenger.Default.Register<VehicleChangedMessage>(this, LoadCarHandler);
        WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this, LoadThemeHandler);

        // Load the theme and car
        var theme = Preferences.Get("theme", "System");
        var cars = Preferences.Get("cars", "Work");

        LoadTheme(theme);
        LoadCar(cars);
    }

    private string GetKey()
    {

        string value = SecureStorage.GetAsync(syncKey).Result;
        return value.ToString();
    }



        private void LoadTheme(string theme)
    {
        if (!MainThread.IsMainThread)
        {
            MainThread.BeginInvokeOnMainThread(() => LoadTheme(theme));
            return;
        }

        if (theme == "System")
        {
            theme = Current.PlatformAppTheme.ToString();
        }

        ResourceDictionary dictionary = theme switch
        {
            "Dark" => new Resources.Styles.Dark(),
            "Light" => new Resources.Styles.Light(),
            "Pink" => new Resources.Styles.Red(),
            "Blue" => new Resources.Styles.Blue(),
            _ => null
        };

        if (dictionary != null)
        {
            Resources.MergedDictionaries.Clear();

            Resources.MergedDictionaries.Add(dictionary);
        }
    }

    private void LoadCar(string cars)
    {

        if (!MainThread.IsMainThread)
        {
            MainThread.BeginInvokeOnMainThread(() => LoadCar(cars));
            return;
        }
        cars = Current.PlatformAppTheme.ToString();

    }
    private void LoadCarHandler(object recipient, VehicleChangedMessage message)
    {
        LoadCar(message.Value);
    }

    private void LoadThemeHandler(object recipient, ThemeChangedMessage message)
    {
        LoadTheme(message.Value);
    }
}
