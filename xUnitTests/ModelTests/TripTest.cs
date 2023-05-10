

namespace xUnitTests.ModelTests
{
    public class TripTest
    {

        [Fact]
        public void Trip_ShouldNotifyPropertyChanged()
        {
            // Arrange
            var trip = new Trip();
            var expectedPropertyName = "vehicle";
            var wasPropertyChangedCalled = false;

            trip.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == expectedPropertyName)
                {
                    wasPropertyChangedCalled = true;
                }
            };

            // Act
            trip.vehicle = "Test Vehicle";

            // Assert
            Assert.False(wasPropertyChangedCalled, "PropertyChanged event not raised for 'vehicle' property.");
        }
    }
}
