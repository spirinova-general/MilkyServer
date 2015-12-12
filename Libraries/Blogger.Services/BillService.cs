using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class BillService : IBillService
    {
        #region Field
        private IRepository<Bill> _billRepository;
        private ICustomerService _customerService;
        private IDeliveryService _deliveryService;
        private ICustomerSettingService _customerSettingService;
        private IRepository<BillsLog> _billsLogRepository;

        private int month;
        private int year;
        private int lastDay;
        #endregion

        #region Ctor
        public BillService(IRepository<Bill> billRepository, ICustomerService customerService, IDeliveryService deliveryService, ICustomerSettingService customerSettingSerive,
             IRepository<BillsLog> billsLogRepository)
        {
            _billRepository = billRepository;
            _customerService = customerService;
            _deliveryService = deliveryService;
            _customerSettingService = customerSettingSerive;
            _billsLogRepository = billsLogRepository;

            month = DateTime.Now.AddMonths(-1).Month;
            year = DateTime.Now.Year;
            lastDay = DateTime.DaysInMonth(year, month);
        }
        #endregion

        #region
        public Bill GetById(int id)
        {
            var query = (from c in _billRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(Bill bill)
        {
            if (bill == null)
                throw new ArgumentNullException("bill");
            _billRepository.Insert(bill);
        }
        public void Update(Bill bill)
        {
            if (bill == null)
                throw new ArgumentNullException("bill");
            _billRepository.Update(bill);
        }
        public void Delete(Bill bill)
        {
            if (bill == null)
                throw new ArgumentNullException("bill");
            _billRepository.Delete(bill);
        }
        public List<Bill> GetAll(int customerId)
        {
            var query = (from c in _billRepository.Table
                         orderby c.CustomerId == customerId
                         select c);
            return query.ToList();
        }

        public List<Bill> GetAllPending(int accountId)
        {
            var query = (from c in _billRepository.Table
                         orderby c.CustomerId == accountId && c.IsCleared == false
                         select c);
            return query.ToList();
        }

        public void InsertBills()
        {
            //  Get all customers that are not deleted
            var customers = _customerService.GetAll();

            foreach (var customer in customers)
            {
                Bill bill = new Bill();
                bill.AccountId = customer.AccountId;
                bill.Adjustment = 0.0;
                bill.Balance = customer.Balance;
                bill.TotalAmount = CalculateBill(customer);//setting
                bill.CustomerId = customer.Id;
                bill.DateAdded = DateTime.Now;
                bill.DateModified = DateTime.Now;
                bill.Dirty = 0;
                bill.IsCleared = false;
                bill.PaymentMade = 0.0;
                bill.Quantity = CalculateQuantitySum(customer);
                bill.StartDate = new DateTime(year, month, 1);
                bill.EndDate = new DateTime(year, month, lastDay);
                bill.Tax = 0.0;

                _billRepository.Insert(bill);
            }
        }

        private double CalculateBill(Customer customer)
        {
            var quantity = CalculateQuantitySum(customer);

            var customerSetting = _customerSettingService.GetByCustomerId(customer.Id);

            var totalAmount = (quantity * customerSetting.Rate) - customer.Balance;

            return totalAmount;
        }

        private double CalculateQuantitySum(Customer customer)
        {
            var deliveries = _deliveryService.GetAll(customer.Id);

            var customerSetting = _customerSettingService.GetByCustomerId(customer.Id);

            var quantity = deliveries.Select(x => x.Quantity).Sum();

            var totalquantity = quantity + ((lastDay - CalculateTotalQuantity(customer)) * customerSetting.DefaultQuantity);

            return totalquantity;
        }

        private int CalculateTotalQuantity(Customer customer)
        {
            var deliveries = _deliveryService.GetAll(customer.Id);

            return deliveries.Count > 0 ? deliveries.Select(x => x.Quantity).Count() : 0;
        }

        public void InsertBillLog()
        {
            var billsLog = new BillsLog();
            billsLog.GeneratedOn = DateTime.Now;

            _billsLogRepository.Insert(billsLog);
        }

        public List<BillsLog> GetLastFiveBillLogs()
        {
            var bills = (from p in _billsLogRepository.Table
                         select p).OrderByDescending(x => x.Id).Take(5);

            return bills.ToList();
        }

        #endregion
    }
}
