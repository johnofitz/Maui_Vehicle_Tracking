using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Service.TripService
{
    public class TripServiceLog
    {

        public TripServiceLog() { }

        private List<Trip> _trip;


        // Method to read json file stored in AppData
        public async Task<List<Trip>> GetVehiclesInfo(string file)
        {
            // Condition to check if menu is already loaded and not null
            if (_trip?.Count > 0)
                return _trip;

            string stream = Path.Combine(FileSystem.Current.AppDataDirectory, file);
            File.Exists(stream);
            using var reader = new StreamReader(stream);
            var items = await reader.ReadToEndAsync();
            _trip = JsonConvert.DeserializeObject<List<Trip>>(items);

            return _trip;
        }
    }
}
