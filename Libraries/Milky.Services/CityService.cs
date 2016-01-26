using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class CityService: ICityService
    {
        #region Field
        private IRepository<City> cityRepository;
        #endregion

        #region Ctor
        public CityService(IRepository<City> CityRepository)
        {
            this.cityRepository = CityRepository;
        }
        #endregion

        #region
        public City GetById(int id)
        {
            var query = (from c in cityRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public void Insert(City City)
        {
            if (City == null)
                throw new ArgumentNullException("City");
            cityRepository.Insert(City);
        }
        public void Update(City City)
        {
            if (City == null)
                throw new ArgumentNullException("City");
            cityRepository.Update(City);
        }
        public void Delete(City city)
        {
            if (city == null)
                throw new ArgumentNullException("City");
            cityRepository.Delete(city);
        }
        public List<City> GetAll()
        {
            var query = (from c in cityRepository.Table
                         orderby c.Id
                         select c);
            return query.ToList();
        }
        #endregion
    }
}