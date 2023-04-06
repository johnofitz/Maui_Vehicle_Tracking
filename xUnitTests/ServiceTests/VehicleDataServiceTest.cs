
using L00177804_Project.Service.VehicleInfoService;
using System.IO;
using System.Reflection;

namespace xUnitTests.ServiceTests
{
    public class VehicleDataServiceTests
    {                    
        [Fact]
        public void GetVehiclesInfo_ReturnsVehiclesList()
        {

           
            //// Arrange
            //var file = "test.json";
            //var expectedCount = 3; // Update this with the expected count of vehicles in your test file

            //VehicleDataService dataService = new();

            //// Act
            //var result = await dataService.GetVehiclesInfo(file);

            //// Assert
            //Assert.Equal(expectedCount, result.Count);
        }

        //[Fact]
        //public async Task GetVehiclesInfo_ReturnsCachedVehiclesList()
        //{
        //    // Arrange
        //    var file = "test.json";
        //    var expectedCount = 3; // Update this with the expected count of vehicles in your test file
            
        //    // Act
        //    var result1 = await sut.GetVehiclesInfo(file);
        //    var result2 = await sut.GetVehiclesInfo(file);

        //    // Assert
        //    Assert.Equal(expectedCount, result1.Count);
        //    Assert.Same(result1, result2);
        //}

        //[Fact]
        //public async Task GetVehiclesInfo_ThrowsFileNotFoundException()
        //{
        //    // Arrange
        //    var file = "nonexistentfile.json";
        //    var sut = new VehicleDataService(); // Update with the name of your class that contains the GetVehiclesInfo method

        //    // Act & Assert
        //    await Assert.ThrowsAsync<FileNotFoundException>(() => sut.GetVehiclesInfo(file));
        //}
    }
   }
