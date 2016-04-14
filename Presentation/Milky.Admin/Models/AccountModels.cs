using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Milky.Admin.Models
{
    public partial class AccountModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FarmerCode { get; set; }
        public string FarmerName { get; set; }
        public string Validated { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int TotalSms { get; set; }
        public int NewSms { get; set; }
    }
}
