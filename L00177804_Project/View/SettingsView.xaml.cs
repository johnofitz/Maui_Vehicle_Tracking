namespace L00177804_Project.View;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	

	}
}