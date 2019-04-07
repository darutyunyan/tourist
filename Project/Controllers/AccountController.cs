using Project.Filters;
using Project.Models;
using Project.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        #region Action methods

        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = null;
                using (TouristContext db = new TouristContext())
                {
                    account = db.Accounts.FirstOrDefault(a => a.Email == model.Email);
                }
                if (account == null)
                {
                    account = new Account {
                        Id = Guid.NewGuid(),
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Country = model.Country
                    };

                    using (TouristContext db = new TouristContext())
                    {
                        db.Accounts.Add(account);
                        db.SaveChanges();

                        account = db.Accounts.Where(a => a.Email == model.Email && a.Password == model.Password).FirstOrDefault();
                    }

                    if (account != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Account with that email already exists!");
                }

            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                Account account = null;
                using (TouristContext db = new TouristContext())
                {
                    account = db.Accounts.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                }
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login or password incorrect!");
                }
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Settings()
        {
            Account account = null;
            AccountInformationViewModel viewModel = new AccountInformationViewModel();

            using (TouristContext db = new TouristContext())
            {
                account = db.Accounts.FirstOrDefault(a => a.Email == User.Identity.Name);

                viewModel.FirstName = account.FirstName;
                viewModel.LastName = account.LastName;
                viewModel.Country = account.Country;
            }
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult ChangeAccountInformation(AccountInformationViewModel viewModel)
        {
            JsonResult jSon = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };

            List<string> listErrors = new List<string>();

            // Check on required
            if (string.IsNullOrEmpty(viewModel.FirstName))
            {
                listErrors.Add("First name is required");
            }
            if (string.IsNullOrEmpty(viewModel.LastName))
            {
                listErrors.Add("Last name is required");
            }
            if (string.IsNullOrEmpty(viewModel.Country))
            {
                listErrors.Add("Country is required");
            }
            if (!listErrors.Any())
            {
                using (TouristContext db = new TouristContext())
                {
                    Account account = db.Accounts.FirstOrDefault(a => a.Email == User.Identity.Name);

                    account.FirstName = viewModel.FirstName;
                    account.LastName = viewModel.LastName;
                    account.Country = viewModel.Country;
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                jSon.Data = new
                {
                    IsError = true,
                    ErrorMessage = listErrors
                };
                return jSon;
            }

            jSon.Data = new
            {
                IsEror = false
            };

            return jSon;
        }
        [HttpPost]
        public JsonResult ChangePassword(ChagePasswordViewModel viewModel)
        {
            JsonResult jSon = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };

            List<string> listErrors = new List<string>();

            // Check on required
            _checkForEmpty(viewModel, ref listErrors);

            if (listErrors.Any())
            {
                jSon.Data = new
                {
                    IsError = true,
                    ErrorMessage = listErrors
                };
                return jSon;
            }

            // Check on length 
            _checkForLength(viewModel, ref listErrors);

            if (listErrors.Any())
            {
                jSon.Data = new
                {
                    IsError = true,
                    ErrorMessage = listErrors
                };
                return jSon;
            }

            using (TouristContext db = new TouristContext())
            {
                var account = db.Accounts.FirstOrDefault(a => a.Email == User.Identity.Name);

                if (!string.Equals(account.Password, viewModel.CurrentPassword))
                {
                    listErrors.Add("Incorrect password");
                }

                if (!string.Equals(viewModel.NewPassword, viewModel.NewPasswordConfirm))
                {
                    listErrors.Add("New password and repeated new password did not match.");
                }

                if (!listErrors.Any())
                {
                    account.Password = viewModel.NewPassword;
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    jSon.Data = new
                    {
                        IsError = true,
                        ErrorMessage = listErrors
                    };
                    return jSon;
                }
            }

            jSon.Data = new
            {
                IsEror = false
            };

            return jSon;
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region Private methods

        private void _checkForEmpty(ChagePasswordViewModel viewModel, ref List<string> listErrors)
        {
            if (string.IsNullOrEmpty(viewModel.CurrentPassword))
            {
                listErrors.Add("Current password is required");
            }

            if (string.IsNullOrEmpty(viewModel.NewPassword))
            {
                listErrors.Add("New password is required");
            }

            if (string.IsNullOrEmpty(viewModel.NewPasswordConfirm))
            {
                listErrors.Add("New password repeated is required");
            }
        }

        private void _checkForLength(ChagePasswordViewModel viewModel, ref List<string> listErrors)
        {
            if (viewModel.NewPassword.Count() < 6)
            {
                listErrors.Add("New password contains less than 6 characters");
            }
        }
        #endregion
    }
}