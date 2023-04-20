

namespace xUnitTests.ViewModelTests
{


    public class ParentViewModelTest
    {
        [Fact]
        public void ParentViewModel_ShouldInitializeProperties()
        {
            // Arrange
            var parentViewModel = new ParentViewModel();

            // Act
            // No action needed, since the default constructor doesn't set any values

            // Assert
            Assert.False(parentViewModel.isBusy);
            Assert.Null(parentViewModel.heading);
            Assert.Null(parentViewModel.vehicleName);
            Assert.Equal(0.0, parentViewModel.vehicleKm);
            Assert.True(parentViewModel.IsNotBusy);
        }

        [Fact]
        public void ParentViewModel_IsNotBusy_ShouldReturnCorrectValue()
        {
            // Arrange
            var parentViewModel = new ParentViewModel();
            parentViewModel.isBusy = true;

            // Act
            bool result = parentViewModel.IsNotBusy;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ParentViewModel_IsNotBusy_ShouldReturnTrueWhenIsBusyIsFalse()
        {
            // Arrange
            var parentViewModel = new ParentViewModel();
            parentViewModel.isBusy = false;

            // Act
            bool result = parentViewModel.IsNotBusy;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ParentViewModel_SetProperties_ShouldReflectChanges()
        {
            // Arrange
            var parentViewModel = new ParentViewModel();

            // Act
            parentViewModel.heading = "Test Heading";
            parentViewModel.vehicleName = "Test Vehicle";
            parentViewModel.vehicleKm = 100.0;

            // Assert
            Assert.Equal("Test Heading", parentViewModel.heading);
            Assert.Equal("Test Vehicle", parentViewModel.vehicleName);
            Assert.Equal(100.0, parentViewModel.vehicleKm);
        }
    }

}
