using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class Scenario
    {
        public int ScenarioId { get; set; }
        public int? SubAreaId { get; set; }
        public string Scenario1 { get; set; }
        public string ScenarioLabel { get; set; }
    }
}
