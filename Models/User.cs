using System;
using System.Collections.Generic;

namespace RainFall.WebApi.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhoneNo { get; set; }
        public string Password { get; set; }
        public int? Enabled { get; set; }
    }
}
