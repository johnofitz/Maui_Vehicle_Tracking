using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00177804_Project.Models.RouteModel
{
    public class Row
    {
        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }
    }
}
