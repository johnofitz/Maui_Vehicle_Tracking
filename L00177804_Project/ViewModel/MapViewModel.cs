
namespace L00177804_Project.ViewModel
{
    /// <summary>
    /// Map Class used to initalize Google Maps API
    /// </summary>
    public partial class MapViewModel: ParentViewModel
    {
    
        public MapViewModel()
        {
            // Open map at default location
        }


        [ObservableProperty]
        public bool userLocation = true;

        [RelayCommand]
        public static async void GetDirection()
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?daddr=52.6676407,-8.724467");
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync("http://maps.google.com/?daddr=52.6676407,-8.724467");
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            {
                await Launcher.OpenAsync("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052");
            }

        
        }
    }
}
