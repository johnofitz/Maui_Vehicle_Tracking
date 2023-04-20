
namespace L00177804_Project.ViewModel
{
    public partial class AddTripViewModel: ParentViewModel
    {

        public AddTripViewModel() { }


        [ObservableProperty]
        public string tripName;

        [ObservableProperty]
        public string tripDate;

        [ObservableProperty]
        public double odemeterStart;

        [ObservableProperty]
        public double odemeterEnd;

        [ObservableProperty]
        public double tripDistance;

        [ObservableProperty]
        public double tripCost;

        [ObservableProperty]
        public string tripNotes;

        [ObservableProperty]
        public double tripConsumption;


        [RelayCommand]
        public Task AddTrip()
        {
            return Task.CompletedTask;
        }

        
    }
}
