using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.Contracts
{
    [Serializable]
    public class Birthday
    {
        private string _firstName;
        private string _lastName;
        private int _birthYear;
        private int _birthMonth;
        private int _birthDay;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int BirthYear
        {
            get { return _birthYear; }
            set { _birthYear = value; }
        }

        public int BirthMonth
        {
            get { return _birthMonth; }
            set { _birthMonth = value; }
        }

        public int BirthDay
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }

        public DateTime ConvertedDateTime
        {
            get; set;
        }

        public int BirthdayId { get; set; }


    }
}
