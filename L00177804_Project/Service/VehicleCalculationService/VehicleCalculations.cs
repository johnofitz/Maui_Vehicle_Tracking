

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
        public Task<double> CalculateFuelConsumption(int distance, double fuel)
        {
            double fuelConsumption = distance * (fuel/100);

            return Task.FromResult(fuelConsumption);
        }

        /// <summary>
        /// Calculate the CO2 emissions based on the fuel consumption and average speed
        /// </summary>
        /// <param name="fuelConsumption"></param>
        /// <returns></returns>
        public Task<double> CalculateCO2Emissions(double fuelConsumption, string fuelType)
        {
    
            if (fuelType == "Petrol")
            {
                co2Factor = 2.31; // Conversion factor for gasoline in kg of CO2 per gallon
            }
            else if (fuelType == "Diesel")
            {
                co2Factor = 2.68; // Conversion factor for diesel in kg of CO2 per liter
            }

            // Calculate CO2 emissions based on the fuel consumption and average speed
            double co2Emissions = fuelConsumption * co2Factor*3.664 ;

            // Return the CO2 emissions as a double
            return Task.FromResult(co2Emissions);
        }

    }
}
