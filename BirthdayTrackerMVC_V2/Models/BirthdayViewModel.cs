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
        public int Birthday { get; set; }
        public int BirthMonth { get; set; }
        public int Birthyear { get; set; }
    }
}