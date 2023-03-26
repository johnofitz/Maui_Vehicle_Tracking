using L00177804_Project.Service.NearByService;

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

		builder.Services.AddSingleton<MapViewModel>();
		builder.Services.AddTransient<MapView>();

		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<MainPage>();

		builder.Services.AddTransient<NearByRestService>();

		builder.Services.AddTransient<ExpensesViewModel>();
		builder.Services.AddTransient<ExpenseView>();

		builder.Services.AddTransient<TripView>();
		builder.Services.AddTransient<TripLogViewModel>();

		builder.Services.AddTransient<VehicleView>();
		builder.Services.AddTransient<VehicleViewModel>();

		builder.Services.AddTransient<SettingsView>();
		//builder.Services.AddTransient<SettingsViewModel>();

		builder.Services.AddTransient<ReminderView>();
		//builder.Services.AddTransient<ReminderViewModel>();

		builder.Services.AddTransient<AddVehicleView>();
		builder.Services.AddTransient<AddVehicleViewModel>();
		return builder.Build();
	}
}
