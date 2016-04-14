using Blogger.Core.Domain;
using Blogger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Milky.Admin
{
    public class WebWorkContext : IWorkContext
    {
        #region Const

        private const string CustomerCookieName = "Milky.customer";

        #endregion

        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly HttpContextBase _httpContext;
        private Account _cachedAccount;

        #endregion

        #region Ctor

        public WebWorkContext(HttpContextBase httpContext, IAuthenticationService authenticationService)
        {
            this._httpContext = httpContext;
            _authenticationService = authenticationService;
        }

        #endregion
        #region Utilities

        protected virtual HttpCookie GetCustomerCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[CustomerCookieName];
        }

        protected virtual void SetAccountCookie(int id)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(CustomerCookieName);
                cookie.HttpOnly = true;
                cookie.Value = id.ToString();
                int cookieExpires = 24 * 365; //TODO make configurable
                cookie.Expires = DateTime.Now.AddHours(cookieExpires);

                _httpContext.Response.Cookies.Remove(CustomerCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }


        #endregion
        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        public virtual Account CurrentAccount
        {
            get
            {
                if (_cachedAccount != null)
                    return _cachedAccount;

                Account account = null;


                //registered user
                if (account == null)
                {
                    account = _authenticationService.GetAuthenticatedAccount();
                }

                if (account == null)
                    return null;
                    //validation

                    SetAccountCookie(account.Id);
                _cachedAccount = account;

                return _cachedAccount;
            }
            set
            {
                SetAccountCookie(value.Id);
                _cachedAccount = value;
            }
        }
    }
}