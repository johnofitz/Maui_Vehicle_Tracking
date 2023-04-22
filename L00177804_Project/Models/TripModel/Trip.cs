

namespace L00177804_Project.Models
{
    public partial class Trip: ObservableObject
    {

        [ObservableProperty] public string tripNames;
        [ObservableProperty] public string tripDates;
        [ObservableProperty] public double odometerStarts;
        [ObservableProperty] public double odometerEnds;
        [ObservableProperty] public string tripDistances;
        [ObservableProperty] public string tripDurations;
        [ObservableProperty] public double tripCosts;
        [ObservableProperty] public string tripNote;
        [ObservableProperty] public double tripConsumptions;
        [ObservableProperty] public string origins;
        [ObservableProperty] public string destinations;
        [ObservableProperty] public double carbonEmissions;
        [ObservableProperty] public int distInt;
        [ObservableProperty] public int durInt;
        [ObservableProperty] public double fuelConsumed;
        [ObservableProperty] public double carbon;
    }
}
