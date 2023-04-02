namespace L00177804_Project.View;

public partial class AddVehicleView : ContentPage
{
	public AddVehicleView(AddVehicleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}