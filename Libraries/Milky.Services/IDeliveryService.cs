using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface IDeliveryService
    {
        Delivery GetById(int id);
        Delivery GetByClientIdAccountId(int clientId, int accountId);
        void Insert(Delivery delivery);
        void Update(Delivery delivery);
        void Delete(Delivery delivery);
        List<Delivery> GetAll();
        List<Delivery> GetAll(int customerId);
        void UpdateDeliverySetting(int customerId, DateTime date, int newQuantity);
    }
}