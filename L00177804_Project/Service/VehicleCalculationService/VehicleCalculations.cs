

namespace L00177804_Project.Service.VehicleCalculationService
{
    public class VehicleCalculations
    {
        private double co2Factor = 0.0; // Conversion factor for CO2 emissions

        // Create constructor
        public VehicleCalculations()
        {
        }

        /// <summary>
        ///  Calculate the fuel consumed over the total journey
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="fuel"></param>
        /// <returns></returns>
        public Task<double> CalculateFuelConsumption(double distance, double fuel)
        {
            double fuelConsumption = distance / fuel;

            return Task.FromResult(fuelConsumption);
        }

        /// <summary>
        /// Calculate the CO2 emissions based on the fuel consumption and average speed
        /// </summary>
        /// <param name="fuelConsumption"></param>
        /// <param name="averageSpeed"></param>
        /// <returns></returns>
        public Task<double> CalculateCO2Emissions(double fuelConsumption, double averageSpeed, string fuelType)
        {
    
            if (fuelType == "gasoline")
            {
                co2Factor = 2.31; // Conversion factor for gasoline in kg of CO2 per gallon
            }
            else if (fuelType == "diesel")
            {
                co2Factor = 2.68; // Conversion factor for diesel in kg of CO2 per liter
            }

            // Calculate CO2 emissions based on the fuel consumption and average speed
            double co2Emissions = fuelConsumption * co2Factor * (averageSpeed / 60.0);

            // Return the CO2 emissions as a double
            return Task.FromResult(co2Emissions);
        }

    }
}
