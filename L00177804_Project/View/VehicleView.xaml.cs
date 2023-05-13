using L00177804_Project.Service.VehicleInfoService;

namespace L00177804_Project.View;

public partial class VehicleView : ContentPage
{
	public VehicleView(VehicleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
   
    }

}