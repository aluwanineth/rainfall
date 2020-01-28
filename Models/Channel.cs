using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class Channel
    {
        public int ChannelId { get; set; }
        public int? ScenarioId { get; set; }
        public int? ChannelType { get; set; }
        public int? ChannelNumber { get; set; }
        public string ChannelName { get; set; }
        public int? UpStreamNodeNumber { get; set; }
        public int? DownStreamNodeNumber { get; set; }
    }
}
