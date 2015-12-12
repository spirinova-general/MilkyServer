using Blogger.Core;
using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Services
{
   public interface IContactService
    {
        Contact GetById(int id);
        IPagedList<Contact> GetAll(int pageIndex, int pageSize);
        Contact GetContact(string name);
        Contact Insert(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
