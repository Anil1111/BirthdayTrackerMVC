using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayTrackerMVC_V2.Models
{
    public class BirthdayDisplayViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}