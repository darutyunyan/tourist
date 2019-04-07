using Project.Filters;
using Project.Models;
using Project.Models.Services;
using Project.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ContactUsViewModel viewModel = new ContactUsViewModel();
                using (TouristContext db = new TouristContext())
                {
                    var account = db.Accounts.FirstOrDefault(a => a.Email == User.Identity.Name);
                    if (account != null)
                    {
                        viewModel.Email = account.Email;
                        viewModel.FirstName = account.FirstName;
                        viewModel.LastName = account.LastName;
                        viewModel.Country = account.Country;
                    }
                    return View(viewModel);
                }

            }
            return View();
        }

        [HttpPost]
        [ExceptionLogger]
        public ActionResult Index(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mail.Send(model.Topic, model.FirstName, model.LastName, model.Email, model.Country, model.Text);
            }

            return View(model);
        }
    }
}