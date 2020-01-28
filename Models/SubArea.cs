using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class SubArea
    {
        public int SubAreaId { get; set; }
        public int? StudyAreaId { get; set; }
        public int? ModelId { get; set; }
        public string SubArea1 { get; set; }
        public string SubAreaLabel { get; set; }
    }
}
