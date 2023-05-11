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

 
        /// <summary>
        ///  Constructor for the SettingsViewModel class
        /// </summary>
        public SettingsViewModel( )
        {
           
            AddThemes();      
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
