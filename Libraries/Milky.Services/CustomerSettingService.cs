using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class CustomerSettingService : ICustomerSettingService
    {
        #region Field
        private IRepository<CustomerSetting> _customerSettingRepository;
        #endregion

        #region Ctor
        public CustomerSettingService(IRepository<CustomerSetting> customerSettingRepository)
        {
            this._customerSettingRepository = customerSettingRepository;
        }
        #endregion

        #region
        public CustomerSetting GetById(int id)
        {
            var query = (from c in _customerSettingRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(CustomerSetting customerSetting)
        {
            if (customerSetting == null)
                throw new ArgumentNullException("CustomerSetting");
            _customerSettingRepository.Insert(customerSetting);
        }
        public void Update(CustomerSetting customerSetting)
        {
            if (customerSetting == null)
                throw new ArgumentNullException("CustomerSetting");
            _customerSettingRepository.Update(customerSetting);
        }
        public void Delete(CustomerSetting customerSetting)
        {
            if (customerSetting == null)
                throw new ArgumentNullException("CustomerSetting");
            _customerSettingRepository.Delete(customerSetting);
        }
        public List<CustomerSetting> GetAll()
        {
            var query = (from c in _customerSettingRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }

        public List<CustomerSetting> GetAll(int accountId)
        {
            if (accountId == 0)
                throw new ArgumentNullException("accountId");

            var query = (from c in _customerSettingRepository.Table
                         where c.AccountId == accountId
                         orderby c.Id
                         select c);
            return query.ToList();
        }

        public CustomerSetting GetByCustomerId(int customerId)
        {
            if (customerId == 0)
                throw new ArgumentNullException("customerId");

            var query = (from c in _customerSettingRepository.Table
                         where c.CustomerId == customerId
                         orderby c.Id
                         select c);

            return query.FirstOrDefault();
        }
        #endregion
    }
}