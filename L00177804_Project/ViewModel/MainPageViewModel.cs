using CommunityToolkit.Mvvm.ComponentModel;
using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.LocationService;
using L00177804_Project.Service.NearByService;
using L00177804_Project.Service.VehicleInfoService;
using System.Windows.Input;

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
            //_ = GetNearByItemsAsync();
        }
        [ObservableProperty]
        private Vehicle _selectVehicle;


        // Access the Vehicles property
        public async Task AddVehiclesToMainAsync()
        {
            try
            {
                // Get the vehicle data from the json file
                var item = await VehicleDataService.GetVehiclesInfo(_vehicleFile);

                // condition to clear menu for erroneous behaviour
                if (VehiclesCollection.Count != 0)
                {
                    VehiclesCollection.Clear();
                }
                // Add the vehicle data to the observable collection
                item.ForEach(VehiclesCollection.Add);

                string check = VehiclesCollection.Select(x => x.Name).FirstOrDefault();

                var cars = Preferences.Get("cars", check);


                SelectVehicle = VehiclesCollection.Single(x => x.Name == cars);

            }
            // Catch errors
            catch (Exception ex)
            {
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
            tokenSource = new();
            token = tokenSource.Token;
            try
            {
                var current = await LocationTrackService.CurrentLocation(token);

                if (current != null)
                {
                    await GoogleMapService.GetGoogleMaps(current.Latitude.ToString(), current.Longitude.ToString());
                }
                // Get user location
                await GoogleMapService.GetGoogleMaps("52.663857", "-8.639021");

            }
            catch (Exception ex)
            {
                // exception
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
            tokenSource = new();
            token = tokenSource.Token;
            if (await Permissions.RequestAsync<Permissions.LocationAlways>() != PermissionStatus.Granted)
            {
                return;
            }

            await Task.Run(() => _locationTrackService.UpdateLocation(Run, token), token);
        }

        [RelayCommand]
        public async Task GoToFuelStation()
        {


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="fuelConsumption"></param>
        /// <returns></returns>
        private int CalculateCarbonEmissions(int distance, int fuelConsumption)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="fuelConsumption"></param>
        /// <returns></returns>
        private int CalculateAverageFuelUsed(int distance, int fuelConsumption)
        {
            return 0;
        }
    }
}

