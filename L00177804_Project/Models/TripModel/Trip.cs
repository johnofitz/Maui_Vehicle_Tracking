

namespace L00177804_Project.Models
{
    public partial class Trip
    {
        public int Id { get; set; }
        public string Vehicle { get; set; }
        public string TripNames { get; set; }
        public string TripDates { get; set; }
        public string TripTimes { get; set; }
        public string TripDistances { get; set; }
        public string TripDurations { get; set; }
        public double TripCosts { get; set; }
        public double CarbonEmissions { get; set; }
        public int DistInt { get; set; }
        public int DurInt { get; set; }
        public double FuelConsumed { get; set; }
        public string TripNote { get; set; }
        public string Origins { get; set; }
        public string Destinations { get; set; }
  
        public DateOnly DateOnly { get; set; }
        public TimeOnly DimeOnly { get; set; }


      

    }
}
