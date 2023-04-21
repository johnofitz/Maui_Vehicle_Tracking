using Microsoft.Maui;

namespace L00177804_Project.Service.LocationService
{
    public class LocationTrackService
    {
        public LocationTrackService() { }

        // Create object from Locations class
        private readonly Locations _currentlocations = new();

        // Store previous lat and long for distance matric
        private double _oldLat = 0;
        private double _oldLng = 0;

        /// <summary>
        /// Continuously updates the current location of the device and calculates distance travelled.
        /// </summary>
        /// <param name="running">A boolean flag indicating whether the location update loop should continue running.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The current location and distance travelled, or the last known location if the operation was cancelled.</returns>
        public async Task<Locations> UpdateLocation(bool running, CancellationToken ct)
        {
            while (running)
            {
                // Check if cancellation has been requested, and return the last known location if so.
                if (ct.IsCancellationRequested)
                {
                    return _currentlocations;
                }

                // Create a new geolocation request with the best accuracy and a 5-second timeout.
                GeolocationRequest request = new(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));

                // Create a new cancellation token source that is linked to the provided cancellation token.
                CancellationTokenSource cancelTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct);

                // Initialize the location variable to null.
                Location location = null;

                try
                {
                    // Get the current location asynchronously using the geolocation request and cancellation token.
                    location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token);

                    if (location != null)
                    {
                        // Update the current location with the new latitude, longitude, and speed values.
                        _currentlocations.Lat = location.Latitude;
                        _currentlocations.Lng = location.Longitude;
                        _currentlocations.Speed = (double)location.Speed;
                    }

                    if (_currentlocations != null && _oldLat != 0 && _oldLng != 0)
                    {
                        // Calculate the distance travelled since the last update and add it to the total distance.
                        Location oldDist = new(_oldLat, _oldLng);
                        Location newDist = new(_currentlocations.Lat, _currentlocations.Lng);
                        double km = Location.CalculateDistance(oldDist, newDist, DistanceUnits.Kilometers);
                        _currentlocations.Distance += km;
                    }

                    // Update the old latitude and longitude values to the new values for the next iteration.
                    _oldLat = _currentlocations.Lat;
                    _oldLng = _currentlocations.Lng;

                }
                catch (Exception ex)
                {
                    // If an exception is thrown, log the error message to the debug console.
                    Debug.WriteLine(ex);
                }
                finally
                {
                    // Wait for 2 seconds if the location was not obtained to prevent overwhelming the geolocation service.
                    while (location == null)
                    {
                        Thread.Sleep(2000);
                    }

                    // Wait for 10 seconds before starting the next iteration of the loop.
                    await Task.Delay(10000, ct);

                }
            }

            // Return the current location and distance travelled (or the last known location if the loop was cancelled).
            return _currentlocations;
        }



        /// <summary>
        /// Returns the current location of the device using geolocation services.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The current location of the device, or null if the location could not be determined.</returns>
        public static async Task<Location> CurrentLocation(CancellationToken ct)
        {
            // Create a new geolocation request with the best accuracy and a 5-second timeout.
            GeolocationRequest request = new(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));

            // Create a new cancellation token source that is linked to the provided cancellation token.
            CancellationTokenSource cancelTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct);

            // Initialize the location variable to null.
            Location location = null;

            try
            {
                // Get the current location asynchronously using the geolocation request and cancellation token.
                location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token);
            }
            catch (Exception ex)
            {
                // If an exception is thrown, log the error message to the debug console.
                Debug.WriteLine(ex.Message);
            }

            // Return the location (which may be null if an error occurred).
            return location;
        }



    }
}
