using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class DeliveryService : IDeliveryService
    {
        #region Field
        private IRepository<Delivery> _deliveryRepository;
        #endregion

        #region Ctor
        public DeliveryService(IRepository<Delivery> deliveryRepository)
        {
            this._deliveryRepository = deliveryRepository;
        }
        #endregion

        #region
        public Delivery GetById(int id)
        {
            var query = (from c in _deliveryRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }

        public Delivery GetByClientIdAccountId(int clientId, int accountId)
        {
            var query = (from c in _deliveryRepository.Table
                         where c.AccountId == accountId && c.ClientId == clientId
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(Delivery delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException("Delivery");
            _deliveryRepository.Insert(delivery);
        }
        public void Update(Delivery delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException("delivery");
            _deliveryRepository.Update(delivery);
        }
        public void Delete(Delivery delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException("delivery");
            _deliveryRepository.Delete(delivery);
        }
        public List<Delivery> GetAll()
        {
            var query = (from c in _deliveryRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }

        public List<Delivery> GetAll(int customerId)
        {
            var query = (from c in _deliveryRepository.Table.AsEnumerable()
                         where c.CustomerId == customerId //&& c.DeliveryDate()
                         orderby c.Id
                         select c);
            return query.ToList();
        }

        private double GetDeliveryOfCustomer(int customerId, DateTime date)
        {

            Delivery delivery = (from d in _deliveryRepository.Table
                                 where d.StartDate == date && d.EndDate == date
                                 select d).FirstOrDefault();

            if (delivery == null)
            {
                //this means there is no specific delivery for that date, enddate stores MAxDate when we insert a customer

                delivery = (from d in _deliveryRepository.Table
                            where d.StartDate < date && d.EndDate > date
                            select d).FirstOrDefault();

            }
            return delivery.Quantity;
        }

        //To get total delivery
        public double GetTotalDeliveryForMonth(int customerId, int month)
        {
            double quantity = 0.0;
            foreach (var days in GetDates(DateTime.Now.Year, month))
            {
                quantity += GetDeliveryOfCustomer(customerId, days);
            }
            return quantity;

        }

        private static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        //    //This adds the delivery which we change from the delivery details page
        public void ChangeDeliveryForDate(int custmerId, DateTime date, int quantity)
        {
            //Create a delivery entry, and insert the entry in table
            Delivery entry = new Delivery();

            entry.CustomerId = custmerId;
            entry.StartDate = entry.EndDate = date;
            entry.Quantity = quantity;
            entry.DateModified = DateTime.Now;
            entry.Dirty = 0;
            entry.AccountId = 1;//need to pass accountid here
            entry.ClientId = 1;//need to discuss it
            entry.DeliveryDate = DateTime.Now;

            _deliveryRepository.Insert(entry);

        }


        //    //This gets called when someone changes default setting of a customer
        public void UpdateDeliverySetting(int customerId, DateTime date, int newQuantity)
        {
            Delivery oldEntry = (from d in _deliveryRepository.Table
                                 where d.StartDate < date && d.EndDate > date
                                 select d).FirstOrDefault();

            if (oldEntry == null)
                throw new ArgumentNullException("Delivery is null");

            //Update the enddate of old entry
            oldEntry.EndDate = date;
            _deliveryRepository.Update(oldEntry);

            Delivery newEntry = new Delivery();
            newEntry.StartDate = date;
            newEntry.EndDate = DateTime.MaxValue;
            newEntry.CustomerId = customerId;
            newEntry.Quantity = newQuantity;
            newEntry.DateModified = DateTime.Now;
            newEntry.Dirty = 0;
            newEntry.AccountId = 1;//need to pass accountid here
            newEntry.ClientId = oldEntry.ClientId;
            newEntry.DeliveryDate = DateTime.Now;
        }


       

        #endregion
    }
}


