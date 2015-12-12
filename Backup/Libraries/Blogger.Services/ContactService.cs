using Blogger.Core;
using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class ContactService : IContactService
    {
        
         #region Field
        private IRepository<Contact> _contactRepository;
        private IWorkContext _workContext;
        #endregion

        #region Ctor
        public ContactService(IRepository<Contact> contactRepository,
            IWorkContext workContext)
        {
            this._contactRepository = contactRepository;
            this._workContext = workContext;
        }
        #endregion

        #region 
       public Contact GetById(int id)
        {
            var query = (from c in _contactRepository.Table
                         where c.Id == id  
                        select c).FirstOrDefault();
            return query;
        }
       public IPagedList<Contact> GetAll(int pageIndex, int pageSize)
       {
           var query = (from c in _contactRepository.Table
                        where c.AccountId == 1
                        select c);
           query = query.OrderBy(c => c.Name);
           return new PagedList<Contact>(query, pageIndex, pageSize);
       }
      
     
        public  Contact GetContact(string name)
        {
            var query = (from c in _contactRepository.Table
                         where c.Name == name && c.AccountId == _workContext.CurrentUser.AccountId
                         select c).FirstOrDefault();
            return query;
        }
        public Contact Insert(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("Contact");
            _contactRepository.Insert(contact);
            return contact;
        }
        public void Update(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("Contact");
            _contactRepository.Update(contact);
        }
        public void Delete(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("Contact");
            _contactRepository.Delete(contact);

        }
     
    
    }
        #endregion
    
}