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
		return builder.Build();
	}
}
