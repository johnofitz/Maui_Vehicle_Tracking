using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xUnitTests.ViewModelTests
{
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using Xunit;
  

    public class AddVehicleViewModelTest
    {
/*
        private readonly string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "test.json");

        [Fact]
        public async Task SaveVehicleData_ValidData_SavesDataToFile()
        {
            // Arrange
            var viewModel = new AddVehicleViewModel();
            viewModel.Names = "John";
            viewModel.Makes = "Toyota";
            viewModel.Models = "Camry";
            viewModel.EngineSizes = "2.5L";
            viewModel.SelectedFuelType = "Petrol";
            viewModel.Odometers = "1000";
            viewModel.SelectedConsumptionType = "MilesPerGallon";
            viewModel.SelectedDistanceType = "Miles";
            viewModel.InsurencePolicys = "Policy1";
            viewModel.InsurenceCompanys = "Company1";
            viewModel.Licences = "License1";

            // Act
            await viewModel.SaveVehicleData();

            // Assert
            Assert.True(File.Exists(targetFile));

            string json = File.ReadAllText(targetFile);
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json);
            Assert.NotNull(vehicles);
            Assert.NotEmpty(vehicles);
            Assert.Equal("John", vehicles[0].Name);
            Assert.Equal("Toyota", vehicles[0].Make);
            Assert.Equal("Camry", vehicles[0].Model);
            Assert.Equal("2.5L", vehicles[0].EngineSize);
            Assert.Equal("Petrol", vehicles[0].FuelType);
            Assert.Equal(1000, vehicles[0].Odometer);
            Assert.Equal("MilesPerGallon", vehicles[0].FuelConsumption);
            Assert.Equal("Miles", vehicles[0].Distance);
            Assert.Equal("Policy1", vehicles[0].InsurencePolicy);
            Assert.Equal("Company1", vehicles[0].InsurenceCompany);
            Assert.Equal("License1", vehicles[0].Licence);
        }

        [Fact]
        public async Task SaveVehicleData_InvalidData_DoesNotSaveDataToFile()
        {
            // Arrange
            var viewModel = new AddVehicleViewModel();
            viewModel.Names = "";
            viewModel.Makes = "Toyota";
            viewModel.Models = "Camry";
            viewModel.EngineSizes = "2.5L";
            viewModel.SelectedFuelType = "Petrol";
            viewModel.Odometers = "InvalidOdometer"; // This will trigger the validation error
            viewModel.SelectedConsumptionType = "MilesPerGallon";
            viewModel.SelectedDistanceType = "Miles";
            viewModel.InsurencePolicys = "Policy1";
            viewModel.InsurenceCompanys = "Company1";
            viewModel.Licences = "License1";

            // Act
            await viewModel.SaveVehicleData();

            // Assert
            Assert.False(File.Exists(targetFile));
        }*/

    }

}
