using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayTracker.Contracts;

namespace BirthdayTracker.DataAccess.Contracts
{
    public interface IBirthdayTrackerRepository
    {
        void SaveBrithday(Birthday birthday);

        List<Birthday> GetSavedBirthdays();
    }
}

