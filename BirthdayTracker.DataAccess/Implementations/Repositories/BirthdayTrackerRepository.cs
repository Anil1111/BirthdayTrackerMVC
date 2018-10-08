using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayTracker.DataAccess.Contracts;
using System.Data.SqlClient;
using BirthdayTracker.Contracts;
using MySql.Data.MySqlClient;

namespace BirthdayTracker.DataAccess.Implementations.Repositories
{
    public class BirthdayTrackerRespository : IBirthdayTrackerRepository
    {
        public void DeleteBirthday(int id)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password = MikeSierra21!!;database=birthday_tracker"))
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM `birthday_tracker`.`birthdays` WHERE id = @Id", conn);
                command.Parameters.Add(new MySqlParameter("Id", id));

                command.ExecuteNonQuery();

            }
        }

        public List<Birthday> GetAllSavedBirthdays()
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password = MikeSierra21!!;database=birthday_tracker"))
            {
                List<Birthday> birthdayList = new List<Birthday>();

                conn.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM birthday_tracker.birthdays", conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Birthday birthday = new Birthday();
                        birthday.BirthdayId = reader.GetInt32(0);
                        birthday.FirstName = reader.GetString(1);
                        birthday.LastName = reader.GetString(2);
                        birthday.ConvertedDateTime = reader.GetDateTime(3);
                        

                        birthdayList.Add(birthday);

                    }
                }

                return birthdayList;

            }
        }

        public Birthday GetSingleSavedBirthday(int id)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password = MikeSierra21!!;database=birthday_tracker"))
            {
                var birthday = new Birthday();

                conn.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM birthday_tracker.birthdays WHERE id = @id", conn);
                command.Parameters.Add(new MySqlParameter("id", id));
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        birthday.BirthdayId = reader.GetInt32(0);
                        birthday.FirstName = reader.GetString(1);
                        birthday.LastName = reader.GetString(2);
                        birthday.ConvertedDateTime = reader.GetDateTime(3);

                    }
                }

                return birthday;

            }
        }

        public void SaveBrithday(Birthday birthday)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; user id = root;" +
                                        "password = MikeSierra21!!; database = birthday_tracker"))
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO `birthday_tracker`.`birthdays` (`FirstName`, `LastName`, `Birthday`) VALUES (@FirstName, @LastName, @Birthday);", conn);
                command.Parameters.Add(new MySqlParameter("FirstName", birthday.FirstName));
                command.Parameters.Add(new MySqlParameter("LastName", birthday.LastName));
                command.Parameters.Add(new MySqlParameter("Birthday", birthday.ConvertedDateTime));

                command.ExecuteNonQuery();

            }
        }

        public void UpdateBirthday(Birthday birthday, int id)
        {
            using (MySqlConnection conn = new MySqlConnection("server = localhost; user id = root;" +
                                         "password = MikeSierra21!!; database = birthday_tracker"))
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand("UPDATE `birthday_tracker`.`birthdays` SET FirstName = @FirstName, LastName = @LastName, Birthday = @Birthday WHERE Id = @Id", conn);
                command.Parameters.Add(new MySqlParameter("Id", id));
                command.Parameters.Add(new MySqlParameter("FirstName", birthday.FirstName));
                command.Parameters.Add(new MySqlParameter("LastName", birthday.LastName));
                command.Parameters.Add(new MySqlParameter("Birthday", birthday.ConvertedDateTime));

                command.ExecuteNonQuery();

            }
        }
    }
}
