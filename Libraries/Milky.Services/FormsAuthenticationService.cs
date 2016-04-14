using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blogger.Core.Domain;
namespace Blogger.Services
{

    public partial class FormsAuthenticationService : IAuthenticationService
    {
        #region Field
        private readonly HttpContextBase _httpContext;
        private readonly IAccountService _accountService;
        private readonly TimeSpan _expirationTimeSpan;
        #endregion

        private Account _cachedAccount;

        #region Ctor
        public FormsAuthenticationService(HttpContextBase httpContext,
             IAccountService userService)
        {
            this._httpContext = httpContext;
            this._accountService = userService;
            this._expirationTimeSpan = FormsAuthentication.Timeout;

        }
        #endregion

        #region Method
        public virtual void SignIn(Account account, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
             1 /*version*/,
            "UserCookie",
             now,
             now.Add(_expirationTimeSpan),
             createPersistentCookie, account.Id.ToString(),
             FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }


            _httpContext.Response.Cookies.Add(cookie);
            _cachedAccount = account;
        }

        public virtual Account GetAuthenticatedAccount()
        {

            var cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                // var id = new Guid(ticket.UserData);
                var user = _accountService.GetById(Convert.ToInt32(ticket.UserData));
                return user;
            }
            return null;
        }

        public virtual void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion


    }

}