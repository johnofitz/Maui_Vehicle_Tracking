
namespace L00177804_Project.Service.LocationService
{
    public class LocationTrackService
    {
        public LocationTrackService() { }

        private Locations _currentlocations = new();

        private double oldLat = 0;
        private double oldLng = 0;


        public async Task UpdateLocation(CancellationToken ct)
        {
            while (true)
            {
                // Request the device's location with the best accuracy and a 5-second timeout
                GeolocationRequest request = new(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
                CancellationTokenSource cancelTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct);
                Location location = null;

                try
                {
                    // Use the cancellation token to abort the location request if needed
                    location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token);

                    _currentlocations.Lat = location.Latitude;
                    _currentlocations.Lng = location.Longitude;
                    _currentlocations.Speed = (double)location.Speed;

                }
                catch (TaskCanceledException)
                {
                    // Debug cancelation exception
                    Debug.WriteLine("Location request canceled");

                }

                finally
                {

                    if (_currentlocations != null && oldLat != 0 && oldLng != 0)
                    {
                        Location oldDist = new(oldLat, oldLng);
                        Location newDist = new(_currentlocations.Lat, _currentlocations.Lng);
                        double km = Location.CalculateDistance(oldDist, newDist, DistanceUnits.Kilometers);
                        _currentlocations.Distance += km;
                    }

                    oldLat = _currentlocations.Lat;
                    oldLng = _currentlocations.Lng;
                }

                // Wait for the location to be retrieved
                while (location == null)
                {
                    Thread.Sleep(1000);

                    if (ct.IsCancellationRequested)
                    {
                        // If cancellation is requested, break out of the loop
                        return;
                    }
                }
                // Wait for 3 seconds before requesting the next location
                await Task.Delay(3000, ct);

            }
        }
    }
}
