
﻿namespace L00177804_Project;


public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();

    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {  
        // ViewModel = new MainPageViewModel(new Service.VehicleInfoService.VehicleDataService());
        //     BindingContext = ViewModel;
        //     base.OnNavigatedTo(args);
    }


}

