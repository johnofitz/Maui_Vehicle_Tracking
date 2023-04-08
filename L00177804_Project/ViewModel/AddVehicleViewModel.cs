
namespace L00177804_Project.ViewModel
{
    public partial class AddVehicleViewModel:ParentViewModel
    {
        // Create an observable collection for the fuel types
        public ObservableCollection<string> FuelTypes { get; set; }

        // Create an observable collection for the consumption unit

        public ObservableCollection<string> ConsumptionUnit { get; set; }

        // Create an observable collection for the distance unit
        public ObservableCollection<string> DistanceUnit { get; set; }

        /// <summary>
        ///  Constructor for the AddVehicleViewModel class
        /// </summary>
        public AddVehicleViewModel() {

            FuelTypes = new ObservableCollection<string>();
            AddFuelTypes();
            SelectedFuelType = fuelTypes.Type1; // set Type1 as the default selected item

            ConsumptionUnit = new ObservableCollection<string>();
            AddConsumptionUnit();
            SelectedConsumptionType = consumptionUnit.Consumption1; // set Consumption1 as the default selected item

            DistanceUnit = new ObservableCollection<string>();
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
        public double odometers;
        [ObservableProperty]
        public string insurencePolicys;
        [ObservableProperty]
        public string insurenceCompanys;
        [ObservableProperty]
        public string licences;


        // Create a new instance of the FuelTypes class
        private readonly FuelTypes fuelTypes = new();

        // Create a new instance of the ConsumptionUnit class
        private readonly ConsumptionUnit consumptionUnit = new();

        // Create a new instance of the DistanceUnit class
        private readonly DistanceUnit distanceUnit = new();

        private List<Vehicle> logging = new();

        // Selected fuel type default
        public string SelectedFuelType { get; set; }

        // Selected consumption type default
        public string SelectedConsumptionType { get; set; }

        // Selected distance type default
        public string SelectedDistanceType { get; set; }


        // Add fuel types to the observable collection
        private void AddFuelTypes()
        {
            FuelTypes.Add(fuelTypes.Type1);
            FuelTypes.Add(fuelTypes.Type2);
            FuelTypes.Add(fuelTypes.Type3);
            FuelTypes.Add(fuelTypes.Type4);
            FuelTypes.Add(fuelTypes.Type5);
        }

        // Add consumption Types to the observable collection
        private void AddConsumptionUnit()
        {
            ConsumptionUnit.Add(consumptionUnit.Consumption1);
            ConsumptionUnit.Add(consumptionUnit.Consumption2);
            ConsumptionUnit.Add(consumptionUnit.Consumption3);
            ConsumptionUnit.Add(consumptionUnit.Consumption4);
        }

        // Add distance unit to the observable collection
        private void AddDistanceUnit()
        {
            DistanceUnit.Add(distanceUnit.Distance1);
            DistanceUnit.Add(distanceUnit.Distance2);
        }

        // Target File to save json data
        readonly string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "vehicle.json");

        // Method used To save vehicle data

        [RelayCommand]
        public async Task SaveVehicleData()
        {
            try
            {
                Vehicle vehicle = new()
                {
                    Name = names,
                    Make = makes,
                    Model = models,
                    EngineSize = engineSizes,
                    FuelType = SelectedFuelType,
                    Odometer = odometers,
                    FuelConsumption = SelectedConsumptionType,
                    Distance = SelectedDistanceType,
                    InsurencePolicy = insurencePolicys,
                    InsurenceCompany = insurenceCompanys,
                    Licence = licences,
                };

                if (!File.Exists(targetFile))
                {
                    logging.Add(vehicle);
                    string json = JsonConvert.SerializeObject(logging);
                    File.WriteAllText(targetFile, json);
                }
                else
                {
                    string json = File.ReadAllText(targetFile);
                    logging = JsonConvert.DeserializeObject<List<Vehicle>>(json);
                    logging.Add(vehicle);
                    string newJson = JsonConvert.SerializeObject(logging);
                    File.WriteAllText(targetFile, newJson);
                }
            }
            catch(Exception ex)
            {
                // Debug
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                // Route to previous page
                await Shell.Current.GoToAsync("..//..");
            }
        }
    }
}
