
using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.NearByService;


namespace L00177804_Project.ViewModel
{
    /// <summary>
    /// Map Class used to initalize Google Maps API
    /// </summary>
    public partial class MapViewModel : ParentViewModel
    {
        // Create object from Class GeoLocationService
        private readonly GoogleMapService _googleMapService = new();

        private Locations _currentlocations = new();

        private double oldLat =0;
        private double oldLng=0;


        CancellationTokenSource tokenSource;
        CancellationToken token;


        // Create object from Class NearByRestService
        public ObservableCollection<NearBy> Item { get; } = new();

        // Inatialize object from NearByService
        private readonly NearByRestService nearByRestService = new();
        public MapViewModel()
        {
            _ = GetNearByItemsAsync();
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

            PermissionStatus permissionStatus = await Permissions.RequestAsync<Permissions.LocationAlways>();

            if (permissionStatus == PermissionStatus.Granted)
            {
                Task locationTask = Task.Run(() => UpdateLocation(token), token);
            }

        }

        private async Task UpdateLocation(CancellationToken ct)
        {
            while (true)
            {
                // Request the device's location with the best accuracy and a 5-second timeout
                GeolocationRequest request = new(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
                CancellationTokenSource cancelTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct);
                Location location = null;

                try
                {
                    // Use the cancellation token to abort the location request if needed
                    location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token);

                    _currentlocations.Lat = location.Latitude;
                    _currentlocations.Lng = location.Longitude;
                    _currentlocations.Speed = (double)location.Speed;

                }
                catch (TaskCanceledException)
                {
                    // Debug cancelation exception
                    Debug.WriteLine("Location request canceled");

                }

                finally
                {

                    if(_currentlocations != null && oldLat !=0 && oldLng !=0)
                    {
                        Location oldDist = new(oldLat, oldLng);
                        Location newDist = new(_currentlocations.Lat, _currentlocations.Lng);
                        double km = Location.CalculateDistance(oldDist, newDist, DistanceUnits.Kilometers);
                    }

                    oldLat = _currentlocations.Lat;
                    oldLng = _currentlocations.Lng;
                }

                // Wait for the location to be retrieved
                while (location == null)
                {
                    Thread.Sleep(1000);

                    if (ct.IsCancellationRequested)
                    {
                        // If cancellation is requested, break out of the loop
                        return;
                    }
                }
                // Wait for 3 seconds before requesting the next location
                await Task.Delay(3000, ct);

            }
        }
    }

}
