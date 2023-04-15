namespace L00177804_Project.View;

public partial class EditVehicleView : ContentPage
{
	public EditVehicleView(EditVehicleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}