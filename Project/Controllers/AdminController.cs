using Project.Models;
using Project.Models.Repository;
using Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
            TouristContext touristContext = new TouristContext();

            _mapManagmentServuce = new MapManagmentService(touristContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCity(string name)
        {
            return Json("asd");
        }

        [HttpGet]
        public ActionResult GetCities()
        {
            List<string> response = null;

            try
            {
                response = _mapManagmentServuce.GetCities().ToList();
            }
            catch (Exception e)
            {
                //TODO
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAttraction(Attraction request)
        {
            if (TryUpdateModel(request))
            {
                try
                {
                    
                }
                catch (Exception)
                {

                    //TODO
                }
            }
            else
            {
                //TODO
            }


            return Json("asd");
        }


        private IMapManagmentService _mapManagmentServuce;
    }
}