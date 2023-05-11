using L00177804_Project.Service.NearByService;
using L00177804_Project.Service.VehicleInfoService;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;
using L00177804_Project.Service.ThemeService;
using Mopups.Hosting;


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
			.UseMauiMaps()
			.UseMauiCommunityToolkit()
			.ConfigureSyncfusionCore()
			.ConfigureMopups();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<MainViewModel>();

        builder.Services.AddTransient<MainPage>();

		builder.Services.AddTransient<EditVehicleView>();
		builder.Services.AddTransient<EditVehicleViewModel>();

		builder.Services.AddTransient<PopUpView>();
		builder.Services.AddTransient<PopUpViewModel>();


		builder.Services.AddTransient<NearByRestService>();

		builder.Services.AddTransient<ExpensesViewModel>();
		builder.Services.AddTransient<ExpenseView>();

		builder.Services.AddTransient<TripView>();
		builder.Services.AddTransient<TripLogViewModel>();

		builder.Services.AddTransient<VehicleView>();
		builder.Services.AddTransient<VehicleViewModel>();


		builder.Services.AddTransient<SettingsView>();
		builder.Services.AddTransient<SettingsViewModel>();


        builder.Services.AddTransient<ThemeAddMessage>();
        builder.Services.AddTransient<ThemeChangedMessage>();


		builder.Services.AddTransient<ReminderView>();
		builder.Services.AddTransient<ReminderViewModel>();

		builder.Services.AddTransient<AddVehicleView>();
		builder.Services.AddTransient<AddVehicleViewModel>();

		builder.Services.AddTransient<VehicleDataService>();

		builder.Services.AddTransient<AddTripView>();
		builder.Services.AddTransient<AddTripViewModel>();

		//builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

		return builder.Build();
	}
}
