using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class DiagramNode
    {
        public int DiagramMemberId { get; set; }
        public int? DiagramId { get; set; }
        public int? NodeId { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? Altitude { get; set; }
    }
}
