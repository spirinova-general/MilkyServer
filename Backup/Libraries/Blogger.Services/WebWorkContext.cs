using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class WebWorkContext : IWorkContext
    {
        #region Const
        private const string UserCookieName = "Contact.User";
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        #endregion

        #region Fields
        private readonly HttpContextBase _httpContext;
        private User _cachedUser;
        #endregion

        #region Ctor
        public WebWorkContext(HttpContextBase httpContext,
             IAuthenticationService authenticationService,
            IUserService userService)
        {
            this._httpContext = httpContext;
            this._authenticationService = authenticationService;
            this._userService = userService;
        }
        #endregion
        #region Utilities
        protected virtual HttpCookie GetUserCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[UserCookieName];
        }

        protected virtual void SetUserCookie(int id)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(UserCookieName);
                cookie.HttpOnly = true;
                cookie.Value = id.ToString();
                if (id == null)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24 * 365; //TODO make configurable
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);
                }

                _httpContext.Response.Cookies.Remove(UserCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }
      

        #endregion

        #region Methods
        public virtual User CurrentUser
        {
            get
            {
                if (_cachedUser != null)
                    return _cachedUser;

                User user = null;

                //registered user
                if (user == null )
                {
                    user = _authenticationService.GetAuthenticatedUser();
                }


                //validation
                if (user != null)
                {
                    SetUserCookie(user.Id);
                    _cachedUser = user;
                }

                return _cachedUser;
            }
            set
            {
                SetUserCookie(value.Id);
                _cachedUser = value;
            }
        }
      
        #endregion
    }
}