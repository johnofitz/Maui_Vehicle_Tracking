using CommunityToolkit.Maui.Views;
using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.LocationService;
using Mopups.Services;

namespace L00177804_Project.ViewModel
{
    public partial class PopUpViewModel: ParentViewModel
    {

        // Create object from Class LocationTrackService
        private readonly LocationTrackService _locationTrackService = new();


        // User Location
        [ObservableProperty]
        public bool run = true;


        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        public PopUpViewModel() { }


        /// <summary>
        ///  Relay Command that accesses LocationTrackService to start tracking user location
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task StartTracking()
        {
            // Create a new cancellation token source and token.
            tokenSource = new();
            token = tokenSource.Token;

            // Request the LocationAlways permission from the user.
            // If the permission is not granted, return from the method.
            if (await Permissions.RequestAsync<Permissions.LocationAlways>() != PermissionStatus.Granted)
            {
                return;
            }
            // Start a new background task that updates the device's location.
            // The task takes a delegate (method) to run and the cancellation token.
            await Task.Run(() => _locationTrackService.UpdateLocation(Run, token), token);

            await MopupService.Instance.PopAsync(Run);
        }


        /// <summary>
        /// Relay Command that accesses GoogleServce to redirect to route application
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task GetDirection()
        {
            // Create a new cancellation token source and token.
            tokenSource = new();
            token = tokenSource.Token;
            try
            {
                bool answer = await Shell.Current.DisplayAlert("Track Journey", "Would you like to track this trip", "Yes", "No");
                // Clear the navigation stack.
                await MopupService.Instance.PopAsync(Run);
                // Get the current location using the LocationTrackService.
                var current = await LocationTrackService.CurrentLocation(token);

                if (answer)
                {
                    await StartTracking();
                }
                // If the current location is not null, get directions from Google Maps
                // by passing the current latitude and longitude to the GetGoogleMaps method.
                if (current != null)
                {
                    await GoogleMapService.GetGoogleMaps(current.Latitude.ToString(), current.Longitude.ToString());
                }

                // Get directions from Google Maps using a fallback location (52.663857, -8.639021)
                // in case the current location could not be retrieved or is null.
                await GoogleMapService.GetGoogleMaps("52.663857", "-8.639021");
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }

        [RelayCommand]
        public async Task AddManualTrip()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AddTripView));
                await MopupService.Instance.PopAsync(Run);
            }
            catch (Exception ex)
            {
                // If an exception is thrown, print the error message to the debug console.
                Debug.WriteLine(ex);
            }
        }

    }
}
