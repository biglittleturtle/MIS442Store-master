using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;

namespace MIS442Store.Controllers
{
    public class NewsController : Controller
    {
        // Variables
        private INewsRepository _NewsRepo;

        // Constructor
        public NewsController()
        {
            _NewsRepo = new NewsRepository();
        }
               
        public ActionResult Index()
        {
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";

            return View(_NewsRepo.GetList());
        }
    }
}