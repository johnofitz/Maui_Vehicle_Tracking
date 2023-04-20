using L00177804_Project.Service.VehicleInfoService;


namespace L00177804_Project.ViewModel
{
    [QueryProperty("Vehicle", "Vehicle")]
    public partial class EditVehicleViewModel : ParentViewModel
    {
        // Create a new vehicle object
        public AddVehicleViewModel VehicleViewModel = new();

        // Create an observable collection for the fuel types
        public ObservableCollection<string> FuelTypes { get; set; }

        // Create an observable collection for the consumption unit
        public ObservableCollection<string> ConsumptionUnit { get; set; }

        // Create an observable collection for the distance unit
        public ObservableCollection<string> DistanceUnit { get; set; }

        [ObservableProperty]
        Vehicle vehicle;

        readonly string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "vehicle.json");
        // Selected fuel type default
        public string SelectedFuelType { get; set; }

        // Selected consumption type default
        public string SelectedConsumptionType { get; set; }

        // Selected distance type default
        public string SelectedDistanceType { get; set; }

        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService;

        // Create object from Class VehicleViewModel for page redirection

        private readonly VehicleViewModel vehicleViewModel = new(new VehicleDataService());

        private readonly MainPageViewModel mainPageViewModel = new(new VehicleDataService());

        public EditVehicleViewModel(VehicleDataService vehicleDataService)
        {

            // Create an instance of the VehicleDataService class
            VehicleDataService = vehicleDataService;

            AddConsumptionUnit();

            AddDistanceUnit();

            AddFuelTypes();
        }

        /// <summary>
        ///  Method that adds the consumption unit to the observable collection
        /// </summary>
        private void AddConsumptionUnit()
        {
            ConsumptionUnit = new ObservableCollection<string>
            {
                VehicleViewModel.consumptionUnit.Consumption1,
                VehicleViewModel.consumptionUnit.Consumption2,
                VehicleViewModel.consumptionUnit.Consumption3
            };
        }

        /// <summary>
        /// Method that adds the distance unit to the observable collection
        /// </summary>
        private void AddDistanceUnit()
        {
            DistanceUnit = new ObservableCollection<string>
            {
                VehicleViewModel.distanceUnit.Distance1,
                VehicleViewModel.distanceUnit.Distance2
            };
        }

        /// <summary>
        /// Method that adds the fuel types to the observable collection
        /// </summary>
        private void AddFuelTypes()
        {
            FuelTypes = new ObservableCollection<string>
            {
                VehicleViewModel.fuelTypes.Type1,
                VehicleViewModel.fuelTypes.Type2
            };
        }

        /// <summary>
        /// Method that gets the vehicle info from the json file
        /// and edit is
        /// </summary>
        /// <returns></returns>

        [RelayCommand]
        public async Task EditVehicleData()
        {
            try
            {
                // Get the vehicle data from the json file
                var vehicles = await VehicleDataService.GetVehiclesInfo(targetFile);

                // Find the object to update
                int idToUpdate = Vehicle.Id;

                Vehicle vehicleToUpdate = vehicles.FirstOrDefault(v => v.Id == idToUpdate);

                if (vehicleToUpdate != null)
                {
                    // Modify the object
                    vehicleToUpdate.Id = Vehicle.Id;
                    vehicleToUpdate.Name = Vehicle.Name;
                    vehicleToUpdate.Make = Vehicle.Make;
                    vehicleToUpdate.Model = Vehicle.Model;
                    vehicleToUpdate.EngineSize = Vehicle.EngineSize;
                    vehicleToUpdate.FuelType = Vehicle.FuelType;
                    vehicleToUpdate.Odometer = Vehicle.Odometer;
                    vehicleToUpdate.FuelConsumption = Vehicle.FuelConsumption;
                    vehicleToUpdate.Distance = Vehicle.Distance;
                    vehicleToUpdate.InsurencePolicy = Vehicle.InsurencePolicy;
                    vehicleToUpdate.InsurenceCompany = Vehicle.InsurenceCompany;
                    vehicleToUpdate.Licence = Vehicle.Licence;
                    // Update other properties as needed
                }

                // Serialize the updated object back to JSON
                string updatedJson = JsonConvert.SerializeObject(vehicles);
                File.WriteAllText(targetFile, updatedJson);


            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine($"Error editing vehicle data: {ex.Message}");
            }

            // Route to previous page
            await Shell.Current.GoToAsync($"//{nameof(VehicleView)}");
        }

        /// <summary>
        /// Method that removes vehicle info from json file
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task DeleteVehicle()
        {
            try
            {
                // Get the vehicle data from the json file
                var vehicles = await VehicleDataService.GetVehiclesInfo(targetFile);

                // Find the object to update
                int vehicleIdToDelete = Vehicle.Id;

                // Find the vehicle to delete based on certain ID
                Vehicle vehicleToDelete = vehicles.FirstOrDefault(v => v.Id == vehicleIdToDelete);

                if (vehicleToDelete != null)
                {
                    // Remove the vehicle from the list
                    vehicles.Remove(vehicleToDelete);

                    if (vehicles.Count == 0)
                    {
                        // Delete the entire file if there are no vehicles left
                        File.Delete(targetFile);
                    }
                    else
                    {
                        // Serialize the updated list back to JSON
                        string json = JsonConvert.SerializeObject(vehicles);

                        // Save the updated JSON to the file
                        File.WriteAllText(targetFile, json);
                    }

                    // Route to previous page
                    await Shell.Current.GoToAsync($"//{nameof(VehicleView)}");
                }
            }
            catch (Exception ex)
            {
                // Debug or handle any exceptions that may occur during the deletion process
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}
