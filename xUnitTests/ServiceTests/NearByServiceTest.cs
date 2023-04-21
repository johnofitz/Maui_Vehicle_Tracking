using L00177804_Project.Service.NearByService;
using L00177804_Project.Models;
using NSubstitute;
using Xunit;

namespace xUnitTests.ServiceTests
{


    public class NearByRestServiceTest
    {
        //[Fact]
        //public async Task GetNearByAsync_ReturnsExpectedResult()
        //{
        //    // Arrange
        //    var expected = new List<NearBy>
        //{
        //    new NearBy { Name = "Gas Station 1", Geometry = new Location { Lat = 42.123, Lng = -71.456 } },
        //    new NearBy { Name = "Gas Station 2", Location = new L00177804_Project.Models.Location { Lat = 42.345, Lng = -71.789 } },
        //    new NearBy { Name = "Gas Station 3", Location = new L00177804_Project.Models.Location { Lat = 42.567, Lng = -71.012 } }
        //};

        //    // Mock the HttpClient
        //    var http = Substitute.For<HttpClient>();
        //    http.GetStreamAsync(Arg.Any<string>()).Returns(
        //        Task.FromResult((Stream)new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { results = expected })))));

        //    // Create the NearByRestService and inject the mocked HttpClient
        //    var service = new NearByRestService {};

        //    // Act
        //    var actual = await service.GetNearByAsync("42.123", "-71.456");

        //    // Assert
        //    Assert.Equal(expected, actual);
        //}
    }

}
