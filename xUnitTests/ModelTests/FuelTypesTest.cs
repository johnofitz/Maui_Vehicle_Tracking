using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.ModelTests
{
    public class FuelTypesTests
    {
        [Fact]
        public void Type1_ShouldBePetrol()
        {
            // Arrange
            var fuelTypes = new FuelTypes();

            // Act
            var type1 = fuelTypes.Type1;

            // Assert
            Assert.Equal("Petrol", type1);
        }

        [Fact]
        public void Type2_ShouldBeDiesel()
        {
            // Arrange
            var fuelTypes = new FuelTypes();

            // Act
            var type2 = fuelTypes.Type2;

            // Assert
            Assert.Equal("Diesel", type2);
        }

        [Fact]
        public void Type3_ShouldBeElectric()
        {
            // Arrange
            var fuelTypes = new FuelTypes();

            // Act
            var type3 = fuelTypes.Type3;

            // Assert
            Assert.Equal("Electric", type3);
        }

        [Fact]
        public void Type4_ShouldBeHybrid()
        {
            // Arrange
            var fuelTypes = new FuelTypes();

            // Act
            var type4 = fuelTypes.Type4;

            // Assert
            Assert.Equal("Hybrid", type4);
        }

        [Fact]
        public void Type5_ShouldBeLPG()
        {
            // Arrange
            var fuelTypes = new FuelTypes();

            // Act
            var type5 = fuelTypes.Type5;

            // Assert
            Assert.Equal("LPG", type5);
        }
    }

}
