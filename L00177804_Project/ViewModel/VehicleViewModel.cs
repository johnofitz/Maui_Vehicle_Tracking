
namespace L00177804_Project.ViewModel
{
    /// <summary>
    ///  This Class is used to store the data for the Vehicle View
    ///  
    /// </summary>
    public partial class VehicleViewModel:ParentViewModel
    {

        public VehicleViewModel() { }

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
