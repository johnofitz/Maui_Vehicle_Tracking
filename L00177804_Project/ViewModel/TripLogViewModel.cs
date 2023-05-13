using L00177804_Project.Models.TripModel;
using L00177804_Project.Service.TripService;

namespace L00177804_Project.ViewModel
{
    public partial class TripLogViewModel: ParentViewModel
    {

        private const string _tripFile = "trips.json";

        private readonly TripServiceLog _tripServiceLog = new();

        public ObservableCollection<Trip> TripCollection { get; set; } = new();

        public ObservableCollection<TripSummary> Summaries { get; set; } = new();


        public TripLogViewModel()
        {
            Heading = "Trip Stats";
            LoadTripLogs();
        }


        public async void LoadTripLogs()
        {
            try
            {
                // Get the trip information from a file using the tripService.
                var item = await _tripServiceLog.GetVehiclesInfo(_tripFile);

                // If the tripollection already has items, clear them out.
                if (TripCollection.Count != 0)
                {
                    TripCollection.Clear();
                }
                var recentTrips = item.OrderByDescending(t => t.TripDates) // sort by date, most recent first
                      .Take(4) // take the most recent 5 trips
                      .ToList();
                recentTrips.ForEach(TripCollection.Add);



                var vehicleEmissions = item.GroupBy(t => t.Vehicle)
                    .Select(g => new
                    {
                        Vehicle = g.Key,
                        TotalEmissions = g.Sum(t => t.CarbonEmissions),
                        TotalFuelConsumed = g.Sum(t => t.FuelConsumed),
                        TotalTripDistances =  g.Sum(t => t.DistInt/1000),
                        TotalTripCosts = g.Sum(t => t.TripCosts)

                    });

              
                foreach (var vehicle in vehicleEmissions)
                {
                    TripSummary tripSummary = new()
                    {
                        Vehicle = vehicle.Vehicle,
                        TotalCarbonEmissions = vehicle.TotalEmissions
                    };
                    Summaries.Add(tripSummary);
                }
         


            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }


    }
}
