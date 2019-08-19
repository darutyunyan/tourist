using Project.Dto;
using Project.Models;
using Project.Models.Repository;
using Project.ModelView;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            TouristContext dbContect = new TouristContext();

            _cityRepo = new CityRepository(dbContect);
            _accountRepo = new AccountRepository(dbContect);
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

        [HttpPost]
        public ActionResult SignUp(SignUpRequest request)
        {
            Response response = new Response();

            try
            {
                ValidateModel(request);

                Account account = this._accountRepo.GetAccountByEmail(request.Email);

                if (account == null)
                {
                    account = new Account
                    {
                        Id = Guid.NewGuid(),
                        Email = request.Email,
                        Password = request.Password,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Country = request.Country
                    };

                    this._accountRepo.AddAccount(account);

                    if (this._accountRepo.IsLogged(account.Email, account.Password))
                    {
                        FormsAuthentication.SetAuthCookie(request.Email, true);
                    }
                }
            }
            catch (Exception e)
            {
            }

            return Json(response);
        }

        [HttpPost]
        public ActionResult Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            if (ModelState.IsValid)
            {
                if (this._accountRepo.IsLogged(request.Email, request.Password))
                {
                    FormsAuthentication.SetAuthCookie(request.Email, true);
                    response.IsLogged = true;
                }
                else
                {
                    response.IsLogged = false;
                }
            }
            return Json(response);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Response repones = new Response();
            FormsAuthentication.SignOut();

            return Json(repones, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetContactUsInformation()
        {
            GetContactUsInformationResponse response = new GetContactUsInformationResponse();

            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    using (TouristContext db = new TouristContext())
                    {
                        var account = db.Accounts.FirstOrDefault(a => a.Email == User.Identity.Name);
                        if (account != null)
                        {
                            response.FirstName = account.FirstName;
                            response.LastName = account.LastName;
                            response.Email = account.Email;
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Settings()
        {
            AccountInformationViewModel actionResult = null;

            try
            {
                Account account = this._accountRepo.GetAccountByEmail(User.Identity.Name); // exception

                AccountInformationViewModel accountInformation = new AccountInformationViewModel()
                {

                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Country = account.Country
                };

                actionResult = accountInformation;
            }
            catch (Exception)
            {
                throw;
            }

            return View(actionResult);
        }

        private CityRepository _cityRepo = null;

        private IAccountRepository _accountRepo = null;
    }
}