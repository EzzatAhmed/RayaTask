using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RayaTask.Model
{
    public class MapResponse
    {
        public int id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal Distance { get; set; }
        public double PinLat { get; set; }
        public double PinLang { get; set; }
        public double UserLat { get; set; }
        public double UserLang { get; set; }

    }
}
