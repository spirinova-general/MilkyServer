using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface ICustomerSettingService
    {
        CustomerSetting GetById(int id);
        CustomerSetting GetByClientIdAccountId(int clientId, int accountId);
        void Insert(CustomerSetting customerSetting);
        void Update(CustomerSetting customerSetting);
        void Delete(CustomerSetting customerSetting);
        List<CustomerSetting> GetAll();
        List<CustomerSetting> GetAll(int accountId);
        CustomerSetting GetByCustomerId(int customerId);
    }
}