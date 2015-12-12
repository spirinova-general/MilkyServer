using AutoMapper;
using Blogger.Core.Domain;
using Blogger.Services;
using Contacts.Web.Extensions;
using Contacts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;

namespace Contacts.Web.Controllers
{
    public class AccountController :ApiController
    {
        #region Field
       
        private readonly IAccountService _accountService;
      

        #endregion

        #region Ctor
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        #endregion
      
      [ResponseType(typeof(AccountModel))]
        public HttpResponseMessage Create(AccountModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = new Account();
                    Mapper.CreateMap<AccountModel, Account>();
                    account = model.ToEntity();
                   _accountService.Insert(account);
                    var response = new HttpResponseMessage(HttpStatusCode.Created);
                    return response;
                }
                else
                {
                    return null;
                  //  return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");
                }
            }
            catch (Exception ex)
            {
                return null;
              //  return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
          
          
        
        }
        [HttpGet]
       public List<AccountModel> List()
        {
            var account = _accountService.GetAll();
            var model = new List<AccountModel>();
            model = account.Select(x => x.ToModel()).ToList();
            return model;
        }
	}
}