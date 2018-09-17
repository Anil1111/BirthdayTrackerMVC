using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayTrackerMVC_V2.Models
{
    public class BirthdayViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string BirthMonth { get; set; }
        public string Birthyear { get; set; }
    }
}