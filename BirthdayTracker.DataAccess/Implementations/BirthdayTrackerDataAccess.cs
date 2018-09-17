using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayTracker.DataAccess.Contracts;
using BirthdayTracker.DataAccess.Implementations.Repositories;
using BirthdayTracker.Contracts;


namespace BirthdayTracker.DataAccess.Implementations
{
    public class BirthdayTrackerDataAccess
    {

        private readonly IBirthdayTrackerRepository _birthdayTrackerRepository;

        public BirthdayTrackerDataAccess()
        {
            _birthdayTrackerRepository = new BirthdayTrackerRespository();
        }

        public List<Birthday> GetSavedBirthdays()
        {
            return _birthdayTrackerRepository.GetSavedBirthdays();
        }

        public void SaveBirthday(Birthday birthday)
        {
            _birthdayTrackerRepository.SaveBrithday(birthday);
        }

    }
}
