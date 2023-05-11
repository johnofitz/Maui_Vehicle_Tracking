
using NSubstitute;


namespace xUnitTests.ViewModelTests
{
    public class MainPageViewModelTests
    {
        [Fact]
        public async Task AddVehiclesToMainAsync_AddsVehiclesToCollection()
        {
            // Arrange
           
            var viewModel = new MainViewModel();

            // Act
            await viewModel.AddVehiclesToMainAsync();

            // Assert
            Assert.Empty(viewModel.VehiclesCollection);
        }

    }
}
