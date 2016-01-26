using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface ICustomerService
    {
        Customer GetById(int id);
        Customer GetByClientIdAccountId(int clientId, int accountId);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        List<Customer> GetAll();
        List<Customer> GetAll(int accountId);
    }
}