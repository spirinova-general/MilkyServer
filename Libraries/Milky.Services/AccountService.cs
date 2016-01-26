using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class AccountService : IAccountService
    {
        #region Field
        private IRepository<Account> _accountRepository;
        #endregion

        #region Ctor
        public AccountService(IRepository<Account> registrationRepository)
        {
            this._accountRepository = registrationRepository;
        }
        #endregion

        #region
        public bool IsValidUser(string farmerCode)
        {
            var account = (from c in _accountRepository.Table
                           where c.FarmerCode == farmerCode
                           select c).FirstOrDefault();

            return account != null ? true : false;
        }

        public Account GetById(int id)
        {
            var query = (from c in _accountRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");
            _accountRepository.Insert(account);
        }
        public void Update(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");
            _accountRepository.Update(account);
        }
        public void Delete(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");
            _accountRepository.Delete(account);
        }
        public List<Account> GetAll()
        {
            var query = (from c in _accountRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }
        #endregion
    }
}