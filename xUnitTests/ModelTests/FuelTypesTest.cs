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


    }

}
