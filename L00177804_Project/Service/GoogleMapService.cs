using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Service
{
    public class GoogleMapService
    {

        public GoogleMapService() { }


        public async Task GetGoogleMaps()
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS || DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?daddr=52.6676407,-8.724467");
            }
            else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync("http://maps.google.com/?daddr=52.6676407,-8.724467");
            }
        }
    }
}
