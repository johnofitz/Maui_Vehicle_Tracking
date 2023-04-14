namespace L00177804_Project.View;

public partial class TripView : ContentPage
{
	public TripView(TripLogViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}