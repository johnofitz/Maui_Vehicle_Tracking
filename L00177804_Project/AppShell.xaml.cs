using System.Reflection;

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

    // This method is called every time the user navigates to a new page in the Shell
    ShellContent _previousShellContent; // declare a variable to hold the previously viewed ShellContent

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        // Check if the user has navigated to a new ShellContent and that there was a previously viewed ShellContent
        if (CurrentItem?.CurrentItem?.CurrentItem is not null && _previousShellContent is not null)
        {
            // Get the ContentCache property of the previously viewed ShellContent using reflection
            var property = typeof(ShellContent)
                .GetProperty("ContentCache", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            // Set the value of the ContentCache property to null to clear the cache
            property.SetValue(_previousShellContent, null);
        }

        // Set the _previousShellContent variable to the currently viewed ShellContent for future reference
        _previousShellContent = CurrentItem?.CurrentItem?.CurrentItem;
    }
}
