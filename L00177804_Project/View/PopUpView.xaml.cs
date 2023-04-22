using Mopups.Interfaces;

namespace L00177804_Project.View;

public partial class PopUpView
{

	public PopUpView(PopUpViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
	}
}