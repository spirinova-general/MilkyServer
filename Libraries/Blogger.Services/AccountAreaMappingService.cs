using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class AccountAreaMappingService : IAccountAreaMappingService
    {

        #region Field
        private IRepository<Account_Area_Mapping> _accountAreaMappingRepository;
        #endregion

        #region Ctor
        public AccountAreaMappingService(IRepository<Account_Area_Mapping> accountAreaMappingRepository)
        {
            this._accountAreaMappingRepository = accountAreaMappingRepository;
        }
        #endregion

        #region
        public Account_Area_Mapping GetById(int id)
        {
            var query = (from c in _accountAreaMappingRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(Account_Area_Mapping accountArea)
        {
            if (accountArea == null)
                throw new ArgumentNullException("account Area Mapping");
            _accountAreaMappingRepository.Insert(accountArea);
        }
        public void Update(Account_Area_Mapping accountArea)
        {
            if (accountArea == null)
                throw new ArgumentNullException("account Area Mapping");
            _accountAreaMappingRepository.Update(accountArea);
        }
        public void Delete(Account_Area_Mapping accountArea)
        {
            if (accountArea == null)
                throw new ArgumentNullException("account Area Mapping");
            _accountAreaMappingRepository.Delete(accountArea);
        }
        public List<Account_Area_Mapping> GetAll()
        {
            var query = (from c in _accountAreaMappingRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }
        #endregion
    }
}