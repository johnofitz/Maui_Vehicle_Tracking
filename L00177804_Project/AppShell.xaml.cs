namespace L00177804_Project;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MapView), typeof(MapView));
    }
}
