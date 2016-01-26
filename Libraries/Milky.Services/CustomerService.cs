using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class CustomerService : ICustomerService
    {
        #region Field
        private IRepository<Customer> _customerRepository;
        #endregion

        #region Ctor
        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        #endregion

        #region
        public Customer GetById(int id)
        {
            var query = (from c in _customerRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");
            _customerRepository.Insert(customer);
        }
        public void Update(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");
            _customerRepository.Update(customer);
        }
        public void Delete(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer");
            _customerRepository.Delete(customer);
        }
        public List<Customer> GetAll()
        {
            var query = (from c in _customerRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }
        public List<Customer> GetAll(int accountId)
        {
            if (accountId == 0)
                throw new ArgumentNullException("account");

            var query = (from c in _customerRepository.Table
                         where c.AccountId == accountId
                         orderby c.Id
                         select c);

            return query.ToList();
        }

        #endregion
    }
}