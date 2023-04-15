
namespace L00177804_Project.ViewModel
{
    public partial class ParentViewModel:ObservableObject
    {
        // Source gennerators will  automatically complete through partial class generation 
        // This generates basic getters and setters
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public bool isBusy;

        [ObservableProperty]
        public string heading;

        // Lambda function to check if not busy
        public bool IsNotBusy => !IsBusy;



        [ObservableProperty]
        public string vehicleName;

        [ObservableProperty]
        public double vehicleKm;

    }
}
