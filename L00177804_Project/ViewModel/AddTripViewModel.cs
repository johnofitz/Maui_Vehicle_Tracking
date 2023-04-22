
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
        public string odemeterStart;

        [ObservableProperty]
        public string odemeterEnd;

        [ObservableProperty]
        public string tripDistance;

        [ObservableProperty]
        public string tripCost;

        [ObservableProperty]
        public string tripNotes;

        [ObservableProperty]
        public string tripConsumption;

        [ObservableProperty]
        public string origin;

        [ObservableProperty]
        public string destination;

        [RelayCommand]
        public Task AddTrip()
        {
            return Task.CompletedTask;
        }

        
    }
}
