﻿
namespace L00177804_Project.Service.LocationService
{
    public class LocationTrackService
    {
        public LocationTrackService() { }

        // Create object from Locations class
        private Locations _currentlocations = new();

        // Store previous lat and long for distance matric
        private double _oldLat = 0;
        private double _oldLng = 0;

        /// <summary>
        /// Method to update location
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task UpdateLocation(CancellationToken ct, bool running)
        {
            while (running)
            {
                // Request the device's location with the best accuracy and a 5-second timeout
                GeolocationRequest request = new(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
                CancellationTokenSource cancelTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct);
                Location location = null;

                try
                {
                    // Use the cancellation token to abort the location request if needed
                    location = await Geolocation.Default.GetLocationAsync(request, cancelTokenSource.Token);
                    if (location != null)
                    {
                        // Add Location class data to local object
                        _currentlocations.Lat = location.Latitude;
                        _currentlocations.Lng = location.Longitude;
                        _currentlocations.Speed = (double)location.Speed;
                    }

                }
                catch (TaskCanceledException)
                {
                    // Debug cancelation exception
                    Debug.WriteLine("Location request canceled");

                }

                finally
                {
                    // Only excutes after second itteration
                    if (_currentlocations != null && _oldLat != 0 && _oldLng != 0)
                    {
                        // Calculate distance between two points
                        Location oldDist = new(_oldLat, _oldLng);
                        Location newDist = new(_currentlocations.Lat, _currentlocations.Lng);
                        double km = Location.CalculateDistance(oldDist, newDist, DistanceUnits.Kilometers);
                        _currentlocations.Distance += km;
                    }
                    // store previous lat and long for distance matric
                    _oldLat = _currentlocations.Lat;
                    _oldLng = _currentlocations.Lng;
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