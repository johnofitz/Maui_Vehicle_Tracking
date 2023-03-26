

namespace L00177804_Project.ViewModel
{
    public partial class AddVehicleViewModel:ParentViewModel
    {
        public AddVehicleViewModel() { }
        // Vehicle properties for Model
        [ObservableProperty]
        string name;
        [ObservableProperty]
        public string make;
        [ObservableProperty]
        public string model;
        [ObservableProperty]
        public string year;
        [ObservableProperty]
        public string engineSize;
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
    }
}
