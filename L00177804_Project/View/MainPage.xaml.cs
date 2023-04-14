
using Microsoft.Maui.Controls;

namespace L00177804_Project;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel;
    public MainPage()
	{
		InitializeComponent();

        ViewModel = new MainPageViewModel( new Service.VehicleInfoService.VehicleDataService());

        BindingContext = ViewModel;
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        
        base.OnNavigatedFrom(args);
    }



    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        var test = args.LoadFromXaml(typeof(MainPage));

        // ViewModel = new MainPageViewModel(new Service.VehicleInfoService.VehicleDataService());
        //     BindingContext = ViewModel;
        //     base.OnNavigatedTo(args);


    }





}

