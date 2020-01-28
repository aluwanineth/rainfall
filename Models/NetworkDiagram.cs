using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class NetworkDiagram
    {
        public int DiagramId { get; set; }
        public int? ScenarioId { get; set; }
        public string DiagramName { get; set; }
    }
}
