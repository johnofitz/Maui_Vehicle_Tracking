using L00177804_Project.Service.TripService;
using NSubstitute;


namespace xUnitTests.ViewModelTests
{
    public class TripStatsViewModelTest
    {
        [Fact]
        public void LoadTripLogs_AddsTripsToTripCollection()
        {
            // Arrange
            var viewModel = new TripLogViewModel();

            // Act
            viewModel.LoadTripLogs();

            // Assert
            Assert.Empty(viewModel.TripCollection);
      
        }
    }
}
