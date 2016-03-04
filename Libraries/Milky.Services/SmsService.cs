﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Configuration;
namespace Blogger.Services
{
    public class SmsService: ISmsService
    {
        private readonly string SMS_API;
        public SmsService()
        {
            SMS_API = WebConfigurationManager.AppSettings["smsApi"];
        }
        public void SendSms(string mobile, string message)
        {
            if (string.IsNullOrEmpty(mobile) || mobile.Length != 10)
                throw new Exception("Enter a 10 digit valid mobile number");

            try
            {
                var api = string.Format(SMS_API, mobile, message);

                WebClient client = new WebClient();
                var webRequest = (HttpWebRequest)WebRequest.Create(api);
                var webResp = (HttpWebResponse)webRequest.GetResponse();
                var statusCode = webResp.StatusCode;


                if (statusCode != HttpStatusCode.OK)
                    throw new Exception(string.Format("Status Code {0}, Description {1}", webResp.StatusCode, webResp.StatusDescription));


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
