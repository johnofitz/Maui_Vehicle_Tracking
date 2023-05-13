

namespace xUnitTests.ModelTests
{
    public class TripTest
    {

        [Fact]
        public void Trip_WhenInstantiated_PropertiesShouldBeNullOrZero()
        {
            // Arrange
            var trip = new Trip();

            // Assert
            Assert.Null(trip.Vehicle);
            Assert.Null(trip.TripNames);
            Assert.Null(trip.TripDates);
            Assert.Null(trip.TripTimes);
            Assert.Null(trip.TripDistances);
            Assert.Null(trip.TripDurations);
            Assert.Equal(0.0, trip.TripCosts);
            Assert.Equal(0.0, trip.CarbonEmissions);
            Assert.Equal(0, trip.DistInt);
            Assert.Equal(0, trip.DurInt);
            Assert.Equal(0.0, trip.FuelConsumed);
            Assert.Null(trip.TripNote);
            Assert.Null(trip.Origins);
            Assert.Null(trip.Destinations);
            Assert.Equal(DateTime.MinValue, trip.DateTime);
        }
    }
}
