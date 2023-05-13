using L00177804_Project.Service.VehicleInfoService;
﻿namespace L00177804_Project;


public partial class MainPage : ContentPage
{
    
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}

