using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            Response.StatusDescription = "Internal error";
            return View();
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 400;
            Response.StatusDescription = "External error";
            return View();
        }
    }
}