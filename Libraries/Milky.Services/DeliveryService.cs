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
        #endregion
    }
}