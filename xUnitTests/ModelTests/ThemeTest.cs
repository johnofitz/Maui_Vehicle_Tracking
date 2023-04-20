using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.ModelTests
{
    public class ThemeTests
    {
        [Fact]
        public void Theme_SetAndGetProperties_ShouldMatch()
        {
            // Arrange
            var expectedName = "Default";
            var expectedKey = "default";
            var theme = new Theme(expectedName, expectedKey);

            // Act
            var actualName = theme.Name;
            var actualKey = theme.Key;

            // Assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedKey, actualKey);
        }
    }
}
