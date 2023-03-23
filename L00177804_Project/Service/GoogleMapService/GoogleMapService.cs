﻿namespace L00177804_Project.Service.GoogleMapService
{
    /// <summary>
    ///  This class is used to open the Google Maps app on the device
    /// </summary>
    public class GoogleMapService
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        public GoogleMapService() { }

        /// <summary>
        ///  This method is used to open the Google Maps app on the device
        ///  at the users current location
        /// </summary>
        /// <returns></returns>
        public async Task GetGoogleMaps(double lat, double lng)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?saddr=52.6676407,-8.724467");
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync("http://maps.google.com/?saddr=52.6676407,-8.724467");
            }
        }
    }
}