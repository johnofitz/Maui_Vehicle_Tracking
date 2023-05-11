
using L00177804_Project.Service.LocationService;


namespace L00177804_Project.Service.NearByService
{
    public class NearByRestService
    {
        // Constructor 
        public NearByRestService(){}

        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        // Inatialize http client
        private readonly HttpClient _client = new();

        // List to hold nearby objects
        private List<NearBy> items = new();

        // Always response on data
        private readonly string resp = "results";

        private readonly string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=";

        private readonly string radius = "1500";

        private readonly string types = "gas_station";

        private readonly string keyword = "fuel";

        private const string apiKey = "GoogleMap";

        /// <summary>
        /// Method used to Deserialize Json object
        /// using Newtonsoft.Json library and http client
        /// Parses Json object to a list of Nearby objects
        /// </summary>
        /// <returns> A List of Nearby fuel stations</returns>
        public async Task<List<NearBy>> GetNearByAsync(string lat, string lng)
        {

            string apitok = await SecureStorage.GetAsync(apiKey);

            // Create a new cancellation token source and token.
            tokenSource = new();
            token = tokenSource.Token;
          

            var current = await LocationTrackService.CurrentLocation(token);
            var currentloc = new Location(current.Latitude, current.Longitude);

            string fullUrl = url + lat + "%2C" + lng + "&radius=" + radius + "&types=" + types + "&keyword=" + keyword + "&key=" + apitok;
            // Url to get nearby fuel stations
      
            // pass url and return response as a stream
            var response = await _client.GetStreamAsync(fullUrl);

            // Inatialize Stream reader to read byte data
            using StreamReader reader = new(response);

            // return stream as a string to end
            string value = await reader.ReadToEndAsync();

            // pass string as a json object
            JObject json = JObject.Parse(value);

            // Check if contains Response key
            if (json.ContainsKey(resp))
            {
                // convert json object to string 
                var responseData = json[resp]?.ToString();
                if (responseData != null)
                {
                    // Deserialize and pass objects to list
                    items = JsonConvert.DeserializeObject<List<NearBy>>(responseData);
                }
                foreach (var item in items)
                {
                    var nearloc = new Location(item.Geometry.Location.Latitiude, item.Geometry.Location.Longitude);
                    // Calculate distance between current location and nearby object
                    if (item != null) {
                        item.Distance = Location.CalculateDistance(currentloc, nearloc, DistanceUnits.Kilometers);
                    }
                }
            }
            // return list
            return items;
        }
    }
}
