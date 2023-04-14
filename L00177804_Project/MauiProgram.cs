using L00177804_Project.Service.NearByService;
using L00177804_Project.Service.VehicleInfoService;
<<<<<<< Updated upstream
=======
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using L00177804_Project.Service.ThemeService;
>>>>>>> Stashed changes

namespace L00177804_Project;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiMaps();

#if DEBUG
		builder.Logging.AddDebug();
#endif

<<<<<<< Updated upstream
		builder.Services.AddSingleton<MapViewModel>();
		builder.Services.AddTransient<MapView>();

		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<MainPage>();
=======
 
        builder.Services.AddTransient<MapViewModel>();
        builder.Services.AddTransient<MapView>();

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();
>>>>>>> Stashed changes

		builder.Services.AddTransient<NearByRestService>();

		builder.Services.AddTransient<ExpensesViewModel>();
		builder.Services.AddTransient<ExpenseView>();

		builder.Services.AddTransient<TripView>();
		builder.Services.AddTransient<TripLogViewModel>();

		builder.Services.AddTransient<VehicleView>();
		builder.Services.AddTransient<VehicleViewModel>();

<<<<<<< Updated upstream
		builder.Services.AddTransient<SettingsView>();
		//builder.Services.AddTransient<SettingsViewModel>();
=======
        builder.Services.AddTransient<SettingsView>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<ThemeAddMessage>();
        builder.Services.AddTransient<ThemeChangedMessage>();
>>>>>>> Stashed changes

		builder.Services.AddTransient<ReminderView>();
		//builder.Services.AddTransient<ReminderViewModel>();

		builder.Services.AddTransient<AddVehicleView>();
		builder.Services.AddTransient<AddVehicleViewModel>();

		builder.Services.AddTransient<VehicleDataService>();



		return builder.Build();
	}
}
