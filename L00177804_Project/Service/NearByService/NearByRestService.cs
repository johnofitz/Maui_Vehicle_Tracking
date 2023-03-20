
namespace L00177804_Project.Service.NearByService
{
    public class NearByRestService
    {
        // Constructor 
        public NearByRestService(){}

        // Inatialize http client
        private readonly HttpClient _client = new();

        // List to hold nearby objects
        private List<NearBy> items = new();

        // Always response on data
        private readonly string resp = "results";

        /// <summary>
        /// Method used to Deserialize Json object
        /// using Newtonsoft.Json library and http client
        /// Parses Json object to a list of Nearby objects
        /// </summary>
        /// <returns> A List of Nearby fuel stations</returns>
        public async Task<List<NearBy>> GetNearByAsync()
        {
            // Url to get nearby fuel stations
            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=52.663857%2C-8.639021&radius=1500&types=gas_station&keyword=fuel&key=AIzaSyCisbhXpngbhbhJSq_ykG8a6HljIFvFhjc";

            // pass url and return response as a stream
            var response = await _client.GetStreamAsync(url);

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
            }
            // return list
            return items;
        }
    }
}
