namespace L00177804_Project.Service.GoogleMapService
{
    /// <summary>
    ///  This class is used to open the Google Maps app on the device
    /// </summary>
    public class GoogleMapService
    {
        /// <summary>
        ///  Constructor
        /// </summary>
        public GoogleMapService() {}

        /// <summary>
        ///  This method is used to open the Google Maps app on the device
        ///  at the users current location
        /// </summary>
        /// <returns></returns>
        public static async Task GetGoogleMaps(string lat, string lng)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync($"http://maps.apple.com/?saddr={lat},{lng}");
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync($"http://maps.google.com/?saddr={lat},{lng}");
            }
        }


        /// <summary>
        ///  Accepts Location to Nearby fuel station for android and IOS
        /// </summary>
        /// <param name="slat"></param>
        /// <param name="slng"></param>
        /// <param name="dlat"></param>
        /// <param name="dlng"></param>
        /// <returns></returns>
        public static async Task GetGoogleMapsRoute(string slat, string slng, string dlat, string dlng)
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync($"http://maps.apple.com/?saddr={slat},{slng}&daddr={dlat},{dlng}");
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync($"http://maps.google.com/?saddr={slat},{slng},&daddr={dlat},{dlng}");
            }
        }

    }
}
