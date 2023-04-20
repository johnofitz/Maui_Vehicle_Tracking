using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.ServiceTests
{

    public class VehicleAddMessageTest
    {
        [Fact]
        public void VehicleAddMessage_ValueChangedMessageConstructor_SetsValueProperty()
        {
            // Arrange
            string expectedValue = "Test Value";

            // Act
            VehicleAddMessage vehicleAddMessage = new VehicleAddMessage(expectedValue);

            // Assert
            Assert.Equal(expectedValue, vehicleAddMessage.Value);
        }
    }

}
