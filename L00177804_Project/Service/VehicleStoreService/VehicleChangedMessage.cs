using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Service.VehicleStoreService
{
    public class VehicleChangedMessage : ValueChangedMessage<string>
    {
        public VehicleChangedMessage(string value) : base(value)
        {
        }
    }
}
