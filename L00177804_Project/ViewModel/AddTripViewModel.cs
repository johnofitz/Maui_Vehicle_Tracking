
using L00177804_Project.Service.LocationService;
using L00177804_Project.Service.VehicleCalculationService;
using L00177804_Project.Service.VehicleInfoService;

namespace L00177804_Project.ViewModel
{
    public partial class AddTripViewModel : ParentViewModel
    {
        private const string _vehicleFile = "vehicle.json";

        private readonly RouteDistanceService _routeDistanceService = new();

        private readonly VehicleCalculations _vehicleCalculations = new();

        private readonly VehicleDataService _vehicleDataService = new();
        // Target File to save json data
        private readonly string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "trips.json");

        private List<Trip> logging = new();

        public AddTripViewModel() { }


        [ObservableProperty] public string tripName;

        [ObservableProperty] public string tripDate;

        [ObservableProperty] public string tripDistance;

        [ObservableProperty] public string tripCost;

        [ObservableProperty] public string tripNotes;

        [ObservableProperty] public string tripConsumption;

        [ObservableProperty] public string origin;

        [ObservableProperty] public string destination;

        [ObservableProperty] public DateTime currentDate;

        [ObservableProperty] public DateTime currentTime = DateTime.Now;

        [ObservableProperty] public DateTime mindate = DateTime.Now;

        [ObservableProperty] public string fuelPricePerLitre;


        [ObservableProperty] private Vehicle vehicle;

        private double fuelPricePerLitreconvert = 0.0;

        private double fuelCost = 0.0;

        private string start;

        private string finish;

        private int retDistint;

        /// <summary>
        ///  AddTrip method
        /// </summary>
        /// <returns></returns>

        [RelayCommand]
        public async Task AddTrip()
        {
            try
            {
                if (await CanSaveTripDataAsync())
                {
                    await GetPrefferedVehicle();

                    var getRouteDistance = await _routeDistanceService.GetRouteDistanceAsync(CapitalizeAddress(origin), CapitalizeAddress(destination));

                    var retDiststring = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Distance.Text).FirstOrDefault();

                    var retDurstring = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Duration.Text).FirstOrDefault();

                    retDistint = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Distance.Value).FirstOrDefault();

                    var retDurint = getRouteDistance.Rows.SelectMany(row => row.Elements).Select(element => element.Duration.Value).FirstOrDefault();

                    start = getRouteDistance.OriginAddresses.FirstOrDefault();

                    finish = getRouteDistance.DestinationAddresses.FirstOrDefault();

                    var fuelConsumed = _vehicleCalculations.CalculateFuelConsumption(retDistint / 1000, vehicle.AverageFuelConsumption);

                    double fuels = fuelConsumed.Result;

                    var carbonEmissions = _vehicleCalculations.CalculateCO2Emissions(fuelConsumed.Result, vehicle.FuelType);

                    double carbons = carbonEmissions.Result;

                    var summary = AddToModel(retDiststring,retDurstring,retDistint,retDurint,carbons,fuels, start, finish);

                    SaveTrip(summary);
 
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                await Shell.Current.DisplayAlert("Sucess", "A Trip has been Added", "OK");

                TripName = string.Empty;
                TripNotes = string.Empty;
                TripConsumption = string.Empty;
                Origin = string.Empty;
                Destination = string.Empty;
                FuelPricePerLitre = string.Empty;


  
            }
        }


        private void SaveTrip(Trip trip)
        {
            // Check if the file exists
            if (!File.Exists(targetFile))
            {
                trip.Id = 1;
                logging.Add(trip);
                string json = JsonConvert.SerializeObject(logging);
                File.WriteAllText(targetFile, json);
            }
            // If the file exists
            else
            {
                string json = File.ReadAllText(targetFile);
                logging = JsonConvert.DeserializeObject<List<Trip>>(json);

                // Set the ID for subsequent entries
                trip.Id = logging.Max(v => v.Id) + 1;
                logging.Add(trip);
                string newJson = JsonConvert.SerializeObject(logging);
                File.WriteAllText(targetFile, newJson);
            }

        }
        /// <summary>
        /// Method used to add all trip parameters to the trip model
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="duration"></param>
        /// <param name="distMeters"></param>
        /// <param name="durationSeconds"></param>
        /// <param name="carbons"></param>
        /// <param name="fuels"></param>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        private Trip AddToModel(string dist, string duration, int distMeters, int durationSeconds, double carbons, double fuels, string start, string finish)
        {
            string time = currentTime.ToString("hh:mm:ss tt");
            string dates = currentDate.Date.ToString("MM/dd/yyyy");
            double cost = CalculateFuelCost();

            Trip trip = new()
            {
               
                Vehicle = vehicle.Name,
                TripNames = tripName,
                Origins = start,
                Destinations = finish,
                TripDates = dates,
                TripTimes = time,
                TripDistances = dist,
                TripDurations = duration,
                DistInt = distMeters,
                DurInt = durationSeconds,
                TripCosts = cost,
                TripNote = tripNotes,
                CarbonEmissions = carbons,
                FuelConsumed = fuels,
                DateTime = CurrentDate
            
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


        private Double CalculateFuelCost()
        {
            double distanceInKm = retDistint / 1000; // convert distance from meters to kilometers
            double litersPer100Km = vehicle.averageFuelConsumption; // assume fuel consumption is in liters per 100 km
            fuelPricePerLitreconvert = double.Parse(fuelPricePerLitre); // assume fuel cost is in dollars per liter
            if(fuelPricePerLitreconvert > 0)
            {
                fuelCost = (distanceInKm / 100) * litersPer100Km * fuelPricePerLitreconvert;
            }
            else
            {
                fuelCost = (distanceInKm / 100) * litersPer100Km * 1.67;
            }
            return fuelCost;
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
                    words[i] = char.ToUpper(words[i][0]) + words[i][1..].ToLower();
                }
            }

            // Join the words back together to form the capitalized address
            return string.Join(" ", words);
        }

        private async Task GetPrefferedVehicle()
        {
            try
            {
                // Get the vehicle information from a file using the VehicleDataService.
                var item = await _vehicleDataService.GetVehiclesInfo(_vehicleFile);


                // Get the name of the default vehicle from the user's preferences.
                string check = item.Select(x => x.Name).FirstOrDefault();
                var cars = Preferences.Get("cars", check);

                // Set the SelectVehicle property to the default vehicle.
                vehicle = item.Single(x => x.Name == cars);
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }

    }
}