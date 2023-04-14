namespace L00177804_Project;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrWU5FdkBAXWFKblR8RWNTfVlgBShNYlxTR3ZbQ11jTn5Xd01jWnhd;Mgo+DSMBPh8sVXJ1S0d+X1RPc0BDXXxLflF1VWRTf156dlJWESFaRnZdQV1nSH5TcUVnWHdedXRW;ORg4AjUWIQA/Gnt2VFhhQlJBfVpdXGNWfFN0RnNedV5wfldBcC0sT3RfQF5jTX9TdkJjXX5WcHJWRQ==;MTY3MDU0MUAzMjMxMmUzMTJlMzMzNVZGNjY2UU1uT3lUZUhvc25wT1M3b0tGVlZ0a0phak9jVUw3OFJkeE1lbU09;MTY3MDU0MkAzMjMxMmUzMTJlMzMzNWY2VGNhR1prNlFJdWc0c3RnU0RITW03WDJwUGtiU3N5VTlGSElQbU0wYUE9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmJJYVF2R2BJeFRwdF9EZ0wgOX1dQl9gSXpSdkVkWXtfeHZWQ2M=;MTY3MDU0NEAzMjMxMmUzMTJlMzMzNW0zVTZSaVpSdFkyTm9FemQ2MGZpTys2MSt5dzNNN2h4T1h4bFpXQUxqUXc9;MTY3MDU0NUAzMjMxMmUzMTJlMzMzNWNMSys3bGU2c0c2cmZ2UHRTR013ODNscm0rKzd5RjI2REFHemMwaFlJUTQ9;Mgo+DSMBMAY9C3t2VFhhQlJBfVpdXGNWfFN0RnNedV5wfldBcC0sT3RfQF5jTX9TdkJjXX5WcnxRRQ==;MTY3MDU0N0AzMjMxMmUzMTJlMzMzNVJNeDdPSVJNNEZQS0FFN2NJdHBXNmxOSjFIYkVMNWZCRC9SckFRcXBNNnc9;MTY3MDU0OEAzMjMxMmUzMTJlMzMzNWxnNUlzcUY0eVZnemo1RE9YWWtsdVczNjZhT2srY1lXZk1ZZmxDUTZnTVU9;MTY3MDU0OUAzMjMxMmUzMTJlMzMzNW0zVTZSaVpSdFkyTm9FemQ2MGZpTys2MSt5dzNNN2h4T1h4bFpXQUxqUXc9");
		MainPage = new AppShell();

        // let's set the initial theme already during the app start
        SetTheme();

        // subscribe to changes in the settings
        SettingsViewModel.Instance.PropertyChanged += OnSettingsPropertyChanged;
    }

    private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SettingsViewModel.Theme))
        {
            SetTheme();
        }
    }

    private void SetTheme()
    {

        UserAppTheme = SettingsViewModel.Instance?.Theme != null
                     ? SettingsViewModel.Instance.Theme.AppTheme
                     : AppTheme.Unspecified;

        //switch (UserAppTheme)
        //{
        //    case AppTheme.Light:
        //        SettingsViewModel.Instance.SetStatusBarColor(Colors.White, true);
        //        break;
        //    case AppTheme.Dark:
        //        DeviceService.Instance.SetStatusBarColor(Colors.Black, false);
        //        break;
        //    case AppTheme.Unspecified when RequestedTheme == AppTheme.Light:
        //        DeviceService.Instance.SetStatusBarColor(Colors.White, true);
        //        break;
        //    case AppTheme.Unspecified:
        //        vInstance.SetStatusBarColor(Colors.Black, false);
        //        break;
        //}
    }
   }
