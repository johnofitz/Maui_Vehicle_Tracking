using L00177804_Project.Models.TripModel;
using L00177804_Project.Service.TripService;
using L00177804_Project.Service.VehicleInfoService;


namespace L00177804_Project.ViewModel
{
    public partial class ReminderViewModel: ParentViewModel
    {

        private const string _vehicleFile = "vehicle.json";

        private const string _tripFile = "trips.json";
        public ObservableCollection<TripSummary> Summaries { get; set; } = new();

        // Create observable collection for vehicle
        public ObservableCollection<Vehicle> VehiclesCollection { get; set; } = new();

        private readonly TripServiceLog _tripServiceLog = new();

        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService = new();

        [ObservableProperty]
        private Vehicle _selectVehicle;


        public ReminderViewModel()
        {
            Heading = "Reminders";
            LoadServiceDate();

        }


        public async void LoadServiceDate()
        {
            try
            {
                // Get the trip information from a file using the tripService.
                var tripLogs = await _tripServiceLog.GetVehiclesInfo(_tripFile);

                var vehicleEmissions = tripLogs.GroupBy(t => t.Vehicle)
                    .Select(g => new
                    {
                        Vehicle = g.Key,
                        TotalEmissions = g.Sum(t => t.CarbonEmissions),
                        TotalFuelConsumed = g.Sum(t => t.FuelConsumed),
                        ServiceDistance = g.Sum(t => t.DistInt),
                        TotalTripCosts = g.Sum(t => t.TripCosts)
                    });

                foreach (var vehicle in vehicleEmissions)
                {
                    TripSummary tripSummary = new()
                    {
                        Vehicle = vehicle.Vehicle,
                        TotalCarbonEmissions = vehicle.TotalEmissions,
                        TotalFuelConsumed = vehicle.TotalFuelConsumed,
                        ServiceDistance = 10000-vehicle.ServiceDistance/1000,
                        TotalTripCosts = vehicle.TotalTripCosts
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
