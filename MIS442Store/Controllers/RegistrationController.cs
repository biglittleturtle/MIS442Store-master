using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using MIS442Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class RegistrationController : Controller
    {
        IRegistrationRepository _Repo = new RegistrationRepository();
        IStateRepository _State = new StateRepository();

        [HttpGet]
        public ActionResult Index() // list registrations for a specific user
        {
            return View(_Repo.GetUserRegistrations("timmy"));
        }

        [HttpGet]
        public ActionResult AddRegistration()
        {
            RegistrationModel model = new RegistrationModel();
            model.State = _State.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRegistration(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                registration.State = _State.Get();
                return View(registration);
            }
            Registration r = new Registration();
            r.RegistrationAddress = registration.RegistrationAddress;
            r.RegistrationCity = registration.RegistrationCity;
            r.RegistrationDate = registration.RegistrationDate;
            r.RegistrationID = registration.RegistrationID;
            r.RegistrationPhone = registration.RegistrationPhone;
            r.RegistrationProductID = registration.RegistrationProductID;
            r.RegistrationSerialNumber = registration.RegistrationSerialNumber;
            r.RegistrationState = registration.RegistrationState;
            r.RegistrationUserName = registration.RegistrationUserName;
            r.RegistrationVerified = registration.RegistrationVerified;
            r.RegistrationZip = registration.RegistrationZip;
            _Repo.SaveRegistration(r);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminIndex() // list all registrations
        {
            return View(_Repo.GetRegistrations());
        }
    }
}