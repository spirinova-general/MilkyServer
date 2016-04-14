using Blogger.Services;
using Milky.Admin;
using Milky.Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Milky.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region Field

        private readonly IAccountService _accountService;
        private readonly IWorkContext _workContext;
        private readonly IAuthenticationService _authenticatinService;

        #endregion

        #region Ctor
        public AccountController(IAccountService accountService, IWorkContext workContext, IAuthenticationService authenticatinService)
        {
            this._accountService = accountService;
            _workContext = workContext;
            _authenticatinService = authenticatinService;
        }
        #endregion

        public ActionResult AccountList()
        {
            if (_workContext.CurrentAccount == null)
                return RedirectToAction("Login");

            return View("GetAllAccounts");
        }

        /// <summary>
        /// returns all accounts
        /// </summary>
        [HttpGet]
        public ActionResult GetAllAccounts(string sidx, string sord, int page, int rows)
        {
            try
            {
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;

                var accounts = _accountService.GetAll();

                var accountModelList = new List<AccountModel>();

                accountModelList.AddRange(accounts.Select(x => new AccountModel()
                {
                    Id = x.Id,
                    FarmerCode = x.FarmerCode,
                    CreatedOn = x.DateAdded,
                    StartDate = x.StartDate.ToString("dd MMMM yyyy"),
                    EndDate = x.EndDate.ToString("dd MMMM yyyy"),
                    FarmerName = string.Format("{0} {1}", x.FirstName.Trim(), x.LastName.Trim()),
                    MobileNumber = x.Mobile,
                    Validated = x.Validated ? "Yes" : "No",
                    TotalSms = x.TotalSms,
                    NewSms = 0

                }));

                var totalRecord = accountModelList.Count();

                var totalPages = (int)Math.Ceiling((float)totalRecord / (float)rows);

                if (sord.ToUpper() == "DESC")
                    accountModelList = accountModelList.OrderByDescending(x => x.FarmerName).ToList();
                else
                    accountModelList = accountModelList.OrderBy(x => x.FarmerName).ToList();

                accountModelList = accountModelList.Skip(pageIndex * pageSize).Take(pageSize).ToList();

                var result = new
                {
                    total = totalPages,
                    page = page,
                    records = totalRecord,
                    rows = accountModelList
                };

                return Json(result, JsonRequestBehavior.AllowGet);

                //return accountModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public JsonResult UpdateAccount(int id, AccountModel model)
        {
            try
            {
                if (model == null || id == 0)
                    throw new ArgumentNullException("model or accountId");

                var account = _accountService.GetById(id);

                if (account == null)
                    throw new ArgumentNullException("account");

                account.TotalSms += model.NewSms;
                account.EndDate = Convert.ToDateTime(model.EndDate);

                _accountService.Update(account);

                return Json( "Data updated successfully" );

            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            if (_workContext.CurrentAccount != null)
                return RedirectToAction("AccountList");

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                var account = _accountService.GetByMobileNumber(loginModel.MobileNo);
                string password = ConfigurationManager.AppSettings["AdminPassword"];
                if (account != null && loginModel.Password == password)
                {
                    _authenticatinService.SignIn(account, true);
                    return Json(new { success = true, responseText = "Login sucess" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Mobile number or password do not match" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;//maintain log
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            _authenticatinService.SignOut();
            return RedirectToAction("Login");
        }

    }
}