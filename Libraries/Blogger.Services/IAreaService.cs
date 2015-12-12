using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface IAreaService
    {
        Area GetById(int id);
        void Insert(Area area);
        void Update(Area area);
        void Delete(Area area);
        List<Area> GetAll();
    }
}