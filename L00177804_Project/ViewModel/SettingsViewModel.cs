using CommunityToolkit.Mvvm.Messaging;
using L00177804_Project.Service.ThemeService;
using L00177804_Project.Service.VehicleInfoService;
using L00177804_Project.Service.VehicleStoreService;

namespace L00177804_Project.ViewModel
{

    public partial class SettingsViewModel : ParentViewModel
    {
      

        [ObservableProperty]
        private List<Theme> themes;

        [ObservableProperty]
        private Theme selectedTheme;

        //[ObservableProperty]
        //private Vehicle preferedVehicle;

        // File name for vehicle.json
        //private const string _vehicleFile = "vehicle.json";

        // Create observable collection for vehicle
        //public ObservableCollection<Vehicle> VehiclesCollection { get; set; } = new();

        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService;

        /// <summary>
        ///  Constructor for the SettingsViewModel class
        /// </summary>
        /// <param name="dataService"></param>
        public SettingsViewModel( VehicleDataService dataService)
        {
            VehicleDataService = dataService;
            AddThemes();
            //AddVehiclesToMainAsync();
           
        }

        /// <summary>
        ///  Method to add the themes to the observable collection
        /// </summary>
        public void AddThemes()
        {
            var defaultThemes = new List<Theme>()
            {
                new Theme("System", "System"),
                new Theme("Dark", "Dark"),
                new Theme("Light", "Light"),
                new Theme("Blue","Blue"),
                new Theme("Red", "Red")
            };
            Themes = new List<Theme>(defaultThemes);

            var theme = Preferences.Get("theme", "System");

            SelectedTheme = Themes.Single(x => x.Key == theme);
        }


        /// <summary>
        ///  Method to set the Theme 
        /// </summary>
        /// <param name="value"></param>
        partial void OnSelectedThemeChanged(Theme value)
        {
            if (value == null)
            {
                return;
            }

            Preferences.Set("theme", value.Key);

            WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(value.Key));
        }
    }
}
