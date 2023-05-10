using CommunityToolkit.Mvvm.Messaging;
using L00177804_Project.Service.ThemeService;
using L00177804_Project.Service.VehicleStoreService;


namespace L00177804_Project;

public partial class App : Application
{

	public App()
	{
        
    
		InitializeComponent();
		MainPage = new AppShell();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrWU5FdkBAXWFKblR8RWNTfVlgBShNYlxTR3ZbQ11jTn5Xd01jWnhd;Mgo+DSMBPh8sVXJ1S0d+X1RPc0BDXXxLflF1VWRTf156dlJWESFaRnZdQV1nSH5TcUVnWHdedXRW;ORg4AjUWIQA/Gnt2VFhhQlJBfVpdXGNWfFN0RnNedV5wfldBcC0sT3RfQF5jTX9TdkJjXX5WcHJWRQ==;MTY3MDU0MUAzMjMxMmUzMTJlMzMzNVZGNjY2UU1uT3lUZUhvc25wT1M3b0tGVlZ0a0phak9jVUw3OFJkeE1lbU09;MTY3MDU0MkAzMjMxMmUzMTJlMzMzNWY2VGNhR1prNlFJdWc0c3RnU0RITW03WDJwUGtiU3N5VTlGSElQbU0wYUE9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmJJYVF2R2BJeFRwdF9EZ0wgOX1dQl9gSXpSdkVkWXtfeHZWQ2M=;MTY3MDU0NEAzMjMxMmUzMTJlMzMzNW0zVTZSaVpSdFkyTm9FemQ2MGZpTys2MSt5dzNNN2h4T1h4bFpXQUxqUXc9;MTY3MDU0NUAzMjMxMmUzMTJlMzMzNWNMSys3bGU2c0c2cmZ2UHRTR013ODNscm0rKzd5RjI2REFHemMwaFlJUTQ9;Mgo+DSMBMAY9C3t2VFhhQlJBfVpdXGNWfFN0RnNedV5wfldBcC0sT3RfQF5jTX9TdkJjXX5WcnxRRQ==;MTY3MDU0N0AzMjMxMmUzMTJlMzMzNVJNeDdPSVJNNEZQS0FFN2NJdHBXNmxOSjFIYkVMNWZCRC9SckFRcXBNNnc9;MTY3MDU0OEAzMjMxMmUzMTJlMzMzNWxnNUlzcUY0eVZnemo1RE9YWWtsdVczNjZhT2srY1lXZk1ZZmxDUTZnTVU9;MTY3MDU0OUAzMjMxMmUzMTJlMzMzNW0zVTZSaVpSdFkyTm9FemQ2MGZpTys2MSt5dzNNN2h4T1h4bFpXQUxqUXc9");

        // Register the recipient with the messenger again
        WeakReferenceMessenger.Default.Register<VehicleChangedMessage>(this, LoadCarHandler);
        WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this, LoadThemeHandler);

        // Load the theme and car
        var theme = Preferences.Get("theme", "System");
        var cars = Preferences.Get("cars", "Work");

        LoadTheme(theme);
        LoadCar(cars);
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
