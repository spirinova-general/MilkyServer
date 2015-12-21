using AutoMapper;
using Blogger.Core.Domain;
using Blogger.Data;
using Blogger.Services;
using Contacts.Web.Extensions;
using Contacts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Omu.ValueInjecter;


namespace Contacts.Web.Controllers
{
    public class SyncObjectController : ApiController
    {
        #region Field
        private IBillService _billService;
        private IAccountService _accountService;
        private ICustomerService _customerService;
        private ICustomerSettingService _customerSettingService;
        private IDeliveryService _deliveryServie;
        private IGlobalSettingService _globalSettingService;
        private IAccountAreaMappingService _accountAreaMappingsService;
        private IAreaService _areaService;
        #endregion

        #region Ctor
        public SyncObjectController(IBillService billService, IAccountService accountService, ICustomerService customerService, ICustomerSettingService customerSettingService
                                     , IDeliveryService deliveryServie, IGlobalSettingService globalSettingService, IAccountAreaMappingService accountAreaMappingsService, IAreaService areaService)
        {
            _billService = billService;
            _accountService = accountService;
            _customerService = customerService;
            _customerSettingService = customerSettingService;
            _deliveryServie = deliveryServie;
            _globalSettingService = globalSettingService;
            _accountAreaMappingsService = accountAreaMappingsService;
            _areaService = areaService;
        }
        #endregion


        [HttpPost]
        public HttpResponseMessage SyncData([FromBody] string model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Convert JSON to Syncobject, put actual object
                    var syncObject = new SyncObjectModel();
                    syncObject = Newtonsoft.Json.JsonConvert.DeserializeObject<SyncObjectModel>(model);

                    CreateOrUpdateAccount(syncObject.Account_List);
                    CreateOrUpdateCustomer(syncObject.Customer_List);
                    CreateOrUpdateCustomerSetting(syncObject.CustomerSetting_List);
                    CreateOrUpdateDelivery(syncObject.Delivery_List);
                    CreateOrUpdateGlobalSetting(syncObject.GlobalSetting_List);
                    CreateOrUpdateAccount_Area_Mapping(syncObject.Account_Area_Mapping_List);
                    CreateOrUpdateBills(syncObject.Bill_List);

                    return Request.CreateResponse(HttpStatusCode.OK, "Data Updated Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //we called it locally
        [HttpGet]
        public HttpResponseMessage InsertBills()
        {
            try
            {
                var isBillPresentForMonth = _billService.IsBillPresentForMonth();

                if (isBillPresentForMonth)
                    throw new Exception("Bill already generated for this month ");

                _billService.InsertBills();

                //if success insert current datetime
                _billService.InsertBillLog();

                return Request.CreateResponse(HttpStatusCode.OK, "Bills inserted Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        public List<BillsLog> GetLastFiveBillLogs()
        {
            try
            {
                return _billService.GetLastFiveBillLogs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public string GetPendingBills(int accountId)//(Person obj )
        {
            try
            {
                if (accountId == 0)
                    throw new ArgumentNullException("Customer Id is 0");

                var bills = _billService.GetAllPending(accountId);

                var JsonData = Newtonsoft.Json.JsonConvert.SerializeObject(bills);

                return JsonData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public bool IsValidUser(string farmerCode)
        {
            if (string.IsNullOrEmpty(farmerCode))
                throw new ArgumentNullException("farmerCode");

            return _accountService.IsValidUser(farmerCode);
        }

        [HttpPost]
        public HttpResponseMessage AddUser(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("accout");

            _accountService.Insert(account);

            return Request.CreateResponse(HttpStatusCode.Created, "User Added Successfully");
        }

        [HttpGet]
        public string GetAllAreas()
        {
            try
            {
                var area = _areaService.GetAll();

                var JsonData = Newtonsoft.Json.JsonConvert.SerializeObject(area);

                return JsonData;

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        #region private methods

        private void CreateOrUpdateBills(List<Bill> bills)
        {
            foreach (var bill in bills)
            {
                var newbills = _billService.GetById(bill.Id);
                bill.Dirty = 0;

                if (bill != null)
                {
                    if (bill.DateModified < bill.DateModified)
                    {
                        newbills.InjectFrom(bill);
                        _billService.Update(newbills);
                    }
                }
                else
                    _billService.Insert(newbills);
            }
        }

        private void CreateOrUpdateAccount_Area_Mapping(List<Account_Area_Mapping> accountAreaMappings)
        {
            foreach (var accountAreaMapping in accountAreaMappings)
            {
                var newAccountAreaMapping = _accountAreaMappingsService.GetById(accountAreaMapping.Id);
                accountAreaMapping.Dirty = 0;

                if (newAccountAreaMapping != null)
                {
                    if (newAccountAreaMapping.DateModified < accountAreaMapping.DateModified)
                    {
                        newAccountAreaMapping.InjectFrom(accountAreaMapping);
                        _accountAreaMappingsService.Update(newAccountAreaMapping);
                    }
                }
                else
                    _accountAreaMappingsService.Insert(accountAreaMapping);
            }
        }

        private void CreateOrUpdateGlobalSetting(List<GlobalSetting> globalSettings)
        {
            foreach (var globalSetting in globalSettings)
            {
                var newglobalSetting = _globalSettingService.GetById(globalSetting.Id);
                globalSetting.Dirty = 0;

                if (newglobalSetting != null)
                {
                    if (newglobalSetting.DateModified < globalSetting.DateModified)
                    {
                        newglobalSetting.InjectFrom(globalSetting);
                        _globalSettingService.Update(newglobalSetting);
                    }
                }
                else
                    _globalSettingService.Insert(globalSetting);
            }
        }

        private void CreateOrUpdateDelivery(List<Delivery> deliveries)
        {
            foreach (var delivery in deliveries)
            {
                var newdelivery = _deliveryServie.GetById(delivery.Id);
                delivery.Dirty = 0;

                if (newdelivery != null)
                {
                    if (newdelivery.DateModified < delivery.DateModified)
                    {
                        newdelivery.InjectFrom(delivery);
                        _deliveryServie.Update(newdelivery);
                    }
                }
                else
                    _deliveryServie.Insert(delivery);
            }
        }

        private void CreateOrUpdateCustomerSetting(List<CustomerSetting> customerSettings)
        {
            foreach (var customerSetting in customerSettings)
            {
                var newCustomerSetting = _customerSettingService.GetById(customerSetting.Id);
                customerSetting.Dirty = 0;

                if (newCustomerSetting != null)
                {
                    if (newCustomerSetting.DateModified < customerSetting.DateModified)
                    {
                        newCustomerSetting.InjectFrom(customerSetting);
                        _customerSettingService.Update(newCustomerSetting);
                    }
                }
                else
                    _customerSettingService.Insert(customerSetting);
            }

        }

        private void CreateOrUpdateAccount(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                var newAccount = _accountService.GetById(account.Id);
                account.Dirty = 0;

                if (newAccount != null)
                {
                    if (newAccount.DateModified < account.DateModified)
                    {
                        newAccount.InjectFrom(account);
                        _accountService.Update(newAccount);
                    }

                }
                else
                    _accountService.Insert(account);
            }


            //throw new NotImplementedException();
        }

        private void CreateOrUpdateCustomer(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var newCustomer = _customerService.GetById(customer.Id);
                customer.Dirty = 0;

                if (newCustomer != null)
                {
                    if (newCustomer.DateModified < customer.DateModified)
                    {
                        newCustomer.InjectFrom(customer);
                        _customerService.Update(newCustomer);
                    }
                }
                else
                    _customerService.Insert(customer);


            }
        }

        #endregion



        //just for testing purpose..
        [HttpGet]
        public string TestGetAll()
        {

            var model = new SyncObjectModel();

            var customerList = _customerService.GetAll(1);
            var customerSettingList = _customerSettingService.GetAll(1);

            model.Customer_List.AddRange(customerList);
            model.CustomerSetting_List.AddRange(customerSettingList);

            var JsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return JsonData;
        }



    }
}