using Blogger.Services;
using Contacts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Blogger.Core.Domain;
using AutoMapper;
namespace Contacts.Web.Controllers
{
    public class ContactController : ApiController
    {
         #region Field
          private readonly IContactService _contactService;
        #endregion

        #region Ctor
          public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }
        #endregion

      [ResponseType(typeof(ContactModel))]
          public HttpResponseMessage Create(ContactModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = new Contact();
                    Mapper.CreateMap<ContactModel, Contact>();
                    contact= Mapper.Map<ContactModel, Contact>(model);
                    _contactService.Insert(contact);
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
      public List<ContactModel> List()
      {
          var contacts = _contactService.GetAll(0, 10);
          var model = new List<ContactModel>();
          //  model = contacts.Select(x => x.ToModel()).ToList();
          foreach (var c in contacts)
          {
              var cModel = new ContactModel();
              Mapper.CreateMap<Contact, ContactModel>();
              model.Add(Mapper.Map<Contact, ContactModel>(c));
              model.Add(cModel);
          }
          return model;
      }

      
    }
}
