using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class AreaService : IAreaService
    {
        #region Field
        private IRepository<Area> _areaRepository;
        #endregion

        #region Ctor
        public AreaService(IRepository<Area> areaRepository)
        {
            this._areaRepository = areaRepository;
        }
        #endregion

        #region
        public Area GetById(int id)
        {
            var query = (from c in _areaRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(Area area)
        {
            if (area == null)
                throw new ArgumentNullException("Area");
            _areaRepository.Insert(area);
        }
        public void Update(Area area)
        {
            if (area == null)
                throw new ArgumentNullException("Area");
            _areaRepository.Update(area);
        }
        public void Delete(Area area)
        {
            if (area == null)
                throw new ArgumentNullException("Area");
            _areaRepository.Delete(area);
        }
        public List<Area> GetAll()
        {
            var query = (from c in _areaRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }
        #endregion
    }
}