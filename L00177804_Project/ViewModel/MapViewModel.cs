
using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.LocationService;
using L00177804_Project.Service.NearByService;


namespace L00177804_Project.ViewModel
{
    /// <summary>
    ///  MapViewModel Class
    /// </summary>
    public partial class MapViewModel : ParentViewModel
    {
        // Create object from Class GeoLocationService
        private readonly GoogleMapService _googleMapService = new();

        // Create object from Class LocationTrackService
        private readonly LocationTrackService _locationTrackService = new();

        
        CancellationTokenSource tokenSource;
        CancellationToken token;


        // Create object from Class NearByRestService
        public ObservableCollection<NearBy> Item { get; } = new();

        // Inatialize object from NearByService
        private readonly NearByRestService nearByRestService = new();

        /// <summary>
        /// MapViewModel Constructor
        /// </summary>
        public MapViewModel()
        {
            //_ = GetNearByItemsAsync();
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
            // Get user location
            await _googleMapService.GetGoogleMaps();


        }

        // Method to get NearbyService rest and pass to an observable collection
        public async Task GetNearByItemsAsync()
        {
            try
            {
                // Get list of nearby objects
                var near = await nearByRestService.GetNearByAsync();

                // Condition to check if items are already loaded
                if (Item.Count != 0)
                {
                    Item.Clear();
                }

                // Add nearby objects to observable collection
                near.ForEach(Item.Add);
            }
            catch (Exception ex)
            {
                // Catch exceptions and display
                Debug.WriteLine($"Unable to get menu: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }



        [RelayCommand]
        public async Task StartTracking()
        {
            tokenSource = new();
            token = tokenSource.Token;

            if (await Permissions.RequestAsync<Permissions.LocationAlways>() != PermissionStatus.Granted)
            {
                return;
            }

            await Task.Run(() => _locationTrackService.UpdateLocation(token), token);
        }

    }

}
