namespace L00177804_Project;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ReminderView), typeof(ReminderView));
        Routing.RegisterRoute(nameof(MapView), typeof(MapView));
        Routing.RegisterRoute(nameof(TripView), typeof(TripView));
        Routing.RegisterRoute(nameof(ExpenseView), typeof(ExpenseView));
        Routing.RegisterRoute(nameof(VehicleView), typeof(VehicleView));
        Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
        Routing.RegisterRoute(nameof(AddVehicleView), typeof(AddVehicleView));
        
    }
}
