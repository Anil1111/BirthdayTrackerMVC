using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayTrackerMVC_V2.Models
{
    public class BirthdayInputViewModel
    {
        public int BirthdayId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
    }
}