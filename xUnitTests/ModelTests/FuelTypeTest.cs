

using L00177804_Project.Models.UnitModel;

namespace xUnitTests.ModelTests
{

    public class FuelTypesTest
    {
        [Fact]
        public void FuelTypes_ShouldHaveCorrectDefaultValues()
        {
            // Arrange
            var fuelTypes = new FuelTypes();

            // Act
            // No action needed, since the default constructor sets the values

            // Assert
            Assert.Equal("Petrol", fuelTypes.Type1);
            Assert.Equal("Diesel", fuelTypes.Type2);
        }
    }

}
