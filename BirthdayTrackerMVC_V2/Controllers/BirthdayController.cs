﻿using System;
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
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(BirthdayViewModel birthdayInput)
        {
            BirthdayTrackerDataAccess _birthdayTrackerDataAccess = new BirthdayTrackerDataAccess();

            try
            {
                var birthday = new Birthday();
                birthday.FirstName = birthdayInput.FirstName;
                birthday.LastName = birthdayInput.LastName;
                birthday.ConvertedDateTime = new DateTime(birthdayInput.Birthyear, birthdayInput.BirthMonth, birthdayInput.Birthday);

                _birthdayTrackerDataAccess.SaveBirthday(birthday);

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Birthday/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
            return View();
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
