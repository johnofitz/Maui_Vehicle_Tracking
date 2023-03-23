
namespace xUnitTests.ModelTests
{
    public class GeometryTest
    {

        [Fact]
        public void GeometryModelTest()
        {
            // Arrange
            Geometry geometry = new()
            {
                // Act
                Location = new Locations
                {
                    Lat = 1.0,
                    Lng = 2.0
                }
            };
            // Assert
            Assert.NotNull(geometry);
            Assert.NotNull(geometry.Location);
            Assert.Equal(1.0, geometry.Location.Lat);
            Assert.Equal(2.0, geometry.Location.Lng);
        }
    }
}
