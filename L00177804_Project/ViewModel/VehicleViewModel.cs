
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
   

        private const string _vehicleFile = "vehicle.json";

        // Create observable collection for vehicle 
        [ObservableProperty]
        private ObservableCollection<Vehicle> _vehicles = new();


        [ObservableProperty]
        private Vehicle preferedVehicle;


 
        /// <summary>
        ///  Constructor for the VehicleViewModel class
        ///  accepts a VehicleDataService object
        /// </summary>


        public VehicleViewModel() {
            
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
            VehicleDataService VehicleDataService = new();
            if (IsBusy)
                return;
            try
            {
                IsBusy = true; // Set busy flag


                // Get the vehicle data from the json file
                var item = await VehicleDataService.GetVehiclesInfo(_vehicleFile);

                // condition to clear menu for erroneous behaviour
                if (_vehicles.Count != 0)
                    _vehicles.Clear();
                // Add the vehicle data to the observable collection    
                item.ForEach(_vehicles.Add);

                var cars = Preferences.Get("cars", "Work");

                PreferedVehicle = _vehicles.Single(x => x.Name == cars);
            }
            // Catch errors
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally {
                IsBusy = false;
                IsRefreshing = false;
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

    
    }
}
