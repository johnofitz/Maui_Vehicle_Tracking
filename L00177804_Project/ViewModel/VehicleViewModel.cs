
using CommunityToolkit.Mvvm.Messaging;
using L00177804_Project.Service.VehicleInfoService;
using L00177804_Project.Service.VehicleStoreService;

namespace L00177804_Project.ViewModel
{
    /// <summary>
    ///  This Class is used to store the data for the Vehicle View 
    /// </summary>
    public partial class VehicleViewModel:ParentViewModel
    {

        [ObservableProperty]
        bool _isRefreshing;
        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService;

        private const string _vehicleFile = "vehicle.json";

        // Create observable collection for vehicle 
        [ObservableProperty]
        private ObservableCollection<Vehicle> _vehicles;


        [ObservableProperty]
        private Vehicle preferedVehicle;


        // Create observable collection for vehicle
        public ObservableCollection<Vehicle> VehiclesCollection { get; set; } = new();
        /// <summary>
        ///  Constructor for the VehicleViewModel class
        ///  accepts a VehicleDataService object
        /// </summary>
        /// <param name="vehicleData"></param>

        public VehicleViewModel(VehicleDataService vehicleData) {
            
            VehicleDataService = vehicleData;
            AddVehicles();
            _ = GetVehiclesAsync();
        }

        /// <summary>
        ///  Method used to navigate to the AddVehicleView
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task GoToAddVehicle()
        {
            await Shell.Current.GoToAsync(nameof(AddVehicleView));
        }

        /// <summary>
        /// Method used to navigate to the EditVehicleView
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>

        [RelayCommand]
        public async Task GoToEditVehicle(Vehicle vehicle)
        {
            if (vehicle.Name == null) return;

            await Shell.Current.GoToAsync(nameof(EditVehicleView), true, new Dictionary<string, object>
            {
            {"Vehicle", vehicle }
            });
        }

        /// <summary>
        ///  Method to get the vehicle data from the json file
        /// </summary>
        [RelayCommand]
        public virtual async Task GetVehiclesAsync()
        {
            try
            {
                _vehicles = new ObservableCollection<Vehicle>();

                // Get the vehicle data from the json file
                var item = await VehicleDataService.GetVehiclesInfo(_vehicleFile);

                // condition to clear menu for erroneous behaviour
                if (_vehicles.Count != 0)
                    _vehicles.Clear();
                // Add the vehicle data to the observable collection    
                item.ForEach(_vehicles.Add);
            }
            // Catch errors
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }



        /// <summary>
        /// This method adds vehicle information to a collection 
        /// and selects a default vehicle.
        /// </summary>
        /// <returns></returns>
        public async void AddVehicles()
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
                //string check = VehiclesCollection.Select(x => x.Name).FirstOrDefault();
                //var cars = Preferences.Get("cars", check);

                //// Set the SelectVehicle property to the default vehicle.
                ///
                //preferedVehicle = VehiclesCollection.Single(x => x.Name == cars);
                var cars = Preferences.Get("cars", "Work");

                PreferedVehicle = VehiclesCollection.Single(x => x.Name == cars);
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }


        partial void OnPreferedVehicleChanged(Vehicle value)
        {
            if (value == null)
            {
                return;
            }

            Preferences.Set("cars", value.Name);

            WeakReferenceMessenger.Default.Send(new VehicleChangedMessage(value.Name));
        }

        [RelayCommand]
        public async Task Refresh()
        {
            await Task.Delay(100);
            IsRefreshing = true;
            _ = GetVehiclesAsync();
       
            IsRefreshing = false;
        }
    }
}
