using L00177804_Project.Models.UnitModel;

namespace xUnitTests.ModelTests
{
    public class ConsumptionUnitTest
    {
        [Fact]
        public void Consumption1_ShouldBeKm100()
        {
            // Arrange
            var consump = new ConsumptionUnit();

            // Act
            var type1 = consump.Consumption1;

            // Assert
            Assert.Equal("L/100km", type1);
        }

        [Fact]
        public void Consumption2_ShouldBeMpg()
        {
            // Arrange
            var consump = new ConsumptionUnit();

            // Act
            var type2 = consump.Consumption2;

            // Assert
            Assert.Equal("km/L", type2);
        }

        [Fact]
        public void Consumption3_ShouldBeMpg()
        {
            // Arrange
            var consump = new ConsumptionUnit();

            // Act
            var type3 = consump.Consumption3;

            // Assert
            Assert.Equal("mpg", type3);
        }

    

    }
}
