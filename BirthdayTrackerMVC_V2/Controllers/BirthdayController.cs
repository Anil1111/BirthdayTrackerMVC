using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirthdayTracker.Contracts;
using BirthdayTrackerMVC_V2.Models;
using BirthdayTracker.DataAccess.Implementations;

namespace BirthdayTrackerMVC_V2.Controllers
{
    public class BirthdayController : Controller
    {
        // GET: Birthday
        public ActionResult Index(
            )
        {
            BirthdayTrackerDataAccess _birthdayTrackerDataAccess = new BirthdayTrackerDataAccess();

            var birthdayList = _birthdayTrackerDataAccess.GetSavedBirthdays();
            var mappedBirthdayList = new List<BirthdayDisplayViewModel>();

            foreach (var b in birthdayList)
            {
                var mappedBirthday = new BirthdayDisplayViewModel();
                mappedBirthday.BirthdayId = b.BirthdayId;
                mappedBirthday.FirstName = b.FirstName;
                mappedBirthday.LastName = b.LastName;
                mappedBirthday.Birthday = b.ConvertedDateTime;


                mappedBirthdayList.Add(mappedBirthday);

            }

            return View(mappedBirthdayList);
        }

        //GET: Birthday/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Birthday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birthday/Create
        [HttpPost]
        public ActionResult Create(BirthdayInputViewModel birthdayInput)
        {
            BirthdayTrackerDataAccess _birthdayTrackerDataAccess = new BirthdayTrackerDataAccess();

            try
            {
                var birthday = new Birthday();
                birthday.FirstName = birthdayInput.FirstName;
                birthday.LastName = birthdayInput.LastName;
                birthday.ConvertedDateTime = new DateTime(birthdayInput.BirthYear, birthdayInput.BirthMonth, birthdayInput.BirthDay);

                _birthdayTrackerDataAccess.SaveBirthday(birthday);

                TempData["Message"] = "Birthday Saved!!!";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Birthday/Edit/5
        public ActionResult Edit(int id)
        {
            BirthdayTrackerDataAccess _birthdayTrackerDataAccess = new BirthdayTrackerDataAccess();

            var birthday = _birthdayTrackerDataAccess.GetSingleSavedBirthday(id);
            var mappedBirthday = new BirthdayInputViewModel();

            mappedBirthday.BirthdayId = birthday.BirthdayId;
            mappedBirthday.FirstName = birthday.FirstName;
            mappedBirthday.LastName = birthday.LastName;
            mappedBirthday.BirthDay = birthday.ConvertedDateTime.Day;
            mappedBirthday.BirthMonth = birthday.ConvertedDateTime.Month;
            mappedBirthday.BirthYear = birthday.ConvertedDateTime.Year;


            return View(mappedBirthday);
        }

        // POST: Birthday/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Birthday/Delete/5
        public ActionResult Delete(int id)
        {
            BirthdayTrackerDataAccess _birthdayTrackerDataAccess = new BirthdayTrackerDataAccess();

            _birthdayTrackerDataAccess.DeleteBirthday(id);

            return RedirectToAction("Index");
        }

        // POST: Birthday/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
