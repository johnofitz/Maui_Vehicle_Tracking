using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Models.RouteModel
{
    public class LocationNear
    {
        [JsonProperty("lat")]
        public double Latitiude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
