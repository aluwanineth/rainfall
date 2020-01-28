using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class DiagramChannel
    {
        public int DiagramMemberId { get; set; }
        public int? DiagramId { get; set; }
        public int? ChannelId { get; set; }
    }
}
