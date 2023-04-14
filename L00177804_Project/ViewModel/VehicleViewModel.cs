
using L00177804_Project.Service.VehicleInfoService;


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

        /// <summary>
        ///  Constructor for the VehicleViewModel class
        ///  accepts a VehicleDataService object
        /// </summary>
        /// <param name="vehicleData"></param>
       
        public VehicleViewModel(VehicleDataService vehicleData) {
            
            VehicleDataService = vehicleData;
            
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
        public async Task GetVehiclesAsync()
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
