using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface ISmsService
    {
        void SendSms(string mobile, string message);
    }
}