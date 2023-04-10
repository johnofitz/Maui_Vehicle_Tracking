
using L00177804_Project.Service.VehicleInfoService;

namespace L00177804_Project.ViewModel
{
    /// <summary>
    ///  This Class is used to store the data for the Vehicle View 
    /// </summary>
    public partial class VehicleViewModel:ParentViewModel
    {
        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService;

        private const string _vehicleFile = "vehicle.json";
        // Create observable collection for vehicle 
        public ObservableCollection<Vehicle> Vehicles { get; set; } = new();

        /// <summary>
        ///  Constructor for the VehicleViewModel class
        ///  accepts a VehicleDataService object
        /// </summary>
        /// <param name="vehicleData"></param>
        public VehicleViewModel(VehicleDataService vehicleData) {
            
            VehicleDataService = vehicleData;
            GetVehiclesAsync();
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
        public async void GetVehiclesAsync()
        {
            try
            {
                var item = await VehicleDataService.GetVehiclesInfo(_vehicleFile);

                // condition to clear menu for erroneous behaviour
                if (Vehicles.Count != 0)
                    Vehicles.Clear();
                // Add the vehicle data to the observable collection
                item.ForEach(Vehicles.Add);

                // condition to check if the observable collection is empty
                if(Vehicles is null)
                {
                    await GoToAddVehicle();
                }
            }
            // Catch errors
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
