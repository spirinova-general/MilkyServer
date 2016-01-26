using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Models
{
    public class SyncObjectModel
    {
        public SyncObjectModel()
        {
            Account_List = new List<Account>();
            Account_Area_Mapping_List = new List<Account_Area_Mapping>();
            Area_List = new List<Area>();
            Bill_List = new List<Bill>();
            City_List = new List<City>();
            Customer_List = new List<Customer>();
            CustomerSetting_List = new List<CustomerSetting>();
            Delivery_List = new List<Delivery>();
            GlobalSetting_List = new List<GlobalSetting>();
        }


        public List<Account> Account_List;
        public List<Account_Area_Mapping> Account_Area_Mapping_List;
        public List<Area> Area_List;
        public List<Bill> Bill_List;
        public List<City> City_List;
        public List<Customer> Customer_List;
        public List<CustomerSetting> CustomerSetting_List;
        public List<Delivery> Delivery_List;
        public List<GlobalSetting> GlobalSetting_List;
    }
}