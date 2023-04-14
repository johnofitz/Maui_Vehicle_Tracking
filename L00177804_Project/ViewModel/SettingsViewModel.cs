using CommunityToolkit.Mvvm.Messaging;
using L00177804_Project.Service.ThemeService;
using L00177804_Project.Service.VehicleInfoService;

namespace L00177804_Project.ViewModel
{

    public partial class SettingsViewModel : ParentViewModel
    {
        private const string _vehicleFile = "vehicle.json";
        // Create observable collection for vehicle
        public ObservableCollection<Vehicle> VehiclesCollection { get; set; } = new();
        // Create an instance of the VehicleDataService class
        private readonly VehicleDataService VehicleDataService;


        public SettingsViewModel( VehicleDataService dataService)
        {
            VehicleDataService = dataService;
            AddThemes();
            AddVehiclesToMainAsync();
        }

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

            var hasCustom = Preferences.ContainsKey("CustomTheme");

            if (hasCustom)
            {
                Themes.Add(new Theme("Custom theme", "Custom"));
            }

            var theme = Preferences.Get("theme", "System");

            SelectedTheme = Themes.Single(x => x.Key == theme);

            WeakReferenceMessenger.Default.Register<ThemeAddMessage>(this, (r, m) =>
            {
                SelectedTheme = null;

                if (m.Value == "Custom")
                {
                    var customTheme = Themes.SingleOrDefault(x => x.Key == "Custom");

                    if (customTheme == null)
                    {
                        customTheme = new Theme("Custom theme", "Custom");

                        Themes.Add(customTheme);
                    }

                    SelectedTheme = customTheme;
                }
            });
        }

        [ObservableProperty]
        private List<Theme> themes;

        [ObservableProperty]
        private Theme selectedTheme;

        partial void OnSelectedThemeChanged(Theme value)
        {
            if (value == null)
            {
                return;
            }

            Preferences.Set("theme", value.Key);

            WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(value.Key));
        }


        public async void AddVehiclesToMainAsync()
        {
            try
            {
                // Get the vehicle data from the json file
                var item = await VehicleDataService.GetVehiclesInfo(_vehicleFile);

                // condition to clear menu for erroneous behaviour
                if (VehiclesCollection.Count != 0)
                {
                    VehiclesCollection.Clear();
                }
                // Add the vehicle data to the observable collection
                item.ForEach(VehiclesCollection.Add);

                SelectVehicle = VehiclesCollection.FirstOrDefault();
                // condition to check if the observable collection is empty
                
            }
            // Catch errors
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private Vehicle _selectVehicle;
        public Vehicle SelectVehicle
        {
            get { return _selectVehicle; }
            set
            {
                _selectVehicle = value;
                OnPropertyChanged(nameof(SelectVehicle));
            }
        }


    }
}
