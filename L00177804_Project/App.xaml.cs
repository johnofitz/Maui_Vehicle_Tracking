
using CommunityToolkit.Mvvm.Messaging;
using L00177804_Project.Service.ThemeService;
using L00177804_Project.Service.VehicleStoreService;


namespace L00177804_Project;

public partial class App : Application
{
    private readonly string syncKey = "syncfusion";
    public App()
	{
        //string key = GetKey();
 
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1mQ1BEaV1CX2BZf1N8RmtTfFpgBShNYlxTR3ZaQ1xiSX1bdUNnXHpW;Mgo+DSMBPh8sVXJ1S0R+X1pCaV5CQmFJfFBmRGNTfFZ6d1FWESFaRnZdQV1mSH9SdkZrWnlad3Zd;ORg4AjUWIQA/Gnt2VFhiQlJPcEBDXXxLflF1VWJZdV14flZCcC0sT3RfQF5jTH9Sd0VgUXxYdnFXTg==;MjAxMDkyNkAzMjMxMmUzMjJlMzNoMHIwQkcrTCtZMlZjMGpvTWlDemxVektIRm02WjRsaUM0ZkxtZW5aRG9ZPQ==;MjAxMDkyN0AzMjMxMmUzMjJlMzNJdHV2SDg3ckFlaG04d1A2dm5Sb09UbXE4RHIwdjZNeHVWbDVGejNka0JnPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVldXGNWfFN0RnNYf1RzfF9FZEwgOX1dQl9gSXtSd0RjWndddnxcTmg=;MjAxMDkyOUAzMjMxMmUzMjJlMzNlbk42Wk8yMWlhQU1vL2sxTlAzUU02NDcyVitQNEhIOThkRjZ1U1I0WWFrPQ==;MjAxMDkzMEAzMjMxMmUzMjJlMzNTZEE0Vi8vT2NKbGl6UHlrOEVYVDkwajBzaEJrNmJMLzVtbmM0OVlrME9NPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPcEBDXXxLflF1VWJZdV14flZCcC0sT3RfQF5jTH9Sd0VgUXxYeX1cTg==;MjAxMDkzMkAzMjMxMmUzMjJlMzNVYTRGOVNkQU5KN05OVy93S1N0WHVjQ1B3NlA5bWRxd2dnSzFpYklKMzhJPQ==;MjAxMDkzM0AzMjMxMmUzMjJlMzNjenFvanJ4d1lhU1Z3VXJHTmkrQ095aHZQeUhGUjlBM2tvcUZSbjlDSXBzPQ==;MjAxMDkzNEAzMjMxMmUzMjJlMzNlbk42Wk8yMWlhQU1vL2sxTlAzUU02NDcyVitQNEhIOThkRjZ1U1I0WWFrPQ==");
   
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
  
    //private string GetKey()
    //{
       
    //    string value = SecureStorage.GetAsync(syncKey).Result;
    //    return value.ToString();
    //}

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
            "Red" => new Resources.Styles.Red(),
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
