using System.Windows.Input;

namespace L00177804_Project.View;

public partial class MapView : ContentPage
{

    public MapView(MapViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;

    }

}