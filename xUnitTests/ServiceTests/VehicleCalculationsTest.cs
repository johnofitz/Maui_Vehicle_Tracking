

namespace xUnitTests.ServiceTests
{


    public class VehicleCalculationsTests
    {
        private readonly VehicleCalculations _vehicleCalculations;

        public VehicleCalculationsTests()
        {
            _vehicleCalculations = new VehicleCalculations();
        }

        [Fact]
        public async Task CalculateFuelConsumption_ReturnsCorrectValue()
        {
            // Arrange
            int distance = 100;
            double fuel = 10.0;

            // Act
            double fuelConsumption = await VehicleCalculations.CalculateFuelConsumption(distance, fuel);

            // Assert
            Assert.Equal(10.0, fuelConsumption);
        }

        [Fact]
        public async Task CalculateCO2Emissions_ReturnsCorrectValue_GivenGasolineFuelType()
        {
            // Arrange
            double fuelConsumption = 10.0;
          
            string fuelType = "gasoline";

            // Act
            double co2Emissions = await _vehicleCalculations.CalculateCO2Emissions(fuelConsumption, fuelType);

            // Assert
            Assert.Equal(84.6, co2Emissions, 1);
        }

        [Fact]
        public async Task CalculateCO2Emissions_ReturnsCorrectValue_GivenDieselFuelType()
        {
            // Arrange
            double fuelConsumption = 10.0;
            string fuelType = "diesel";

            // Act
            double co2Emissions = await _vehicleCalculations.CalculateCO2Emissions(fuelConsumption, fuelType);

            // Assert
            Assert.Equal(98.2, co2Emissions, 1);
        }
    }

}
