using Project.Dto;
using Project.Filters;
using Project.Models;
using Project.Models.Repository;
using Project.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
            TouristContext dbContect = new TouristContext();

            _accountRepo = new AccountRepository(dbContect);
        }

        #region Action methods

        [HttpPost]
        public ActionResult ChangeAccountInformation(AccountInformationViewModel viewModel)
        {
            Debug.Assert(!string.IsNullOrEmpty(viewModel.FirstName));
            Debug.Assert(!string.IsNullOrEmpty(viewModel.LastName));
            Debug.Assert(!string.IsNullOrEmpty(viewModel.Country));

            JsonResult jsonResult = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };

            if (TryUpdateModel(viewModel))
            {
                try
                {
                    Account account = this._accountRepo.GetAccountByEmail(User.Identity.Name);

                    account.FirstName = viewModel.FirstName;
                    account.LastName = viewModel.LastName;
                    account.Country = viewModel.Country;

                    this._accountRepo.UpdateAccount(account);

                    jsonResult.Data = new
                    {
                        IsError = false
                    };
                }
                catch (Exception ex)
                {
                    jsonResult.Data = new
                    {
                        IsExceptionError = true,
                        ErrorMessage = ex.Message
                    };
                }
            }
            else
            {
                ModelState modelState;

                string firstNameError = null;
                string lastNameError = null;
                string counrtyError = null;

                ViewData.ModelState.TryGetValue("FirstName", out modelState);
                if (modelState.Errors.Count > 0)
                    firstNameError = modelState.Errors[0].ErrorMessage;

                ViewData.ModelState.TryGetValue("LastName", out modelState);
                if (modelState.Errors.Count > 0)
                    lastNameError = modelState.Errors[0].ErrorMessage;

                ViewData.ModelState.TryGetValue("Country", out modelState);
                if (modelState.Errors.Count > 0)
                    counrtyError = modelState.Errors[0].ErrorMessage;

                jsonResult.Data = new
                {
                    IsError = true,
                    FirstNameError = firstNameError,
                    LastNameError = lastNameError,
                    CountryError = counrtyError
                };
            }

            return jsonResult;
        }

        [HttpPost]
        public ActionResult ChangePassword(ChagePasswordViewModel viewModel)
        {
            Debug.Assert(!string.IsNullOrEmpty(viewModel.CurrentPassword));
            Debug.Assert(!string.IsNullOrEmpty(viewModel.NewPassword));
            Debug.Assert(!string.IsNullOrEmpty(viewModel.NewPasswordConfirm));

            JsonResult jsonResult = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
            if (TryUpdateModel(viewModel))
            {
                try
                {
                    Account account = this._accountRepo.GetAccountByEmail(User.Identity.Name);

                    if (account.Password != viewModel.CurrentPassword)
                        throw new Exception("Incorect current password!");

                    account.Password = viewModel.NewPassword;

                    this._accountRepo.UpdateAccount(account);

                    jsonResult.Data = new
                    {
                        IsError = false
                    };
                }
                catch (Exception ex)
                {
                    jsonResult.Data = new
                    {
                        IsExceptionError = true,
                        ErrorMessage = ex.Message
                    };
                }
            }
            else
            {
                ModelState modelState;

                string currentPasswordError = null;
                string newPasswordError = null;
                string newPasswordConfirmError = null;

                ViewData.ModelState.TryGetValue("CurrentPassword", out modelState);
                if (modelState.Errors.Count > 0)
                    currentPasswordError = modelState.Errors[0].ErrorMessage;

                ViewData.ModelState.TryGetValue("NewPassword", out modelState);
                if (modelState.Errors.Count > 0)
                    newPasswordError = modelState.Errors[0].ErrorMessage;

                ViewData.ModelState.TryGetValue("NewPasswordConfirm", out modelState);
                if (modelState.Errors.Count > 0)
                    newPasswordConfirmError = modelState.Errors[0].ErrorMessage;

                jsonResult.Data = new
                {
                    IsError = true,
                    CurrentPasswordError = currentPasswordError,
                    NewPasswordError = newPasswordError,
                    NewPasswordConfirmError = newPasswordConfirmError
                };
            }

            return jsonResult;
        }

        #endregion

        IAccountRepository _accountRepo = null;
    }
}