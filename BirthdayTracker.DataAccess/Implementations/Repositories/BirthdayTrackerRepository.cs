using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayTracker.DataAccess.Contracts;
using System.Data.SqlClient;
using BirthdayTracker.Contracts;

namespace BirthdayTracker.DataAccess.Implementations.Repositories
{
    public class BirthdayTrackerRespository : IBirthdayTrackerRepository
    {
        public List<Birthday> GetSavedBirthdays()
        {
            using (SqlConnection conn = new SqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=birthday_tracker"))
            {
                List<Birthday> birthdayList = new List<Birthday>();

                conn.Open();

                SqlCommand command = new SqlCommand("SELECT TOP 1000 * FROM birthdays", conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Birthday birthday = new Birthday();
                        birthday.FirstName = reader.GetString(1);
                        birthday.LastName = reader.GetString(2);
                        birthday.ConvertedDateTime = reader.GetDateTime(3);

                        birthdayList.Add(birthday);

                    }
                }

                return birthdayList;

            }
        }

        public void SaveBrithday(Birthday birthday)
        {
            using (SqlConnection conn = new SqlConnection("server = localhost; user id = root;" +
                                        "persistsecurityinfo = True; database = birthday_tracker"))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO birthdays ('FirstName','LastName','Birthday')VALUES(@FirstName, @LastName, @Birthday); ", conn);
                command.Parameters.Add(new SqlParameter("FirstName", birthday.FirstName));
                command.Parameters.Add(new SqlParameter("LastName", birthday.LastName));
                command.Parameters.Add(new SqlParameter("Birthday", birthday.ConvertedDateTime));

                command.ExecuteNonQuery();

            }
        }
    }
}
