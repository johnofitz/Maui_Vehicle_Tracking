using L00177804_Project.Service.VehicleInfoService;
using L00177804_Project.ViewModel;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.ViewModelTests
{
    public class MainViewModelTest
    {
        [Fact]
        public async Task AddToMainAsync()
        {

            var dataService = Substitute.For<VehicleDataService>();

            // Arrange
            MainPageViewModel viewModel = new(dataService);
            // Act
            var car = viewModel.AddVehiclesToMainAsync();
            //
            Assert.NotNull(car);
        }
    }
}
