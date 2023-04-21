using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.LocationService;
using L00177804_Project.Service.NearByService;
using L00177804_Project.Service.VehicleInfoService;
using Mopups.Services;

namespace L00177804_Project.ViewModel
{
    public partial class MainPageViewModel : ParentViewModel
    {

        private const string _vehicleFile = "vehicle.json";

        // Create object from Class LocationTrackService
        private readonly LocationTrackService _locationTrackService = new();

        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService;


        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        // User Location
        [ObservableProperty]
        public bool run = true;


        // Create object from Class NearByRestService
        public ObservableCollection<NearBy> Item { get; } = new();

        // Inatialize object from NearByService
        private readonly NearByRestService nearByRestService = new();

        // Create observable collection for vehicle
        public ObservableCollection<Vehicle> VehiclesCollection { get; set; } = new();

        [ObservableProperty]
        private Vehicle _selectVehicle;

        /// <summary>
        /// Constructor for the MainPageViewModel class
        /// </summary>
        /// <param name="vehicleData"></param>
        public MainPageViewModel(VehicleDataService vehicleData)
        {
            // Create an instance of the VehicleDataService class
            VehicleDataService = vehicleData;

            // Get Vehicle data from json file
            _ = AddVehiclesToMainAsync();

            // Get NearBy Fuel stations within 1.5km
            _ = GetNearByItemsAsync();
        }
    
        /// <summary>
        /// This method adds vehicle information to a collection 
        /// and selects a default vehicle.
        /// </summary>
        /// <returns></returns>
        public async Task AddVehiclesToMainAsync()
        {
            try
            {
                // Get the vehicle information from a file using the VehicleDataService.
                var item = await VehicleDataService.GetVehiclesInfo(_vehicleFile);

                // If the VehiclesCollection already has items, clear them out.
                if (VehiclesCollection.Count != 0)
                {
                    VehiclesCollection.Clear();
                }

                // Add each vehicle in the item list to the VehiclesCollection.
                item.ForEach(VehiclesCollection.Add);

                // Get the name of the default vehicle from the user's preferences.
                string check = VehiclesCollection.Select(x => x.Name).FirstOrDefault();
                var cars = Preferences.Get("cars", check);

                // Set the SelectVehicle property to the default vehicle.
                SelectVehicle = VehiclesCollection.Single(x => x.Name == cars);
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }


        /// <summary>
        /// Relay Command that accesses GoogleServce to redirect to route application
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task GetDirection()
        {
            // Create a new cancellation token source and token.
            tokenSource = new();
            token = tokenSource.Token;

            try
            {
                // Get the current location using the LocationTrackService.
                var current = await LocationTrackService.CurrentLocation(token);

                // If the current location is not null, get directions from Google Maps
                // by passing the current latitude and longitude to the GetGoogleMaps method.
                if (current != null)
                {
                    await GoogleMapService.GetGoogleMaps(current.Latitude.ToString(), current.Longitude.ToString());
                }

                // Get directions from Google Maps using a fallback location (52.663857, -8.639021)
                // in case the current location could not be retrieved or is null.
                await GoogleMapService.GetGoogleMaps("52.663857", "-8.639021");
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        ///  Relay Command that accesses NearByRestService to get nearby fuel stations
        ///  within 1.5km radius
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        ///  Relay Command that accesses LocationTrackService to start tracking user location
        /// </summary>
        /// <returns></returns>

        [RelayCommand]
        public async Task StartTracking()
        {
            // Create a new cancellation token source and token.
            tokenSource = new();
            token = tokenSource.Token;

            // Request the LocationAlways permission from the user.
            // If the permission is not granted, return from the method.
            if (await Permissions.RequestAsync<Permissions.LocationAlways>() != PermissionStatus.Granted)
            {
                return;
            }
            // Start a new background task that updates the device's location.
            // The task takes a delegate (method) to run and the cancellation token.
            await Task.Run(() => _locationTrackService.UpdateLocation(Run, token), token);
        }


        /// <summary>
        /// Command to go to fuel station via google maps service
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task GoToFuelStation(NearBy nearBy)
        {
           
            // Create a new cancellation token source and token.
            tokenSource = new();
            token = tokenSource.Token;
            try
            {
                bool answer = await Shell.Current.DisplayAlert("Track Journey", "Would you like to track this trip", "Yes", "No");

                // Get the current location using the LocationTrackService.
                var current = await LocationTrackService.CurrentLocation(token);

                if (answer)
                {
                    await StartTracking();
                }
                // If the current location is not null, get directions from Google Maps
                // by passing the current latitude and longitude to the GetGoogleMaps method.
                if (current != null)
                {
                    await GoogleMapService.GetGoogleMapsRoute(current.Latitude.ToString(), current.Longitude.ToString(),nearBy.Geometry.Location.Latitiude.ToString(), nearBy.Geometry.Location.Longitude.ToString());
                }
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
            
        }

        [RelayCommand]
        public static void GoToSelection()
        {
            MopupService.Instance.PushAsync(new PopUpView());
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="distance"></param>
        ///// <param name="fuelConsumption"></param>
        ///// <returns></returns>
        //private int CalculateCarbonEmissions(int distance, int fuelConsumption)
        //{
        //    return 0;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="distance"></param>
        ///// <param name="fuelConsumption"></param>
        ///// <returns></returns>
        //private int CalculateAverageFuelUsed(int distance, int fuelConsumption)
        //{
        //    return 0;
        //}
    }
}

