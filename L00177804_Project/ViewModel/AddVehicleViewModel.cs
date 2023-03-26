
namespace L00177804_Project.ViewModel
{
    public partial class AddVehicleViewModel:ParentViewModel
    {

        public ObservableCollection<string> FuelTypes { get; set; }

        public ObservableCollection<string> ConsumptionUnit { get; set; }

        public ObservableCollection<string> DistanceUnit { get; set; }

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
        public string name;
        [ObservableProperty]
        public string make;
        [ObservableProperty]
        public string models;
        [ObservableProperty]
        public string fuelType;
        [ObservableProperty]
        public double odometer;
        [ObservableProperty]
        public double fuelConsumption;
        [ObservableProperty]
        public string fuelUnit;
        [ObservableProperty]
        public string insurencePolicy;
        [ObservableProperty]
        public string insurenceCompany;
        [ObservableProperty]
        public string licence;


        // Create a new instance of the FuelTypes class
        FuelTypes fuelTypes = new();

        // Create a new instance of the ConsumptionUnit class
        ConsumptionUnit consumptionUnit = new();

        // Create a new instance of the DistanceUnit class
        DistanceUnit distanceUnit = new();

        public string SelectedFuelType { get; set; }

        public string SelectedConsumptionType { get; set; }


        public string SelectedDistanceType { get; set; }


        // Add fuel types to the observable collection
        public void AddFuelTypes()
        {
            FuelTypes.Add(fuelTypes.Type1);
            FuelTypes.Add(fuelTypes.Type2);
            FuelTypes.Add(fuelTypes.Type3);
            FuelTypes.Add(fuelTypes.Type4);
            FuelTypes.Add(fuelTypes.Type5);
        }

        // Add consumption Types to the observable collection
        public void AddConsumptionUnit()
        {
            ConsumptionUnit.Add(consumptionUnit.Consumption1);
            ConsumptionUnit.Add(consumptionUnit.Consumption2);
            ConsumptionUnit.Add(consumptionUnit.Consumption3);
            ConsumptionUnit.Add(consumptionUnit.Consumption4);
        }

        // Add distance unit to the observable collection
        public void AddDistanceUnit()
        {
            DistanceUnit.Add(distanceUnit.Distance1);
            DistanceUnit.Add(distanceUnit.Distance2);
        }


        [RelayCommand]
        public async Task GetVehicle()
        {
            string newName = Name;
            double ode = Odometer;
            string t = SelectedFuelType;
        }


    }
}
