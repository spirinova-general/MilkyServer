using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blogger.Core.Domain;
namespace Blogger.Services
{

    //public partial class FormsAuthenticationService:IAuthenticationService
    //{
    //    #region Field
    //    private readonly HttpContextBase _httpContext;
    //    private readonly IUserService _userService;
    //    private readonly TimeSpan _expirationTimeSpan;
    //    #endregion

    //    private User _cachedUser;

    //    #region Ctor
    //    public FormsAuthenticationService(HttpContextBase httpContext,
    //         IUserService userService)
    //    {
    //        this._httpContext = httpContext;
    //        this._userService = userService;
    //        this._expirationTimeSpan = FormsAuthentication.Timeout;

    //    }
    //    #endregion

    //    #region Method
    //    public virtual void SignIn(User user, bool createPersistentCookie)
    //    {
    //        var now = DateTime.UtcNow.ToLocalTime();

    //        var ticket = new FormsAuthenticationTicket(
    //         1 /*version*/,
    //        "UserCookie",
    //         now,
    //         now.Add(_expirationTimeSpan),
    //         createPersistentCookie, user.Id.ToString(),
    //         FormsAuthentication.FormsCookiePath);

    //        var encryptedTicket = FormsAuthentication.Encrypt(ticket);

    //        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
    //        cookie.HttpOnly = true;
    //        if (ticket.IsPersistent)
    //        {
    //            cookie.Expires = ticket.Expiration;
    //        }
    //        cookie.Secure = FormsAuthentication.RequireSSL;
    //        cookie.Path = FormsAuthentication.FormsCookiePath;
    //        if (FormsAuthentication.CookieDomain != null)
    //        {
    //            cookie.Domain = FormsAuthentication.CookieDomain;
    //        }


    //        _httpContext.Response.Cookies.Add(cookie);
    //        _cachedUser = user;
    //    }

    //    public virtual User GetAuthenticatedUser()
    //    {

    //        var cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
    //        if (cookie != null)
    //        {
    //            var ticket = FormsAuthentication.Decrypt(cookie.Value);
    //            // var id = new Guid(ticket.UserData);
    //            var user = _userService.GetById(Convert.ToInt32(ticket.UserData));
    //            return user;
    //        }
    //        return null;
    //    }

    //    public virtual void SignOut()
    //    {
    //        FormsAuthentication.SignOut();
    //    }

    //    #endregion


    //}

}