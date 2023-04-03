namespace xUnitTests.ViewModelTests
{
    public class MapViewModelTest
    {
        [Fact]
        public void GetNearByItemsTest()
        {
            //// Arrange
            var mapViewModel = new MapViewModel();
            //// Act
            var result = mapViewModel.GetNearByItemsAsync();
            //// Assert
            Assert.NotNull(result);
        }
    }
}