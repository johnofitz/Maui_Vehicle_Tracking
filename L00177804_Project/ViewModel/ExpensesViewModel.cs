using L00177804_Project.Models.TripModel;
using L00177804_Project.Service.TripService;
using L00177804_Project.Service.VehicleInfoService;


namespace L00177804_Project.ViewModel
{
    public partial class ExpensesViewModel:ParentViewModel
    {

        private const string _tripFile = "trips.json";
        public ObservableCollection<TripSummary> Summaries { get; set; } = new();

        // Create observable collection for vehicle
        public ObservableCollection<Trip> VehiclesCollection { get; set; } = new();

        private readonly TripServiceLog _tripServiceLog = new();


        [ObservableProperty]
        private Vehicle _selectVehicle;


        public ExpensesViewModel()
        {
            Heading = "Expense Summary";
            LoadServiceDate();

        }


        public async void LoadServiceDate()
        {
            try
            {
                // Get the trip information from a file using the tripService.
                var item = await _tripServiceLog.GetVehiclesInfo(_tripFile);

                item.ForEach(VehiclesCollection.Add);

                var vehicleEmissions = item.GroupBy(t => t.Vehicle)
                                        .Select(g => new
                                        {
                                            Vehicle = g.Key,
                                            TotalEmissions = g.Sum(t => t.CarbonEmissions),
                                            TotalTripCosts = g.Sum(t => t.TripCosts)

                                        });


                foreach (var vehicle in vehicleEmissions)
                {
                    TripSummary tripSummary = new()
                    {
                        Vehicle = vehicle.Vehicle,
                        TotalTripCosts = vehicle.TotalTripCosts,
                        TotalCarbonEmissions = vehicle.TotalEmissions
                    };
                    Summaries.Add(tripSummary);
                }

            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
                return;
            }
        }




    }
}
