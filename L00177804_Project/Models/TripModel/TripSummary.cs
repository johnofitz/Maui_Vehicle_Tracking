

namespace L00177804_Project.Models.TripModel
{
    public class TripSummary
    {
    
        public string Vehicle { get; set; }
        public string TotalTripDistances { get; set; }
        public double TotalTripCosts { get; set; }
        public double TotalCarbonEmissions { get; set; }
        public int TotalDistInt { get; set; }
        public double TotalFuelConsumed { get; set; }

        public double ServiceDistance { get; set; }
    }
}
