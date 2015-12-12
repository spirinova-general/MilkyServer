using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class GlobalSettingService : IGlobalSettingService
    {
        #region Field
        private IRepository<GlobalSetting> _globalSettingRepository;
        #endregion

        #region Ctor
        public GlobalSettingService(IRepository<GlobalSetting> globalSettingRepository)
        {
            this._globalSettingRepository = globalSettingRepository;
        }
        #endregion

        #region
        public GlobalSetting GetById(int id)
        {
            var query = (from c in _globalSettingRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(GlobalSetting globalSetting)
        {
            if (globalSetting == null)
                throw new ArgumentNullException("GlobalSetting");
            _globalSettingRepository.Insert(globalSetting);
        }
        public void Update(GlobalSetting globalSetting)
        {
            if (globalSetting == null)
                throw new ArgumentNullException("GlobalSetting");
            _globalSettingRepository.Update(globalSetting);
        }
        public void Delete(GlobalSetting globalSetting)
        {
            if (globalSetting == null)
                throw new ArgumentNullException("GlobalSetting");
            _globalSettingRepository.Delete(globalSetting);
        }
        public List<GlobalSetting> GetAll()
        {
            var query = (from c in _globalSettingRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }
        #endregion
    }
}