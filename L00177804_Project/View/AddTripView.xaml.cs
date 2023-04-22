namespace L00177804_Project.View;

public partial class AddTripView : ContentPage
{
    
	public AddTripView(AddTripViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

	}
}