using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface ICityService
    {
        City GetById(int id);
        void Insert(City city);
        void Update(City city);
        void Delete(City city);
        List<City> GetAll();
    }
}