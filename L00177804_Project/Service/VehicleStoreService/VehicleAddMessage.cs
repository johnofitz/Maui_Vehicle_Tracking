using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Service.VehicleInfoService
{
    public class VehicleAddMessage : ValueChangedMessage<string>
    {
        public VehicleAddMessage(string value) : base(value) { }
    }
}
