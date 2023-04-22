
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

            var nearBy = new NearBy
            {
                // Act
                BusinessStatus = expectedBusinessStatus,
                Icon = expectedIcon,
                IconBackgroundColor = expectedIconBackgroundColour,
                IconMaskBaseUri = expectedIconMaskUri,
                Name = expectedName,
                PlaceId = expectedPlaceId,
                Rating = expectedRating,
                Reference = expectedReference,
                Scope = expectedScope,
                UserRating = expectedUserRating,
                Vicinity = expectedVicinity,
                PriceLevel = expectedPriceLevel
            };

            // Assert
            Assert.Equal(expectedBusinessStatus, nearBy.BusinessStatus);
            Assert.Equal(expectedIcon, nearBy.Icon);
            Assert.Equal(expectedIconBackgroundColour, nearBy.IconBackgroundColor);
            Assert.Equal(expectedIconMaskUri, nearBy.IconMaskBaseUri);
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
