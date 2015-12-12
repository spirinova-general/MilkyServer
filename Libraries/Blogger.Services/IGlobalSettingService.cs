using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface IGlobalSettingService
    {
        GlobalSetting GetById(int id);
        void Insert(GlobalSetting globalSetting);
        void Update(GlobalSetting globalSetting);
        void Delete(GlobalSetting globalSetting);
        List<GlobalSetting> GetAll();
    }
}