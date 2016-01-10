using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Models
{
    public class BillsModel
    {
        public string FarmerName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsFinal { get; set; }
        public int AccountId { get; set; }
        public double TotalAmount { get; set; }

    }
}