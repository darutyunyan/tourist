using Project.Filters;
using Project.Models;
using Project.Models.Repository;
using Project.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            TouristContext dbContect = new TouristContext();

            _cityRepo = new CityRepository(dbContect);
        }

        public ActionResult Index()
        {
            IndexViewModel response = new IndexViewModel();

            try
            {
                if (User.Identity.IsAuthenticated)
                    response.IsAuthenticated = true;

                response.Cities = _cityRepo.GetCities().Select(c => c.Name).ToArray();
            }
            catch (Exception)
            {

                throw;
            }

            
            return View(response);
        }

        private CityRepository _cityRepo = null;
    }
}