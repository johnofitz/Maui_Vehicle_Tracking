using Microsoft.Maui.Devices.Sensors;

namespace L00177804_Project.ViewModel
{
    /// <summary>
    /// Map Class used to initalize Google Maps API
    /// </summary>
    public partial class MapViewModel: ParentViewModel
    {
        // Create object from Class GeoLocationService
        private readonly GoogleMapService _googleMapService = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="googleMapService"></param>
        public MapViewModel()
        {
         
        }


        // User Location
        [ObservableProperty]
        public bool userLocation = true;


        /// <summary>
        /// Relay Command that accesses GoogleServce to redirect to route application
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task GetDirection()
        {
            await _googleMapService.GetGoogleMaps(); 
     
        }



        
    }
}
