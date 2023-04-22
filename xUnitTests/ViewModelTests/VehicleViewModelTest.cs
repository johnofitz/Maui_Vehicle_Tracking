using Microsoft.Maui.Controls;
using NSubstitute;


namespace xUnitTests.ViewModelTests
{
    public class VehicleViewModelTest
    {

        [Fact]
        public void Constructor_ShouldCallGetVehiclesAsync()
        {
            // Arrange
            var mockVehicleData = Substitute.For<VehicleDataService>();

            // Act
            var viewModel = new VehicleViewModel(mockVehicleData);

            // Assert
            mockVehicleData.Received(1);
        }

   
    }
}

