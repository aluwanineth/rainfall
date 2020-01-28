using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class Node
    {
        public int NodeId { get; set; }
        public int? ScenarioId { get; set; }
        public int? NodeType { get; set; }
        public int? NodeNumber { get; set; }
        public string NodeName { get; set; }
        public double? StartingStorage { get; set; }
    }
}
