
using L00177804_Project.Service.VehicleInfoService;
using Microsoft.Maui.Controls;

namespace L00177804_Project.ViewModel
{
    /// <summary>
    ///  AddVehicleViewModel class
    /// </summary>
    public partial class AddVehicleViewModel : ParentViewModel
    {
        // Create an observable collection for the fuel types
        public ObservableCollection<string> FuelTypes { get; set; } = new();

        // Create an observable collection for the consumption unit
        public ObservableCollection<string> ConsumptionUnit { get; set; } = new();

        // Create an observable collection for the distance unit
        public ObservableCollection<string> DistanceUnit { get; set; } = new();

        /// <summary>
        ///  Constructor for the AddVehicleViewModel class
        /// </summary>
        public AddVehicleViewModel()
        {
            AddFuelTypes();
            SelectedFuelType = fuelTypes.Type1; // set Type1 as the default selected item
       
            AddConsumptionUnit();
            SelectedConsumptionType = consumptionUnit.Consumption1; // set Consumption1 as the default selected item
            // Create a new instance of the DistanceUnit class
        
            AddDistanceUnit();
            SelectedDistanceType = distanceUnit.Distance1; // set Distance1 as the default selected item

        }
        // Vehicle properties for Model
        [ObservableProperty]
        public string names;
        [ObservableProperty]
        public string makes;
        [ObservableProperty]
        public string models;
        [ObservableProperty]
        public string engineSizes;
        [ObservableProperty]
        public string odometers;
        [ObservableProperty]
        public string insurencePolicys;
        [ObservableProperty]
        public string insurenceCompanys;
        [ObservableProperty]
        public string licences;
        // Odometer convert to double
        public double odeconvert;


        // Create a new instance of the FuelTypes class
        public readonly FuelTypes fuelTypes = new();

        // Create a new instance of the ConsumptionUnit class
        public readonly ConsumptionUnit consumptionUnit = new();

        // Create a new instance of the DistanceUnit class
        public readonly DistanceUnit distanceUnit = new();

        private List<Vehicle> logging = new();

        // Selected fuel type default
        [ObservableProperty]
        public string selectedFuelType;

        // Selected consumption type default
        [ObservableProperty]
        public string selectedConsumptionType;

        // Selected distance type default
        [ObservableProperty]
        public string selectedDistanceType;

        public string ValidationCheck { get; set; }


        /// <summary>
        ///  Add fuel types to the observable collection
        /// </summary>
        public void AddFuelTypes()
        {
            FuelTypes.Add(fuelTypes.Type1);
            FuelTypes.Add(fuelTypes.Type2);
            FuelTypes.Add(fuelTypes.Type3);
            FuelTypes.Add(fuelTypes.Type4);
            FuelTypes.Add(fuelTypes.Type5);
        }

        /// <summary>
        ///  Add consumption unit to the observable collection
        /// </summary>
        public void AddConsumptionUnit()
        {
            ConsumptionUnit.Add(consumptionUnit.Consumption1);
            ConsumptionUnit.Add(consumptionUnit.Consumption2);
            ConsumptionUnit.Add(consumptionUnit.Consumption3);
            ConsumptionUnit.Add(consumptionUnit.Consumption4);
        }

        /// <summary>
        ///  Add distance unit to the observable collection
        /// </summary>
        public void AddDistanceUnit()
        {
            DistanceUnit.Add(distanceUnit.Distance1);
            DistanceUnit.Add(distanceUnit.Distance2);
        }

        // Target File to save json data
        readonly string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "vehicle.json");

        /// <summary>
        ///  Method to save the vehicle data to the json file
        /// </summary>
        /// <returns></returns>

        [RelayCommand]
        public async Task SaveVehicleData()
        {
            if (await CanSaveVehicleDataAsync() && await IsDoubleAsync(odometers))
            {
                // Convert odometer to double
                odeconvert = double.Parse(odometers);

                try
                {
                    // Create a new instance of the Vehicle class
                    Vehicle vehicle = new()
                    {
                        Name = names,
                        Make = makes,
                        Model = models,
                        EngineSize = engineSizes,
                        FuelType = SelectedFuelType,
                        Odometer = odeconvert,
                        FuelConsumption = SelectedConsumptionType,
                        Distance = SelectedDistanceType,
                        InsurencePolicy = insurencePolicys,
                        InsurenceCompany = insurenceCompanys,
                        Licence = licences,
                    };

                

                    // Check if the file exists
                    if (!File.Exists(targetFile))
                    {
                        vehicle.Id = 1;
                        logging.Add(vehicle);
                        string json = JsonConvert.SerializeObject(logging);
                        File.WriteAllText(targetFile, json);
                    }
                    // If the file exists
                    else
                    {
                        string json = File.ReadAllText(targetFile);
                        logging = JsonConvert.DeserializeObject<List<Vehicle>>(json);

                        // Set the ID for subsequent entries
                        vehicle.Id = logging.Max(v => v.Id) + 1;
                        logging.Add(vehicle);

                        string newJson = JsonConvert.SerializeObject(logging);
                        File.WriteAllText(targetFile, newJson);
                    }
                }
                catch (Exception ex)
                {
                    // Debug
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    await Shell.Current.GoToAsync($"../../{nameof(VehicleView)}");
                }
            }
        }

        /// <summary>
        ///  Method to check if the vehicle data can be saved for string information
        /// </summary>
        /// <returns> boolean true or false</returns>
        private async Task<bool> CanSaveVehicleDataAsync()
        {
            if (string.IsNullOrEmpty(names) || string.IsNullOrEmpty(makes) || string.IsNullOrEmpty(models) || names.Length > 20 || models.Length>10 || makes.Length >10)
            {
                await Shell.Current.DisplayAlert("Error!", "Required fields are blank or invalid", "OK");
                return false;
            }
            return true;
        }

        /// <summary>
        ///  Method to check if the vehicle data can be saved for double information
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Boolean true/false</returns>
        public async Task<bool> IsDoubleAsync(string value)
        {
            if(double.TryParse(value, out _) == false)
            {
                await Shell.Current.DisplayAlert("Error!", "Not a vald Odometer Reading", "OK");
            } 
            return double.TryParse(value, out _);
        }

    }
}
