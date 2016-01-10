using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface IBillService
    {
        Bill GetById(int id);
        void Insert(Bill bill);
        void Update(Bill bill);
        void Delete(Bill bill);
        List<Bill> GetAll(int customerId);
        List<Bill> GetAllPending(int customerId);

        void InsertBills();

        void InsertBillLog();
        List<BillsLog> GetLastFiveBillLogs();
        bool IsBillPresentForMonth();

        List<Bill> GetBillsByAccountId(int accountId);
    }
}