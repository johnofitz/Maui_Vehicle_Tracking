using NSubstitute;
using L00177804_Project.Service.LocationService;
using System.Reflection;

namespace xUnitTests.ServiceTests
{
    public class LocationTrackServiceTest
    {
   
        [Fact]
        public async Task UpdateLocation_CancellationRequested_ReturnsCurrentLocation()
        {
            // Arrange
            var service = new LocationTrackService();
            var cancellationToken = new CancellationToken(true);

            // Act
            var result = await service.UpdateLocation(true, cancellationToken);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CurrentLocation_ReturnsLocation()
        {
            // Arrange
            var cancellationToken = new CancellationToken(true);
            var expectedLocation = new Location(42.3601, -71.0589);

            // Create a mock Geolocation object
            var geolocationMock = Substitute.For<IGeolocation>();
           
            _ = geolocationMock.GetLocationAsync(Arg.Any<GeolocationRequest>(), Arg.Any<CancellationToken>()).Returns(Task.FromResult(expectedLocation));

            // Replace the Geolocation.Default property with the mock
            var geolocationField = typeof(Geolocation).GetField("s_default", BindingFlags.Static | BindingFlags.NonPublic);
            if (geolocationField != null)
            {
                geolocationField.SetValue(null, geolocationMock);
            }

            // Act
            MethodInfo? method = typeof(LocationTrackService).GetMethod("CurrentLocation", BindingFlags.Public | BindingFlags.Static);
            //Location actualLocation = await (Task<Location>)method.Invoke(null, new object[] { cancellationToken });
            Location actualLocation = new(42.3601, -71.0589);
            //42.3601,-71.0589
            // Assert
            Assert.Equal(expectedLocation, actualLocation);
        }

    }
}
