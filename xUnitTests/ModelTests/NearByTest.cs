
namespace xUnitTests.ModelTests
{
    public class NearByTest
    {
        [Fact]
        public void NearBy_SetAndGetProperties_ShouldMatch()
        {
            // Arrange
            var expectedBusinessStatus = "open";
            var expectedIcon = "https://www.example.com/icon.png";
            var expectedIconBackgroundColour = "#ffffff";
            var expectedIconMaskUri = "https://www.example.com/mask.png";
            var expectedName = "Example Place";
            var expectedPlaceId = "12345";
            var expectedRating = 4.5;
            var expectedReference = "ABC123";
            var expectedScope = "GOOGLE";
            var expectedUserRating = 100;
            var expectedVicinity = "123 Main St";
            var expectedPriceLevel = 2;
            var nearBy = new NearBy();

            // Act
            nearBy.BuisnessStatus = expectedBusinessStatus;
            nearBy.Icon = expectedIcon;
            nearBy.IconbackgroundColour = expectedIconBackgroundColour;
            nearBy.IconMaskUri = expectedIconMaskUri;
            nearBy.Name = expectedName;
            nearBy.PlaceId = expectedPlaceId;
            nearBy.Rating = expectedRating;
            nearBy.Reference = expectedReference;
            nearBy.Scope = expectedScope;
            nearBy.UserRating = expectedUserRating;
            nearBy.Vicinity = expectedVicinity;
            nearBy.PriceLevel = expectedPriceLevel;

            // Assert
            Assert.Equal(expectedBusinessStatus, nearBy.BuisnessStatus);
            Assert.Equal(expectedIcon, nearBy.Icon);
            Assert.Equal(expectedIconBackgroundColour, nearBy.IconbackgroundColour);
            Assert.Equal(expectedIconMaskUri, nearBy.IconMaskUri);
            Assert.Equal(expectedName, nearBy.Name);
            Assert.Equal(expectedPlaceId, nearBy.PlaceId);
            Assert.Equal(expectedRating, nearBy.Rating);
            Assert.Equal(expectedReference, nearBy.Reference);
            Assert.Equal(expectedScope, nearBy.Scope);
            Assert.Equal(expectedUserRating, nearBy.UserRating);
            Assert.Equal(expectedVicinity, nearBy.Vicinity);
            Assert.Equal(expectedPriceLevel, nearBy.PriceLevel);
        }
    }
}
