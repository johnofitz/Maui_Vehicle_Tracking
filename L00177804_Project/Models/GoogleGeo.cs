using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Models
{
    public class GoogleGeo
    {

        [JsonProperty("location")]
        public LocationNear Location { get; set; }
    }
}
