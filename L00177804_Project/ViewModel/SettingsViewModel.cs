using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.ViewModel
{
    public partial class SettingsViewModel: ParentViewModel
    {

        private static SettingsViewModel _instance;
        public static SettingsViewModel Instance => _instance ??= new SettingsViewModel();

        private SettingsViewModel()
        {
            Theme = Theme.System;
        }

        [ObservableProperty]
        private Theme _theme;
    }
}
