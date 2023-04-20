using L00177804_Project.Service.VehicleStoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.ServiceTests
{


    public class VehicleChangedMessageTest
    {
        [Fact]
        public void VehicleChangedMessage_ValueChangedMessageConstructor_SetsValueProperty()
        {
            // Arrange
            string expectedValue = "Test Value";

            // Act
            VehicleChangedMessage vehicleChangedMessage = new(expectedValue);

            // Assert
            Assert.Equal(expectedValue, vehicleChangedMessage.Value);
        }
    }

}
