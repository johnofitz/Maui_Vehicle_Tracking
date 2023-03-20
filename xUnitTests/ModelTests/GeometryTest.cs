
namespace xUnitTests.ModelTests
{
    public class GeometryTest
    {

        [Fact]
        public void GeometryModelTest()
        {
            // Arrange
            Geometry geometry = new();
            // Act
            geometry.location = new L00177804_Project.Models.Location
            {
                lat = 1.0,
                lng = 2.0
            };
            // Assert
            Assert.NotNull(geometry);
            Assert.NotNull(geometry.location);
            Assert.Equal(1.0, geometry.location.lat);
            Assert.Equal(2.0, geometry.location.lng);
        }
    }
}
