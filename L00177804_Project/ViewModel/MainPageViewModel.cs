using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.LocationService;
using L00177804_Project.Service.NearByService;
using L00177804_Project.Service.VehicleInfoService;

namespace L00177804_Project.ViewModel
{
    public partial class MainPageViewModel:ParentViewModel
    {

        // Create object from Class GeoLocationService
        private readonly GoogleMapService _googleMapService = new();

        // Create object from Class LocationTrackService
        private readonly LocationTrackService _locationTrackService = new();

   
        private readonly VehicleViewModel _vehicleViewModel = new( new VehicleDataService());

        CancellationTokenSource tokenSource;
        CancellationToken token;

        // Create object from Class NearByRestService
        public ObservableCollection<NearBy> Item { get; } = new();

        // Inatialize object from NearByService
        private readonly NearByRestService nearByRestService = new();

        public ObservableCollection<Vehicle> VehiclesCollection { get; set; }

        public MainPageViewModel()
        {
            _vehicleViewModel.GetVehiclesAsync();

            AddVehiclesToMain();

            SelectVehicle = VehiclesCollection.FirstOrDefault();

            // GetNearByItemsAsync();
           // _ = GetNearByItemsAsync();
        }
        
        private Vehicle _selectVehicle;
        public Vehicle SelectVehicle
        {
            get { return _selectVehicle; }
            set
            {
                _selectVehicle = value;
                OnPropertyChanged(nameof(SelectVehicle));
            }
        }

        // Access the Vehicles property
        public void AddVehiclesToMain()
        {
            // Get vehicle data
            VehiclesCollection = _vehicleViewModel.Vehicles;

        }



        // User Location
        [ObservableProperty]
        public bool run = true;


        /// <summary>
        /// Relay Command that accesses GoogleServce to redirect to route application
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task GetDirection()
        {
            tokenSource = new();
            token = tokenSource.Token;
            try
            {
                var current = await LocationTrackService.CurrentLocation(token);

                if (current != null)
                {
                    await _googleMapService.GetGoogleMaps(current.Latitude.ToString(), current.Longitude.ToString());
                }
                // Get user location
                await _googleMapService.GetGoogleMaps("52.663857", "-8.639021");

            }
            catch (Exception ex)
            {
                // exception
                Debug.WriteLine(ex);
            }
        }

        // Method to get NearbyService rest and pass to an observable collection
        public async Task GetNearByItemsAsync()
        {
            tokenSource = new();
            token = tokenSource.Token;
            try
            {
                var current = await LocationTrackService.CurrentLocation(token);
                // Get list of nearby objects
                var near = await nearByRestService.GetNearByAsync(current.Latitude.ToString(), current.Longitude.ToString());

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




    
        //public Vehicle SelectVehicle { get; set; }


       



        [RelayCommand]
        public async Task StartTracking()
        {
            tokenSource = new();
            token = tokenSource.Token;
            if (await Permissions.RequestAsync<Permissions.LocationAlways>() != PermissionStatus.Granted)
            {
                return;
            }

            await Task.Run(() => _locationTrackService.UpdateLocation(Run, token), token);
        }




    }
}
