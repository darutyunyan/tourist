using Project.Models;
using Project.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class MapController : Controller
    {
        public MapController()
        {
            TouristContext touristContext = new TouristContext();

            _cityRepo = new CityRepository(touristContext);
            _attractionRepo = new AttractionRepository(touristContext);
            _routeRepo = new RouteRepository(touristContext);
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
                response = _cityRepo.GetCities().Select(c=>c.Name).ToList();
            }
            catch (Exception e)
            {
                //TODO
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAttraction(string name)
        {
            return Json("asd");
        }


        private ICiryRepository _cityRepo = null;

        private IAttractionRepository _attractionRepo = null;

        private IRouteRepository _routeRepo = null;      
    }
}