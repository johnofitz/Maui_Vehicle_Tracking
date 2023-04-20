
using L00177804_Project.Service.VehicleCalculationService;
using NSubstitute;
using System.Threading.Tasks;

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
            double distance = 100.0;
            double fuel = 10.0;

            // Act
            double fuelConsumption = await _vehicleCalculations.CalculateFuelConsumption(distance, fuel);

            // Assert
            Assert.Equal(10.0, fuelConsumption);
        }

        [Fact]
        public async Task CalculateCO2Emissions_ReturnsCorrectValue_GivenGasolineFuelType()
        {
            // Arrange
            double fuelConsumption = 10.0;
            double averageSpeed = 60.0;
            string fuelType = "gasoline";

            // Act
            double co2Emissions = await _vehicleCalculations.CalculateCO2Emissions(fuelConsumption, averageSpeed, fuelType);

            // Assert
            Assert.Equal(23.1, co2Emissions, 1);
        }

        [Fact]
        public async Task CalculateCO2Emissions_ReturnsCorrectValue_GivenDieselFuelType()
        {
            // Arrange
            double fuelConsumption = 10.0;
            double averageSpeed = 60.0;
            string fuelType = "diesel";

            // Act
            double co2Emissions = await _vehicleCalculations.CalculateCO2Emissions(fuelConsumption, averageSpeed, fuelType);

            // Assert
            Assert.Equal(26.8, co2Emissions, 1);
        }
    }

}
