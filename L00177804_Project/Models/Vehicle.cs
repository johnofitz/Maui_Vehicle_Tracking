
namespace L00177804_Project.Models
{

    public partial class Vehicle:ObservableObject
    {

        public Vehicle(){}

        public Vehicle(string name)
        {
            Name = name;
        }

        [ObservableProperty] public int id;

        [ObservableProperty] public string name;

        [ObservableProperty] public string make;

        [ObservableProperty] public string model;

        [ObservableProperty] public string fuelType;

        [ObservableProperty] public double odometer;

        [ObservableProperty] public string engineSize;

        [ObservableProperty] public string fuelConsumption;

        [ObservableProperty] public string insurencePolicy;

        [ObservableProperty] public string insurenceCompany;


        [ObservableProperty] public string licence;

        [ObservableProperty] public string distance;

        public override string ToString()
        {
            return Name;
        }

    }
}
