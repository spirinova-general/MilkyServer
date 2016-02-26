using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Services
{
   public interface IAccountService
    {
        Account GetById(int id);
        void Insert(Account account);
        void Update(Account account);
        void Delete(Account account);
        List<Account> GetAll();

        Account GetByMobileNumber(string number);
        bool IsValidUser(string farmerCode);
    }
}
