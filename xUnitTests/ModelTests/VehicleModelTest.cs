

namespace xUnitTests.ModelTests
{
    public class VehicleModelTest
    {
        [Fact]
        public void Vehicle_WithDefaultConstructor_ShouldInitializeProperties()
        {
            // Arrange
            var vehicle = new Vehicle();

            // Act
            // No action needed, since the default constructor doesn't set any values

            // Assert
            Assert.Equal(0, vehicle.id);
            Assert.Null(vehicle.name);
            Assert.Null(vehicle.make);
            Assert.Null(vehicle.model);
            Assert.Null(vehicle.fuelType);
            Assert.Equal(0.0, vehicle.odometer);
            Assert.Null(vehicle.engineSize);
            Assert.Null(vehicle.fuelConsumption);
            Assert.Null(vehicle.insurencePolicy);
            Assert.Null(vehicle.insurenceCompany);
            Assert.Null(vehicle.licence);
            Assert.Null(vehicle.distance);
            Assert.Null(vehicle.ToString());
        }

        [Fact]
        public void Vehicle_WithParameterizedConstructor_ShouldSetValues()
        {
            // Arrange
            string expectedName = "TestVehicle";
            var vehicle = new Vehicle(expectedName);

            // Act
            // No action needed, since the parameterized constructor sets the 'Name' property

            // Assert
            Assert.Equal(0, vehicle.id);
            Assert.Equal(expectedName, vehicle.name);
            Assert.Null(vehicle.make);
            Assert.Null(vehicle.model);
            Assert.Null(vehicle.fuelType);
            Assert.Equal(0.0, vehicle.odometer);
            Assert.Null(vehicle.engineSize);
            Assert.Null(vehicle.fuelConsumption);
            Assert.Null(vehicle.insurencePolicy);
            Assert.Null(vehicle.insurenceCompany);
            Assert.Null(vehicle.licence);
            Assert.Null(vehicle.distance);
            Assert.Equal(expectedName, vehicle.ToString());
        }

        [Fact]
        public void Vehicle_ToString_ShouldReturnName()
        {
            // Arrange
            string expectedName = "TestVehicle";
            var vehicle = new Vehicle(expectedName);

            // Act
            string result = vehicle.ToString();

            // Assert
            Assert.Equal(expectedName, result);
        }
    }

}
