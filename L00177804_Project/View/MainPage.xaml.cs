
namespace L00177804_Project;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
    
        BindingContext = viewModel;
    }


}

