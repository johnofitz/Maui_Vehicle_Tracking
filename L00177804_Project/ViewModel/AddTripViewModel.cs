
using L00177804_Project.Service.LocationService;
using L00177804_Project.Service.VehicleCalculationService;
using System.Reflection;

namespace L00177804_Project.ViewModel
{
    public partial class AddTripViewModel : ParentViewModel
    {   

        private readonly RouteDistanceService _routeDistanceService = new();

        private readonly VehicleCalculations _vehicleCalculations = new();


        // Target File to save json data
        private readonly string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "trips.json");

        private List<Trip> logging = new();

        public AddTripViewModel() { }


        [ObservableProperty] public string tripName;

        [ObservableProperty] public string tripDate;

        [ObservableProperty] public string odemeterStart;

        [ObservableProperty] public string odemeterEnd;

        [ObservableProperty] public string tripDistance;

        [ObservableProperty] public string tripCost;

        [ObservableProperty] public string tripNotes;

        [ObservableProperty] public string tripConsumption;

        [ObservableProperty] public string origin;

        [ObservableProperty] public string destination;


        // Odometer convert to double
        public double odeStartconvert = 0.0;

        public double odeEndconvert = 0.0;

        public double tripDistanceconvert = 0.0;

        public double tripCostconvert = 0.0;

        public double tripConsumptionconvert = 0.0;

        /// <summary>
        ///  AddTrip method
        /// </summary>
        /// <returns></returns>

        [RelayCommand]
        public async Task AddTrip()
        {
            try
            {
                if (await CanSaveTripDataAsync() && await IsDoubleAsync(odemeterStart) && await IsDoubleAsync(odemeterEnd))
                {

                    odeStartconvert = double.Parse(odemeterStart);

                    odeEndconvert = double.Parse(odemeterEnd);

                    var getRouteDistance = await _routeDistanceService.GetRouteDistanceAsync(CapitalizeAddress(origin), CapitalizeAddress(destination));

                    var retDiststring = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Distance.Text).FirstOrDefault();

                    var retDurstring = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Duration.Text).FirstOrDefault();

                    var retDistint = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Distance.Value).FirstOrDefault();

                    var retDurint = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Duration.Value).FirstOrDefault();

                    string start = getRouteDistance.OriginAddresses.FirstOrDefault();

                    string finsh = getRouteDistance.DestinationAddresses.FirstOrDefault();

                    var fuelConsumed = _vehicleCalculations.CalculateFuelConsumption(retDistint / 1000, 4.5);

                    double fuels = fuelConsumed.Result;

                    var carbonEmissions = _vehicleCalculations.CalculateCO2Emissions(fuelConsumed.Result, "diesel");

                    double carbons = carbonEmissions.Result;

                    var summary = AddToModel(retDiststring,retDurstring,retDistint,retDurint,carbons,fuels,start,finsh);

                    SaveTrip(summary);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }


        private void SaveTrip(Trip trip)
        {
            // Check if the file exists
            if (!File.Exists(targetFile))
            {
                logging.Add(trip);
                string json = JsonConvert.SerializeObject(logging);
                File.WriteAllText(targetFile, json);
            }
            // If the file exists
            else
            {
                string json = File.ReadAllText(targetFile);
                logging = JsonConvert.DeserializeObject<List<Trip>>(json);


                logging.Add(trip);
                string newJson = JsonConvert.SerializeObject(logging);
                File.WriteAllText(targetFile, newJson);
            }

        }

        private Trip AddToModel(string dist, string duration, int distMeters, int durationSeconds, double carbons, double fuels, string start, string finish)
        {
            Trip trip = new()
            {
                tripNames = tripName,
                tripDates = tripDate,
                odometerStarts = odeStartconvert,
                odometerEnds = odeEndconvert,
                tripDistances = dist,
                tripDurations = duration,
                DistInt = distMeters,
                DurInt = durationSeconds,
                tripCosts = tripCostconvert,
                tripNote = tripNotes,
                carbonEmissions = carbons,
                fuelConsumed = fuels,
                tripConsumptions = tripConsumptionconvert,
                origins = start,
                destinations = finish,
            };
            return trip;
        }

        /// <summary>
        ///  Method to check if the vehicle data can be saved for string information
        /// </summary>
        /// <returns> boolean true or false</returns>
        private async Task<bool> CanSaveTripDataAsync()
        {
            if (string.IsNullOrEmpty(tripName) || string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination) || tripName.Length > 20 || destination.Length > 30 || origin.Length > 30)
            {
                await Shell.Current.DisplayAlert("Error!", "Required fields are blank or invalid", "OK");
                return false;
            }
            return true;
        }

        /// <summary>
        ///  Method to check if the vehicle data can be saved for double information
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Boolean true/false</returns>

        public static async Task<bool> IsDoubleAsync(string value)

        {
            if (double.TryParse(value, out _) == false)
            {
                await Shell.Current.DisplayAlert("Error!", "Not a vald Odometer Reading", "OK");
            }
            return double.TryParse(value, out _);
        }

        public static string CapitalizeAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return address;
            }
            // Split the address into individual words
            string[] words = address.Split(' ');

            // Capitalize the first letter of each word
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            // Join the words back together to form the capitalized address
            return string.Join(" ", words);
        }
    }
}