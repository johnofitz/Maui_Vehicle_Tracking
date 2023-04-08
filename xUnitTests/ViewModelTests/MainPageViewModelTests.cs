using L00177804_Project.Service.GoogleMapService;
using L00177804_Project.Service.LocationService;
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
        public void GetNearByItemsTest()
        {
            // Arrange
            var mainViewModel = new MainPageViewModel();
            // Act
            var result = mainViewModel.GetNearByItemsAsync();
            // Assert
            Assert.NotNull(result);
        }
                                                                   
   }
}
