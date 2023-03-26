
namespace L00177804_Project.Service.VehicleInfoService
{
    public class VehicleDataService
    {

        public VehicleDataService() { }


        private List<Vehicle> _vehicles;


        // Method to read json file stored in AppData
        public async Task<List<Vehicle>> GetVehiclesInfo()
        {
            // Condition to check if menu is already loaded and not null
            if (_vehicles?.Count > 0)
                return _vehicles;

            string stream = Path.Combine(FileSystem.Current.AppDataDirectory, "vehicle.json");
            using var reader = new StreamReader(stream);
            var items = await reader.ReadToEndAsync();
            _vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(items);

            return _vehicles;
        }
    }
}
