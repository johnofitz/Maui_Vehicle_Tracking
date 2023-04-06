
using L00177804_Project.Service.VehicleInfoService;

namespace L00177804_Project.ViewModel
{
    /// <summary>
    ///  This Class is used to store the data for the Vehicle View
    ///  
    /// </summary>
    public partial class VehicleViewModel:ParentViewModel
    {
        // 
        private readonly VehicleDataService VehicleDataService;

        // Create observable collection for vehicle 
        public ObservableCollection<Vehicle> Vehicles { get; set; }


        public VehicleViewModel(VehicleDataService vehicleData) {
            
            this.VehicleDataService = vehicleData;
            Vehicles = new ObservableCollection<Vehicle>();
            GetVehiclesAsync();
        }


        [RelayCommand]
        public async Task GoToAddVehicle()
        {
            await Shell.Current.GoToAsync(nameof(AddVehicleView));
        }
        private readonly string _file = "vehicle.json";
        /// <summary>
        ///  Method to get the vehicle data from the json file
        /// </summary>
        public async void GetVehiclesAsync()
        {
            try
            {
                var item = await VehicleDataService.GetVehiclesInfo(_file);

                // condition to clear menu for erroneous behaviour
                if (Vehicles.Count != 0)
                    Vehicles.Clear();

                item.ForEach(Vehicles.Add);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"No File History Found: {ex.Message}");
                await Shell.Current.DisplayAlert("Error! No File History Found", ex.Message, "OK");
            }
        }
    }
}
